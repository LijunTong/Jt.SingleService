using Jt.SingleService.Core.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Core.Tables.Mappers
{
    public class MenuMapper : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}