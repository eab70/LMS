using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models.Tables
{
    public class RosterAssignment
    {
        public int RosterAssignmentID { get; set; }
        public int RosterID { get; set; }
        public int AssignmentID { get; set; }
        public decimal? PointsEarned { get; set; }
        public decimal? Percentage { get; set; }
        public string Grade { get; set; }
    }
}
