using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWCLMS.Models.Tables;
using System.Web.Mvc;
using SWCLMS.Models;

namespace SWCLMS.UI.Models
{
    public class RosterViewModel
    {
        public List<RosterStudent> CourseRoster { get; set; }
        public List<LmsUser> UserSearch { get; set; }
        public List<RosterSearchResult> StudentSearchResults { get; set; }
        //public LmsUser StudentNotInClass { get; set; }
        public RosterStudent StudentInClass { get; set; }
        public Course Course { get; set; }        
        public string LastName { get; set; }
        public string FirstName { get; set; }
        //public byte? GradeLevelID { get; set; }
        public string GradeLevelID { get; set; }

        public List<SelectListItem> GradeLevels { get; set; }

        public void CreateGradeLevel(List<GradeLevel> gradeLevels)
        {
            GradeLevels = new List<SelectListItem>();

            foreach (var g in gradeLevels)
            {
                GradeLevels.Add(
                    new SelectListItem() { Text = g.GradeLevelName, Value = g.GradeLevelID.ToString() }
                    );
            }
        }
    }
}