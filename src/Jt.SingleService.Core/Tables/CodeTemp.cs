using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Core.Tables
{
   [Table("code_temp")]
    public class CodeTemp : BaseEntity
    {
        	[Column("id")]
        	public string Id { get; set; }
        	[Column("name")]
        	public string Name { get; set; }
        	[Column("temp_content")]
        	public string TempContent { get; set; }
        	[Column("user_id")]
        	public string UserId { get; set; }
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