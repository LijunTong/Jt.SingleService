using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data.Tables
{
   [Table("code_gen_scheme")]
    public class CodeGenScheme : BaseEntity
    {
        	[Column("id")]
        	public string Id { get; set; }
        	[Column("name")]
        	public string Name { get; set; }
        	[Column("des")]
        	public string Des { get; set; }
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