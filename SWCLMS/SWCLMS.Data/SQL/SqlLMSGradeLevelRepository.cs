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
    public class SqlLMSGradeLevelRepository : ILMSGradeLevelRepository
    {
        public List<GradeLevel> GradeLevelGetAll()
        {
            List<GradeLevel> gradeLevels = new List<GradeLevel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("GradeLevelGetAll", cn); 
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var gradeLevel = new GradeLevel();
                        if (dr["GradeLevelID"] != DBNull.Value)
                            gradeLevel.GradeLevelID = (byte)dr["GradeLevelID"];
                        gradeLevel.GradeLevelName = dr["GradeLevelName"].ToString();
                        
                        gradeLevels.Add(gradeLevel);
                    }
                }
            }
            return gradeLevels;
        }
    }
}
