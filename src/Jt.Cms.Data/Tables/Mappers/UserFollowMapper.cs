using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data
{
    public class UserFollowMapper : IEntityTypeConfiguration<UserFollow>
    {
        public void Configure(EntityTypeBuilder<UserFollow> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasOne(m => m.User)
                .WithMany(u => u.FollowUsers)
                .HasForeignKey(m => m.UserId);

            builder.HasOne(m => m.Follow)
                .WithMany(u => u.UserFollows)
                .HasForeignKey(m => m.FollowId);
        }
    }
}