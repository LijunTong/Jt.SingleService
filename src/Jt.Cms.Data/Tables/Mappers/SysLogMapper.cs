using Jt.Cms.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data.Tables.Mappers
{
    public class SysLogMapper : IEntityTypeConfiguration<SysLog>
    {
        public void Configure(EntityTypeBuilder<SysLog> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}