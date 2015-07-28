using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SWCLMS.BLL;
using SWCLMS.Data.Mocks;
using SWCLMS.Data.SQL;

namespace SWCLMS.Tests
{
    [TestFixture]
    class SqlLmsRoleRepositoryTest
    {
        [Test]
        public void RolesShouldReturnFour()
        {
            MockLmsRoleRepository repo = new MockLmsRoleRepository();
            //LMSRoleManager roleManager = new LmsRoleManager(repo);
            var count = repo.RoleGetAll().Count;  //if Database changed then this UserID may be impacted

            Assert.IsTrue(count > 0);
                
        }

        [Test]
        public void OnePersonOneRole()
        {
            MockLmsRoleRepository repo = new MockLmsRoleRepository();
            //LMSRoleManager roleManager = new LmsRoleManager(repo);
            var count = repo.UserGetAllRoles(1).Count;  
            Assert.IsTrue(count == 1);

        }
    }
}
