using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.Mocks
{
    public class MockLMSParentRepository : ILMSParentRepository
    {
        public List<LmsUser> GetStudents(int UserID)
        {
            List<LmsUser> students = new List<LmsUser>();

            return students;
        }
    }
}
