using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.BLL
{
    public class LMSGradeLevelManager  
    {
        private ILMSGradeLevelRepository _lmsGradeLevelRepository;

        public LMSGradeLevelManager(ILMSGradeLevelRepository lmsGradeLevelRepository)
        {
            _lmsGradeLevelRepository = lmsGradeLevelRepository;
        }

        public List<GradeLevel> GradeLevelGetAll()
        {
            List<GradeLevel> gradeLevels = new List<GradeLevel>();
            gradeLevels = _lmsGradeLevelRepository.GradeLevelGetAll();

            return gradeLevels;
        }
    }
}
