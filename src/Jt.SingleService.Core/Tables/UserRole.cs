using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Core.Tables
{
    [Table("user_role")]
    public class UserRole : BaseEntity
    {
        [Column("id")]
        public string Id { get; set; }

        [Column("role_id")]
        public string RoleId { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("creater")]
        public string Creater { get; set; }

        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        [Column("updater")]
        public string Updater { get; set; }

        [Column("up_time")]
        public DateTime UpTime { get; set; }
    }
}