using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data
{
    public class ArticleLikeMapper : IEntityTypeConfiguration<ArticleLike>
    {
        public void Configure(EntityTypeBuilder<ArticleLike> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Article)
                 .WithMany(x => x.ArticleLikes)
                 .HasForeignKey(x => x.ArticleId);

            builder.HasOne(m => m.User)
                 .WithMany(x => x.ArticleLikes)
                 .HasForeignKey(x => x.UserId);
        }
    }
}