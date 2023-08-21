using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("role")]
    public class Role : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("code")]
        public string Code { get; set; }
        [Column("des")]
        public string Des { get; set; }

        public List<RoleAction> RoleActions { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}