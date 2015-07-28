using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using SWCLMS.BLL;
using SWCLMS.Data.SQL;
using SWCLMS.UI.Models;

namespace SWCLMS.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Teacher"))
                {
                    return RedirectToAction("Index", "Teacher");
                }
                if (User.IsInRole("Student"))
                {
                    return RedirectToAction("Index", "Student");
                }
                if (User.IsInRole("Parent"))
                {
                    return RedirectToAction("Index", "Parent");
                }
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }

                return RedirectToAction("NotApprovedYet", "Home");
            }

            var gradeLevelRepo = new SqlLMSGradeLevelRepository();
            var model = new LoginRegistrationVM();            
            model.RegisterViewModel.CreateGradeLevel(gradeLevelRepo.GradeLevelGetAll());
            model.RegisterViewModel.PopulateSelectListItems(gradeLevelRepo.GradeLevelGetAll());//Added 6/28--Lis

            return View(model);
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult NotApprovedYet()
        {
            return View();

        }
    }
}