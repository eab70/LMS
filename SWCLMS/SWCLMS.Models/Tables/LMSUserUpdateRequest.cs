using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models.Tables
{
    public class LMSUserUpdateRequest
    {
        public int UserID { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte? GradeLevelID { get; set; }
        public string UserId { get; set; }
        public string RoleID { get; set; }
        public string RoleName { get; set; }

        public List<string> RoleNames { get; set; }

        public LMSUserUpdateRequest()
        {
            RoleNames = new List<string>();
        }
    }
}
