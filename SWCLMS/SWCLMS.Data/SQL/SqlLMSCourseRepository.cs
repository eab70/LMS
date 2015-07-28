using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.SQL
{
    public class SqlLMSCourseRepository : ILmsCourseRepository
    {
        public List<TeacherCourses> GetTeacherCourses(int userID)
        {
            List<TeacherCourses> courses = new List<TeacherCourses>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("UserTeacherDashboard", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var course = new TeacherCourses();
                        course.CourseID = (int)dr["CourseID"];
                        course.CourseName = dr["CourseName"].ToString();
                        course.IsArchived = (bool)dr["IsArchived"];

                        courses.Add(course);
                    }
                }
            }
            return courses;
        }

        public Course ShowTeacherCourse(int courseID)
        {
            Course course = new Course();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("CourseInformationGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        course.CourseID = (int)dr["CourseID"];
                        course.CourseName = dr["CourseName"].ToString();
                        course.GradeLevel = (byte)dr["GradeLevel"];
                        course.IsArchived = (bool)dr["IsArchived"];
                        course.StartDate = (DateTime)dr["StartDate"];
                        course.EndDate = (DateTime)dr["EndDate"];

                        if (dr["CourseDescription"] != DBNull.Value)
                        {
                            course.CourseDescription = dr["CourseDescription"].ToString();
                        }
                    }
                }
            }
            return course;
        }

        public void EditTeacherCourse(Course courseToEdit)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("CourseEditInformation", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseID", courseToEdit.CourseID);
                cmd.Parameters.AddWithValue("@CourseName", courseToEdit.CourseName);
                cmd.Parameters.AddWithValue("@GradeLevel", courseToEdit.GradeLevel);
                cmd.Parameters.AddWithValue("@IsArchived", courseToEdit.IsArchived);
                cmd.Parameters.AddWithValue("@StartDate", courseToEdit.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", courseToEdit.EndDate);
                cmd.Parameters.AddWithValue("@CourseDescription", courseToEdit.CourseDescription);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddCourse(Course courseToAdd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("CourseAddCourse", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", courseToAdd.TeacherID);
                cmd.Parameters.AddWithValue("@SubjectID", courseToAdd.SubjectID);
                cmd.Parameters.AddWithValue("@CourseName", courseToAdd.CourseName);
                cmd.Parameters.AddWithValue("@CourseDescription", courseToAdd.CourseDescription);
                cmd.Parameters.AddWithValue("@GradeLevel", courseToAdd.GradeLevel);
                cmd.Parameters.AddWithValue("@IsArchived", courseToAdd.IsArchived);
                cmd.Parameters.AddWithValue("@StartDate", courseToAdd.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", courseToAdd.EndDate);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
