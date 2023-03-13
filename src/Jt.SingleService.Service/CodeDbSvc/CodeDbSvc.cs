using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.CodeDbSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class CodeDbSvc : BaseSvc<CodeDb>, ICodeDbSvc, ITransientInterface
    {
        private readonly ICodeDbRepo _repository;

        public CodeDbSvc(ICodeDbRepo repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<CodeDb>> GetListByUserIdAsync(string userId)
        {
            return await _repository.GetListAsync(x => x.UserId == userId);

        }

        public async Task<List<CodeDb>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId)
        {
            return await _repository.GetListAsync(x => x.UserId == userId, pagerEntity);
        }
    }
}
