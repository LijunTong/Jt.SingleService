using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data
{
    public class ArticleCommentMapper : IEntityTypeConfiguration<ArticleComment>
    {
        public void Configure(EntityTypeBuilder<ArticleComment> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Article)
                 .WithMany(x => x.ArticleComments)
                 .HasForeignKey(x => x.ArticleId);

            builder.HasOne(m => m.User)
                 .WithMany(x => x.ArticleComments)
                 .HasForeignKey(x => x.UserId);
        }
    }
}