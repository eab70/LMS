using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models.Tables
{
    public class Roster
    {
        public int RosterID { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
        public string CurrentGrade { get; set; }
        public bool IsDeleted { get; set; }  //bit??      
    }
}
