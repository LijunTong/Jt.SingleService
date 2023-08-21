using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data
{
    public class CommentLikeMapper : IEntityTypeConfiguration<CommentLike>
    {
        public void Configure(EntityTypeBuilder<CommentLike> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.ArticleComment)
                 .WithMany(x => x.CommentLikes)
                 .HasForeignKey(x => x.CommentId);

            builder.HasOne(m => m.User)
                 .WithMany(x => x.CommentLikes)
                 .HasForeignKey(x => x.UserId);
        }
    }
}