using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data
{
    public class ControllerMapper : IEntityTypeConfiguration<Controller>
    {
        public void Configure(EntityTypeBuilder<Controller> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}