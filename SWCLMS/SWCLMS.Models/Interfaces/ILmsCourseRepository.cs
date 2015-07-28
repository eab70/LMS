using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Interfaces
{
    public interface ILmsCourseRepository
    {
        List<TeacherCourses> GetTeacherCourses(int userID);
        Course ShowTeacherCourse(int courseID);
        void EditTeacherCourse(Course courseToEdit);
        void AddCourse(Course courseToAdd);
    }
}