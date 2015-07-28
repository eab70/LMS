using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models
{
    public class TeacherCourses
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int NumberOfStudents { get; set; }
        public bool IsArchived { get; set; }
        public List<Course> Course { get; set; }
        
    }
}