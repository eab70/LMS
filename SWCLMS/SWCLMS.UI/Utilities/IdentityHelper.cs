using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ninject;
using Ninject.Modules;
using SWCLMS.BLL;
using SWCLMS.Models.Tables;

namespace SWCLMS.UI.Utilities
{
    public class IdentityHelper
    {
        private const string CurrentUser = "CURRENT_USER";

        public static LmsUser GetLmsUserForCurrentUser(Controller controller)
        {
            LmsUser user;

            if (controller.Session[CurrentUser] == null)
            {
                var userManager = controller.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var aspNetId = userManager.FindByName(controller.User.Identity.Name).Id;
                var lmsUserManager = GetKernel().Get<LmsUserManager>();

                user = lmsUserManager.GetByAspNetId(aspNetId);
                controller.Session[CurrentUser] = user;
            }
            else
            {
                user = (LmsUser)controller.Session[CurrentUser];
            }

            return user;
        }

        private static IKernel _kernel;
        private static IKernel GetKernel()
        {
            if (_kernel == null)
            {
                _kernel = new StandardKernel();
                _kernel.Load(new INinjectModule[] { new SqlNinjectModule() });
            }

            return _kernel;
        }
    }
}
