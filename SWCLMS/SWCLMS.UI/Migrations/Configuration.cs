using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SWCLMS.UI.Models;

namespace SWCLMS.UI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SWCLMS.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

      protected override void Seed(SWCLMS.UI.Models.ApplicationDbContext context)
        {
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
 
            if (roleMgr.RoleExists("Admin"))
                return;
 
            CreateRoles(roleMgr);
 
            CreateAdmin(userMgr);
            CreateTeacher(userMgr);
            CreateStudent(userMgr);
            CreateParent(userMgr);
        }
 
        private void CreateParent(UserManager<ApplicationUser> userMgr)
        {
            var user = new ApplicationUser()
            {
                UserName = "parent@swcguild.com"
            };
 
            userMgr.Create(user, "testing123");
            userMgr.AddToRole(user.Id, "Parent");
        }
 
        private void CreateStudent(UserManager<ApplicationUser> userMgr)
        {
            var user = new ApplicationUser()
            {
                UserName = "student1@swcguild.com"
            };
 
            userMgr.Create(user, "testing123");
            userMgr.AddToRole(user.Id, "Student");
 
            var user2 = new ApplicationUser()
            {
                UserName = "student2@swcguild.com"
            };
 
            userMgr.Create(user2, "testing123");
            userMgr.AddToRole(user2.Id, "Student");
 
        }
 
        private void CreateTeacher(UserManager<ApplicationUser> userMgr)
        {
            var user = new ApplicationUser()
            {
                UserName = "teacher@swcguild.com"
            };
 
            userMgr.Create(user, "testing123");
            userMgr.AddToRole(user.Id, "Teacher");
 
        }
 
        private void CreateAdmin(UserManager<ApplicationUser> userMgr)
        {
            var user = new ApplicationUser()
            {
                UserName = "admin@swcguild.com"
            };
            userMgr.Create(user, "testing123");
            userMgr.AddToRole(user.Id, "Admin");
 
        }
 
        private void CreateRoles(RoleManager<IdentityRole> roleMgr)
        {
            roleMgr.Create(new IdentityRole("Admin"));
            roleMgr.Create(new IdentityRole("Teacher"));
            roleMgr.Create(new IdentityRole("Parent"));
            roleMgr.Create(new IdentityRole("Student"));
        }
    }
    }
