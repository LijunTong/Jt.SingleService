using Jt.Cms.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.Cms.Data.Dto
{
    public class GetUserInfoOutput
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Avatar { get; set; }

        public DateTime RegisterTime { get; set; }

        public DateTime LoginTime { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
