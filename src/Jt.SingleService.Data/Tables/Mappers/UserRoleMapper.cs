using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Data
{
    public class UserRoleMapper : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasOne(m => m.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(m => m.RoleId);

            builder.HasOne(m => m.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(m => m.UserId);
        }
    }
}