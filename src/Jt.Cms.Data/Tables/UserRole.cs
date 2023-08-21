using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("user_role")]
    public class UserRole : BaseEntity
    {

        [Column("role_id")]
        public string RoleId { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }
    }
}