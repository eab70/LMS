using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.SQL
{
    public class SqlLmsStudentCourseRepository : ILmsStudentCourseRepository
    {
        public List<StudentCourse> GetStudentCourses(int userID)
        {
            List<StudentCourse> student = new List<StudentCourse>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("UserStudentDashboard", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var courses = new StudentCourse();
                        //courses.UserID = (int) dr["UserID"];
                        courses.CourseID = (int) dr["CourseID"];
                        courses.CourseName = dr["CourseName"].ToString();
                        courses.CurrentGrade = dr["CurrentGrade"].ToString();

                        student.Add(courses);
                    }
                }
                return student;
            }
        }


        public List<RosterAssignment> CourseAssignmentGrades(int CourseID)
        {
            List<RosterAssignment> grades = new List<RosterAssignment>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("CourseAssignmentGrades", cn); //sproc has "slide12" in its name
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseID", CourseID); //changed from UserID

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var assignments = new RosterAssignment();
                        assignments.AssignmentID = (int) dr["AssignmentID"];
                        assignments.Grade = dr["Grade"].ToString();
                        assignments.Percentage = (decimal) dr["Percentage"];

                        grades.Add(assignments);
                    }
                }
            }
            return grades;
        }
    }
}
