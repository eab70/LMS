using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.Mocks
{
    public class MockLmsRoleRepository : ILmsRoleRepository
    {
        private List<Role> _dataSet { get; set; }

        public MockLmsRoleRepository()
        {
            _dataSet = new List<Role>(){
                new Role()
                {
                    RoleID = "abcd",
                    RoleName = "admin",
                },
                new Role()
                {
                    RoleID = "efgh",
                    RoleName = "teacher"
                },
                new Role()
                {
                     RoleID = "ijkl",
                     RoleName = "student",
                },
                new Role()
                {
                    RoleID = "mnop",
                    RoleName = "parent"
                }
            };
        }

        private List<LMSUserUpdateRequest> _dataSet2 { get; set; }

        
        public List<Role> RoleGetAll()
        {
            List<Role> role = new List<Role>();

            return _dataSet;
            
        }

        public List<LMSUserUpdateRequest> UserGetAllRoles(int UserID)
        {
            List<LMSUserUpdateRequest> role = new List<LMSUserUpdateRequest>();
            _dataSet2 = new List<LMSUserUpdateRequest>(){
                new LMSUserUpdateRequest()
                {
                    UserID = 1,
                    ID = "1234",
                    FirstName = "Evil",
                    LastName = "K",
                    GradeLevelID = 1,
                    UserId = "ffff",
                    RoleID = "abcd",
                    RoleName = "admin",
                },
               
            };

            return _dataSet2;
        }

        public void RemoveRoles(string aspNetUserId)
        {
            
        }

        public void AddRole(string aspNetUserId, string roleName)
        {
            
        }
    }
}
