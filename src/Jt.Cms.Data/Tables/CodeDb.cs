using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("code_db")]
    public class CodeDb : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("con_str")]
        public string ConStr { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }
    }
}