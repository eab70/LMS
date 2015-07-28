using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models
{
    //Nikki
    //The AdminUserList property will be the return of the search. The other properties will be the search
    //information sent to the database. 
    public class AdminUserSearch
    {
        public List<LmsUser> AdminUserList { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string SelectedRoleID { get; set; } //Added from Steve 06/23/2015

        public List<SelectListItem> Roles { get; set; }

        public void CreateRole(List<Role> roles)
        {
            Roles = new List<SelectListItem>();

            foreach (var r in roles)
            {
                Roles.Add(
                    new SelectListItem() { Text = r.RoleName, Value = r.RoleID });
            }
        }
    }
}
