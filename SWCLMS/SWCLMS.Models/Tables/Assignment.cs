using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models.Tables
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int CourseID { get; set; }
        public string AssignmentName { get; set; }
        public int PossiblePoints { get; set; }
        public DateTime DueDate { get; set; }
        public string AssignmentDescription { get; set; }
    }
}
