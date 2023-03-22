using Jt.SingleService.Data.DbContexts;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Lib.DI;
using Jt.SingleService.Data.Dto.User.Req;
using Jt.SingleService.Lib.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Jt.SingleService.Data.Repositories.Impl
{
    public class UserRepo : BaseRepo<User>, IUserRepo, ITransientInterface
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
                .Include(x => x.UserRoles)
                   .ThenInclude(x => x.Role)
                .ToListAsync();
        }

        public async Task<User> GetUserAsync(string id)
        {
            return await DbSet.Where(x => x.Id == id)
                 .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                 .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await GetFirstAsync(x => x.UserName == userName);
        }
    }
}
