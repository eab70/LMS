using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWCLMS.BLL;
using SWCLMS.UI.Utilities;

namespace SWCLMS.UI.Controllers
{
    [Authorize(Roles = "Parent")]
    public class ParentController : Controller
    {
        private LMSParentManager _lmsParentManager;

        public ParentController(LMSParentManager lmsParentManager)
        {
            _lmsParentManager = lmsParentManager;
        }

        // GET: Parent
        public ActionResult Index()
        {
            var currentUser = IdentityHelper.GetLmsUserForCurrentUser(this);
            var model = _lmsParentManager.GetStudents(currentUser.UserID);

            return View(model);
        }
    }
}