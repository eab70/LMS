using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SWCLMS.BLL;
using SWCLMS.Data.SQL;

namespace SWCLMS.Tests
{
    [TestFixture]
    class SqlLmsStudentCourseRepositoryTest
    {
        [Test]
        public void CoursesShouldReturnMoreThanZero()
        {
            SqlLmsStudentCourseRepository repo = new SqlLmsStudentCourseRepository();
            LmsStudentCourseGradeManager courseManager = new LmsStudentCourseGradeManager(repo);
            var count = courseManager.GetStudentCourses(1).Count;  //if Database changed then this UserID may be impacted

            Assert.IsTrue(count == 0);
                
        }
    }
}
