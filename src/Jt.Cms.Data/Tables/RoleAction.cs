using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("role_action")]
    public class RoleAction : BaseEntity
    {
        [Column("role_id")]
        public string RoleId { get; set; }

        [Column("controller")]
        public string Controller { get; set; }

        [Column("action")]
        public string Action { get; set; }

        public Role Role { get; set; }
    }
}