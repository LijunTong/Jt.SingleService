using Jt.SingleService.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Data.Tables.Mappers
{
    public class RoleActionMapper : IEntityTypeConfiguration<RoleAction>
    {
        public void Configure(EntityTypeBuilder<RoleAction> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Role)
                .WithMany(r => r.RoleActions)
                .HasForeignKey(m => m.RoleId);
        }
    }
    
}