using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Tables
{
    [Table("user")]
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }
    }
}
