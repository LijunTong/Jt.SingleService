using Jt.Cms.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data.Tables.Mappers
{
    public class ActionMapper : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}