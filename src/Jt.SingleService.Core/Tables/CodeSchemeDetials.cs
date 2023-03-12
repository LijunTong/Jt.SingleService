using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Core.Tables
{
   [Table("code_scheme_detials")]
    public class CodeSchemeDetials : BaseEntity
    {
        	[Column("id")]
        	public string Id { get; set; }
        	[Column("file_name")]
        	public string FileName { get; set; }
        	[Column("temp_id")]
        	public Int32 TempId { get; set; }
        	[Column("gen_scheme_id")]
        	public Int32 GenSchemeId { get; set; }
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