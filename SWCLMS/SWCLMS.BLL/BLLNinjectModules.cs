using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using SWCLMS.Data.Mocks;
using SWCLMS.Data.SQL;
using SWCLMS.Models.Interfaces;
using SWCLMS.Data;

namespace SWCLMS.BLL
{
    public class MockNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILmsUserRepository>().To<MockLmsUserRepository>();
            Bind<ILmsRoleRepository>().To<MockLmsRoleRepository>();
            Bind<ILmsStudentCourseRepository>().To<MockLmsStudentCourseRepository>();
            Bind<ILMSParentRepository>().To<MockLMSParentRepository>();
            Bind<ILmsRosterRepository>().To<MockLmsRosterRepository>();
        }
    }

    public class SqlNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILmsUserRepository>().To<SqlLmsUserRepository>();
            Bind<ILmsRoleRepository>().To<SqlLmsRoleRepository>();
            Bind<ILmsStudentCourseRepository>().To<SqlLmsStudentCourseRepository>();
            Bind<ILmsCourseRepository>().To<SqlLMSCourseRepository>();
            Bind<ILMSParentRepository>().To<SqlLMSParentRepository>();
            Bind<ILmsRosterRepository>().To<SqlLMSRosterRepository>();
            Bind<ILMSGradeLevelRepository>().To<SqlLMSGradeLevelRepository>();
            Bind<IlmsSubjectRepository>().To<SqlLmsSubjectRepository>();
        }
    }

    public class DependencyLoader
    {
        public static NinjectModule LoadModule()
        {
            if(Settings.GetMode() == "SQL")
                return new SqlNinjectModule();

            return new SqlNinjectModule();
        }
    }

}
