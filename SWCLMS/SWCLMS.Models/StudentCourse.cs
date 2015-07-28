using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models
{
    public class StudentCourse
    {
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public string CurrentGrade { get; set; }
        public string CourseName { get; set; }
        
    }
   
}
