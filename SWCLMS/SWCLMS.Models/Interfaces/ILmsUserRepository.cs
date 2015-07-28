using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Interfaces
{
    public interface ILmsUserRepository
    {
        List<LmsUser> GetUnassignedUsers();
        LmsUser GetUnassignedUserDetails(int UserID);
        LmsUser UpdateUserDetails(LMSUserUpdateRequest user); //Void
        List<LmsUser> UserSearch(AdminUserSearch searchName);
        LmsUser GetByAspNetId(string aspNetId);
        void Create(LmsUser user);  //added 6/28 by Lis
    }
}
