using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;
using System.Transactions;

namespace SWCLMS.BLL
{
    public class LMSRoleManager
        {
            private ILmsRoleRepository _lmsRoleRepository;

            public LMSRoleManager(ILmsRoleRepository lmsRoleRepository)
            {
                _lmsRoleRepository = lmsRoleRepository;
            }

            public void UpdateRoles(LMSUserUpdateRequest request)
            {
                using (var transactionScope = new System.Transactions.TransactionScope())
                {
                    _lmsRoleRepository.RemoveRoles(request.ID);                    

                    foreach (var role in request.RoleNames)
                    {
                        _lmsRoleRepository.AddRole(request.ID, role);
                    }

                    transactionScope.Complete();
                }
            }
        }
    }

