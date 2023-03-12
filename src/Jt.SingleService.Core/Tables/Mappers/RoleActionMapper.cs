using Jt.SingleService.Core.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Core.Tables.Mappers
{
    public class RoleActionMapper : IEntityTypeConfiguration<RoleAction>
    {
        public void Configure(EntityTypeBuilder<RoleAction> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}