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
    public class SqlLMSRosterRepository : ILmsRosterRepository
    {
        public List<RosterStudent> GetRosterStudents(int teacherID, int courseID)
        {
            List<RosterStudent> students = new List<RosterStudent>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("RosterGetStudentsInCourse", cn); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                cmd.Parameters.AddWithValue("@CourseID", courseID);


                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var student = new RosterStudent();                        
                        student.FirstName = dr["FirstName"].ToString();
                        student.LastName = dr["LastName"].ToString();
                        student.Email = dr["Email"].ToString();
                        student.IsDeleted = (bool)dr["IsDeleted"];
                        if (dr["GradeLevelID"] != DBNull.Value)
                            student.GradeLevelID = (byte)dr["GradeLevelID"];
                        student.RosterID = (int)dr["RosterID"];
                        student.CourseID = (int)dr["CourseID"];
                        
                        students.Add(student);
                    }
                }
            }

            return students;
        }

        public void RemoveStudent(int RosterID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("RosterRemoveStudent", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RosterID", RosterID);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddStudent(RosterStudent student)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("RosterInsertStudent", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseID", student.CourseID);
                cmd.Parameters.AddWithValue("@UserID", student.UserID);
                cmd.Parameters.AddWithValue("@CurrentGrade", student.CurrentGrade);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<RosterSearchResult> RosterUserSearch(RosterStudent studentSearch)
        {
            List<RosterSearchResult> students = new List<RosterSearchResult>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("RosterGetStudentsNotInCourse", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(studentSearch.LastName))
                    cmd.Parameters.Add(new SqlParameter("@LastName", studentSearch.LastName));

                if (studentSearch.GradeLevelID != null)
                    cmd.Parameters.Add(new SqlParameter("@GradeLevelID", studentSearch.GradeLevelID));

                cmd.Parameters.AddWithValue("@CourseID", studentSearch.CourseID);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var student = new RosterSearchResult();
                        student.UserID = (int)dr["UserID"];
                        student.FirstName = dr["FirstName"].ToString();
                        student.LastName = dr["LastName"].ToString();
                        student.GradeLevelName = dr["GradeLevelName"].ToString();

                        students.Add(student);
                    }
                }
            }
            return students;
        }
    }
}
