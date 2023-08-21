using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Data
{
    [Table("user")]
    public class User : BaseEntity
    {
        [Column("user_name")]
        public string UserName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("register_time")]
        public DateTime RegisterTime { get; set; }

        [Column("login_time")]
        public DateTime LoginTime { get; set; }

        [Column("status")]
        public Int32 Status { get; set; }

        [Column("avatar")]
        public string Avatar { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}