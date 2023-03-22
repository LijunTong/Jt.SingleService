using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Data.Tables
{
    [Table("role_action")]
    public class RoleAction : BaseEntity
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("role_id")]
        public string RoleId { get; set; }
        [Column("controller")]
        public string Controller { get; set; }
        [Column("action")]
        public string Action { get; set; }
        [Column("creater")]
        public string Creater { get; set; }
        [Column("create_time")]
        public DateTime CreateTime { get; set; }
        [Column("updater")]
        public string Updater { get; set; }
        [Column("up_time")]
        public DateTime UpTime { get; set; }

        public Role Role { get; set; }
    }
}