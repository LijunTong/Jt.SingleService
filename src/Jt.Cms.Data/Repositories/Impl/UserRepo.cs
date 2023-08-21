using Jt.Common.Tool.DI;
using Jt.Cms.Lib.Extensions;
using Jt.Common.Tool.Extension;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Jt.Cms.Data
{
    public class UserRepo : BaseRepo<User>, IUserRepo, ITransientDIInterface
    {
        public UserRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<User>> GetPagerListAsync(GetPagerListReq req)
        {
            Expression<Func<User, bool>> predicate = x => true;
            if (req.UserName.IsNotNullOrWhiteSpace())
            {
                predicate.And(x => x.UserName.Contains(req.UserName));
            }
            return await DbSet.Where(predicate)
                .Include(x => x.UserRoles.Where(x => x.IsDel == 0))
                   .ThenInclude(x => x.Role)
                .Include(x => x.UserFollows.Where(x => x.IsDel == 0))
                .ToListAsync();
        }

        public async Task<User> GetUserAsync(string id)
        {
            return await DbSet.Where(x => x.Id == id)
                 .Include(x => x.UserRoles.Where(x=>x.IsDel == 0))
                    .ThenInclude(x => x.Role)
                 .Include(x => x.UserFollows.Where(x => x.IsDel == 0))
                 .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await GetFirstAsync(x => x.UserName == userName);
        }
    }
}
