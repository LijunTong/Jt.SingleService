using Jt.SingleService.Core.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Core.Tables.Mappers
{
    public class SysLogMapper : IEntityTypeConfiguration<SysLog>
    {
        public void Configure(EntityTypeBuilder<SysLog> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}