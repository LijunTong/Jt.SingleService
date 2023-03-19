using Jt.Cms.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data.Tables.Mappers
{
    public class RoleActionMapper : IEntityTypeConfiguration<RoleAction>
    {
        public void Configure(EntityTypeBuilder<RoleAction> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}