using Jt.SingleService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Service.UserSvc
{
    public class UserSvc : IUserSvc
    {
        private readonly IUserRepo _userRepo;

        public UserSvc(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
    }
}
