using Jt.SingleService.Core.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Core.Tables.Mappers
{
    public class UserRoleMapper : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}