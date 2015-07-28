using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;
using SWCLMS.Models;

namespace SWCLMS.Data.Mocks
{
    public class MockLmsRosterRepository : ILmsRosterRepository
    {
        public List<RosterStudent> GetRosterStudents(int TeacherID, int CourseID)
        {
            List<RosterStudent> roster = new List<RosterStudent>();

            return roster;
        }

        public void RemoveStudent(int RosterID)
        {
            
        }

        public List<RosterSearchResult> RosterUserSearch(RosterStudent studentSearch)
        {
            List <RosterSearchResult> roster = new List<RosterSearchResult>();

            return roster;
        }

        public void AddStudent(RosterStudent student)
        {
            
        }
    }
}
