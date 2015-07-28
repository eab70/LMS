using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWCLMS.Models.Tables;

namespace SWCLMS.UI.Models
{
    public class StudentCourseAssignmentGradesVM
    {
        public Course Course { get; set; }
        public List<RosterAssignment> Assignments { get; set; }
    }
}