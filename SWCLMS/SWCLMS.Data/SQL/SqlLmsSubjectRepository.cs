using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.SQL
{
    public class SqlLmsSubjectRepository : IlmsSubjectRepository
    {
        public List<Subject> SubjectGetAll()
        {
            List<Subject> subjects = new List<Subject>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("Select * From Subject", cn);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var subject = new Subject
                        {
                            SubjectID = (int)dr["SubjectID"],
                            SubjectName = dr["SubjectName"].ToString()
                        };

                        subjects.Add(subject);
                    }
                }
            }
            return subjects;
        }
    }
}