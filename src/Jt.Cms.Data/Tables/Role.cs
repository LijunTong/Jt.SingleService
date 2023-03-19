using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data.Tables
{
    [Table("role")]
    public class Role : BaseEntity
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("code")]
        public string Code { get; set; }
        [Column("des")]
        public string Des { get; set; }
        [Column("creater")]
        public string Creater { get; set; }
        [Column("create_time")]
        public DateTime CreateTime { get; set; }
        [Column("updater")]
        public string Updater { get; set; }
        [Column("up_time")]
        public DateTime UpTime { get; set; }
        [NotMapped]
        public List<RoleAction> RoleActions { get; set; }
    }
}