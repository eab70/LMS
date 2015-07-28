using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.Mocks
{
    public class MockLmsStudentCourseRepository : ILmsStudentCourseRepository
    {
        public List<StudentCourse> GetStudentCourses(int userID)
        {
            List<StudentCourse> student = new List<StudentCourse>();

            return student;
        }

        public List<RosterAssignment> CourseAssignmentGrades(int UserID)
        {
            List<RosterAssignment> grades = new List<RosterAssignment>();

            return grades;
        }
    }

}
