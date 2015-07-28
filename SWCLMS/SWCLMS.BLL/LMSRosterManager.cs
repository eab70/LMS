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
    public class LMSRosterManager
    {
        private ILmsRosterRepository _lmsRosterRepository;

        public LMSRosterManager(ILmsRosterRepository lmsRosterRepository)
        {
            _lmsRosterRepository = lmsRosterRepository;
        }

        public DataResponse<List<RosterStudent>> GetRosterStudents(int userID,int courseID)
        {
            var response = new DataResponse<List<RosterStudent>>();

            try
            {
                response.Data = _lmsRosterRepository.GetRosterStudents(userID,courseID);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public void RemoveStudent(int RosterID)
        {
            _lmsRosterRepository.RemoveStudent(RosterID);
        }

        public void AddStudent(RosterStudent student)
        {
            _lmsRosterRepository.AddStudent(student);
        }

        public DataResponse<List<RosterSearchResult>> RosterUserSearch(RosterStudent student)
        {
            var response = new DataResponse<List<RosterSearchResult>>();

            try
            {
                response.Data = _lmsRosterRepository.RosterUserSearch(student);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }      
    }
}
