using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SWCLMS.Models.Tables;

namespace SWCLMS.UI.Models
{
    public class StudentDashboardVM
    {
        public int UserID { get; set; }
        public Course Courses { get; set; }
        public string CurrentGrade { get; set; }
        
    }

}