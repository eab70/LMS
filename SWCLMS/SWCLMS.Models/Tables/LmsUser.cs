using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models.Tables
{
    public class LmsUser
    {
        public int UserID { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte? GradeLevelID { get; set; }
        public string SuggestedRole { get; set; }
    }

    

    
}
