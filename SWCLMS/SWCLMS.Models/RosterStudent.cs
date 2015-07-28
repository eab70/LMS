using System.Collections.Generic;
using System.Web.Mvc;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models
{
    public class RosterStudent
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RosterID { get; set; }
        public int CourseID { get; set; }
        public string CurrentGrade { get; set; }
        public bool IsDeleted { get; set; }
        public byte? GradeLevelID { get; set; }        
    }
}