using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Data.Tables
{
   [Table("code_db")]
    public class CodeDb : BaseEntity
    {
        	[Column("id")]
        	public string Id { get; set; }
        	[Column("name")]
        	public string Name { get; set; }
        	[Column("type")]
        	public string Type { get; set; }
        	[Column("con_str")]
        	public string ConStr { get; set; }
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