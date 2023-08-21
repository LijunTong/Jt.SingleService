using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Data
{
    [Table("code_temp")]
    public class CodeTemp : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("temp_content")]
        public string TempContent { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        public List<CodeSchemeDetials> CodeSchemeDetials { get; set; }
    }
}