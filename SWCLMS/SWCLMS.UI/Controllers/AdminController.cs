using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWCLMS.BLL;
using SWCLMS.Models;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;
using SWCLMS.UI.Models;
using SWCLMS.Data.SQL;


namespace SWCLMS.UI.Controllers
{
    //[Authorize(Roles = "Admin")]  Probably belongs here but at the moment we have an AdminDController to create a plain AdminDashboardView, so as not to touch our original AdminController
    public class AdminController : Controller
    {
        private LmsUserManager _lmsUserManager;
        private LMSRoleManager _lmsRoleManager;


        public AdminController(LmsUserManager lmsUserManager, LMSRoleManager lmsRoleManager)
        {
            _lmsUserManager = lmsUserManager;
            _lmsRoleManager = lmsRoleManager;
        }       

        public ActionResult Index()
        {
            var model = _lmsUserManager.GetUnassignedUsers();

            return View(model);
        }

        public ActionResult GetUserDetails(int ID)
        {
            var gradeLevelRepo = new SqlLMSGradeLevelRepository();
            var roleRepo = new SqlLmsRoleRepository();
            var user = _lmsUserManager.GetUnassignedUserDetails(ID);

            UserDetailsToEditVM model = new UserDetailsToEditVM();
            model.UserDetailsToEdit = user.Data;
            model.CreateGradeLevel(gradeLevelRepo.GradeLevelGetAll());
            model.CreateRole(roleRepo.RoleGetAll());
            var userAllRoles = model.CreateUserRoleList(roleRepo.UserGetAllRoles(ID));
            model.PopulateRolesCheckbox(userAllRoles);

            return View(model);
        }

        [HttpPost]
        //public ActionResult GetUserDetails(UserDetailsToEditVM user) //changed on 6/16-17 changed from EditUserDetails
        public ActionResult GetUserDetails(UserDetailsToEditVM user)
        {
            var request = new LMSUserUpdateRequest();

            request.UserID = user.UserDetailsToEdit.UserID;
            request.ID = user.UserDetailsToEdit.ID;
            request.FirstName = user.UserDetailsToEdit.FirstName;
            request.LastName = user.UserDetailsToEdit.LastName;
            request.GradeLevelID = user.UserDetailsToEdit.GradeLevelID;

            foreach (var roleSelection in user.SelectedRoles)
            {
                if (roleSelection.CheckedStatus)
                {
                    request.RoleNames.Add(roleSelection.RoleName);
                }
            }

            _lmsRoleManager.UpdateRoles(request);
            _lmsUserManager.UpdateUserDetails(request);
            
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult Search()
        {
            var roleRepo = new SqlLmsRoleRepository();
            AdminUserSearch model = new AdminUserSearch();
            model.CreateRole(roleRepo.RoleGetAll());

            return View(model);
        }

        [HttpPost]
        public ActionResult Search(AdminUserSearch user)
        {
            var model = _lmsUserManager.Search(user);
            var roleRepo = new SqlLmsRoleRepository();
            model.CreateRole(roleRepo.RoleGetAll());

            return View(model);
        }
    }
}