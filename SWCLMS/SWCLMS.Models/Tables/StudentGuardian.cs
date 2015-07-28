using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models.Tables
{
    public class StudentGuardian
    {
        public int GuardianID { get; set; }
        public int StudentID { get; set; }
    }
}
