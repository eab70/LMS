using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.BLL
{
    public class LmsUserManager
    {
        private ILmsUserRepository _lmsUserRepository;

        public LmsUserManager(ILmsUserRepository lmsUserRepository)
        {
            _lmsUserRepository = lmsUserRepository;
        }

        public DataResponse<List<LmsUser>> GetUnassignedUsers()
        {
            var response = new DataResponse<List<LmsUser>>();

            try
            {
                response.Data = _lmsUserRepository.GetUnassignedUsers();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        //public DataResponse<UserDetailsToEdit> GetUnassignedUserDetails(int UserID)
        //{
        //    var response = new LmsUser();

        //    //try
        //    //{
        //        response = _lmsUserRepository.GetUnassignedUserDetails(UserID);
        //    //    response.Success = true;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    response.Message = "User doesn't exist";
        //    //}

        //    return response;
        //}

        public DataResponse<LmsUser> GetUnassignedUserDetails(int UserID) //original method
        {
            var response = new DataResponse<LmsUser>();

            try
            {
                response.Data = _lmsUserRepository.GetUnassignedUserDetails(UserID);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "User doesn't exist";
            }

            return response;
        }

        public DataResponse<LmsUser> UpdateUserDetails(LMSUserUpdateRequest user)
            //public DataResponse<LmsUser> UpdateUserDetails(LmsUser user)
        {
            var response = new DataResponse<LmsUser>();

            try
            {
                response.Data = _lmsUserRepository.UpdateUserDetails(user);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "User not updated";
            }

            return response;
        }

        public AdminUserSearch Search(AdminUserSearch user)
        {
            var response = new AdminUserSearch();

            try
            {
                response.AdminUserList = _lmsUserRepository.UserSearch(user);
            }
            catch (Exception ex)
            {
            }

            return response;
        }

        public LmsUser GetByAspNetId(string aspNetId)
        {
            return _lmsUserRepository.GetByAspNetId(aspNetId);
        }


        public Response Create(LmsUser user)   // Lis 6/28
        {
            var response = new Response();
            try
            {
                _lmsUserRepository.Create(user);
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



