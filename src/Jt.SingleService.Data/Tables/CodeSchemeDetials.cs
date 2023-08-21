using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Data
{
    [Table("code_scheme_detials")]
    public class CodeSchemeDetials : BaseEntity
    {
        [Column("file_name")]
        public string FileName { get; set; }

        [Column("temp_id")]
        public string TempId { get; set; }

        [Column("gen_scheme_id")]
        public string GenSchemeId { get; set; }

        public CodeTemp CodeTemp { get; set; }

        public CodeGenScheme CodeGenScheme { get; set; }
    }
}