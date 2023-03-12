using Jt.SingleService.Core.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Core.Tables.Mappers
{
    public class ControllerMapper : IEntityTypeConfiguration<Controller>
    {
        public void Configure(EntityTypeBuilder<Controller> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}