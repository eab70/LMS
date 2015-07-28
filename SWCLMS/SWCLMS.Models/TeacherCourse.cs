using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models
{
    public class TeacherCourse
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int NumberOfStudents { get; set; }
        public byte IsArchived { get; set; }
        public List<Course> Course { get; set; }

    }
}
