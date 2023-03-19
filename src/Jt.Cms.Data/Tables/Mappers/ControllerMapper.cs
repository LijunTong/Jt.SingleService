using Jt.Cms.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data.Tables.Mappers
{
    public class ControllerMapper : IEntityTypeConfiguration<Controller>
    {
        public void Configure(EntityTypeBuilder<Controller> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}