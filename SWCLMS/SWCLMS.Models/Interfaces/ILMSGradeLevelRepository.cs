using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Interfaces  //added 6/16 after Nikki left
{
    public interface ILMSGradeLevelRepository
    {
        List<GradeLevel> GradeLevelGetAll();
    }
}
