using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.SQL
{
    public class SqlLMSParentRepository : ILMSParentRepository
    {
        public List<LmsUser> GetStudents(int UserID)
        {
            List<LmsUser> students = new List<LmsUser>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("UserParentDashboard", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var student = new LmsUser();
                        student.UserID = (int)dr["UserID"];
                        student.FirstName = dr["FirstName"].ToString();
                        student.LastName = dr["LastName"].ToString();

                        students.Add(student);
                    }
                }
            }
            return students;
        }
    }

}
