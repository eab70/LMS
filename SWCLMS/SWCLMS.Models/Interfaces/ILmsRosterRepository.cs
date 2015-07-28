using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Tables;
using SWCLMS.Models;

namespace SWCLMS.Models.Interfaces
{
    public interface ILmsRosterRepository
    {
        List<RosterStudent> GetRosterStudents(int teacherID, int courseID);
        void RemoveStudent(int RosterID);
        List<RosterSearchResult> RosterUserSearch(RosterStudent studentSearch);
        void AddStudent(RosterStudent student);
    }
}
