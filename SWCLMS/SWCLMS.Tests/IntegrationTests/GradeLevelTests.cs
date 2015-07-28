using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SWCLMS.Data.SQL;

namespace SWCLMS.Tests.IntegrationTests
{
    [TestFixture]
    public class GradeLevelTests
    {
        [Test]
        public void CanLoadGradeLevels()
        {
            SqlLMSGradeLevelRepository repo = new SqlLMSGradeLevelRepository();
            var gradeLevels = repo.GradeLevelGetAll();
            
            Assert.AreNotEqual(0, gradeLevels.Count);
        }
    }
}
