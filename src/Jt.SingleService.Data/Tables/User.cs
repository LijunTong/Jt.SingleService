using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Data.Tables
{
    [Table("user")]
    public class User : BaseEntity
    {
        [Column("id")]
        public string Id { get; set; }
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
        [Column("creater")]
        public string Creater { get; set; }
        [Column("create_time")]
        public DateTime CreateTime { get; set; }
        [Column("updater")]
        public string Updater { get; set; }
        [Column("up_time")]
        public DateTime UpTime { get; set; }

        [Column("avatar")]
        public string Avatar { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}