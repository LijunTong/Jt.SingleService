using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("code_gen_scheme")]
    public class CodeGenScheme : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("des")]
        public string Des { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        public List<CodeSchemeDetials> CodeSchemeDetials { get; set; }
    }
}