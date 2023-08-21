using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("user_follow")]
    public class UserFollow : BaseEntity
    {

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("follow_id")]
        public string FollowId { get; set; }

        [Column("follow_time")]
        public DateTime FollowTime { get; set; }

        /// <summary>
        /// ∑€Àø
        /// </summary>
        public User Follow { get; set; }

        /// <summary>
        /// ”√ªß
        /// </summary>
        public User User { get; set; }
    }
}