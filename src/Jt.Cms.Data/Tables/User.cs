using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("user")]
    public class User : BaseEntity
    {
        [Column("user_name")]
        public string UserName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("register_time")]
        public DateTime RegisterTime { get; set; }

        [Column("login_time")]
        public DateTime LoginTime { get; set; }

        [Column("status")]
        public Int32 Status { get; set; }

        [Column("avatar")]
        public string Avatar { get; set; }

        public List<UserRole> UserRoles { get; set; }

        /// <summary>
        /// ·ÛË¿
        /// </summary>
        public List<UserFollow> UserFollows { get; set; }

        /// <summary>
        /// ¹Ø×¢
        /// </summary>
        public List<UserFollow> FollowUsers { get; set; }

        public List<ArticleCollect> ArticleCollects { get; set; }

        public List<ArticleComment> ArticleComments { get; set; }

        public List<ArticleLike> ArticleLikes { get; set; }

        public List<ArticleRead> ArticleReads { get; set; }

        public List<CommentLike> CommentLikes { get; set; }
    }
}