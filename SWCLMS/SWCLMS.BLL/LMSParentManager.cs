using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.BLL
{
    public class LMSParentManager
    {
        private ILMSParentRepository _lmsParentRepository;

        public LMSParentManager(ILMSParentRepository lmsParentRepository)
        {
            _lmsParentRepository = lmsParentRepository;
        }
        public DataResponse<List<LmsUser>> GetStudents(int UserID)
        {
            var response = new DataResponse<List<LmsUser>>();

            try
            {
                response.Data = _lmsParentRepository.GetStudents(UserID);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
