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
        /// ��˿
        /// </summary>
        public User Follow { get; set; }

        /// <summary>
        /// �û�
        /// </summary>
        public User User { get; set; }
    }
}