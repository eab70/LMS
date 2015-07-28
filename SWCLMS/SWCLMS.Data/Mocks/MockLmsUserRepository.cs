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

namespace SWCLMS.Data.Mocks
{
    public class MockLmsUserRepository : ILmsUserRepository
    {
        public List<LmsUser> GetUnassignedUsers()
        {
            return new List<LmsUser>()
            {
                new LmsUser()
                {
                    Email = "eric@swcguild.com",
                    FirstName = "Eric",
                    LastName = "Wise",
                    SuggestedRole = "Admin",
                    GradeLevelID = null,
                    ID = "1",
                    UserID = 1
                },
                new LmsUser()
                {
                    Email = "alincoln@swcguild.com",
                    FirstName = "Abraham",
                    LastName = "Lincoln",
                    SuggestedRole = "Teacher",
                    GradeLevelID = null,
                    ID = "2",
                    UserID = 2
                },
                new LmsUser()
                {
                    Email = "joe.schmoe@swcguild.com",
                    FirstName = "Joe",
                    LastName = "Schmoe",
                    SuggestedRole = "Student",
                    GradeLevelID = null,
                    ID = "3",
                    UserID = 3
                },
                new LmsUser()
                {
                    Email = "jane.schmoe@swcguild.com",
                    FirstName = "Jane",
                    LastName = "Schmoe",
                    SuggestedRole = "Parent",
                    GradeLevelID = null,
                    ID = "4",
                    UserID = 4
                }
            };
        }

        public LmsUser GetUnassignedUserDetails(int UserID)
        {
            LmsUser user = new LmsUser();
          
            return user;
        }

        public LmsUser UpdateUserDetails(LMSUserUpdateRequest user)
        {
            LmsUser user1 = new LmsUser();

            return user1;
        }

        public LmsUser UpdateUserDetails(LmsUser user)
        {
          LmsUser user1 = new LmsUser();

            return user1;
        }

        public List<LmsUser> UserSearch(AdminUserSearch searchName)
        {
            List<LmsUser> user2 = new List<LmsUser>();

            return user2;
        }

        public LmsUser GetByAspNetId(string aspNetId)
        {
            LmsUser user = new LmsUser();
            return user;
        }

        public void Create(LmsUser user)
        {
            LmsUser user3 = new LmsUser();
            
        }
    }
}
