using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Interfaces
{
    public interface ILmsRoleRepository
    {
        List<Role> RoleGetAll();
        List<LMSUserUpdateRequest> UserGetAllRoles(int UserID);

        void RemoveRoles(string aspNetUserId);
        void AddRole(string aspNetUserId, string roleName);
    }
    
}

