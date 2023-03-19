using Jt.SingleService.Core.Models;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Service.CodeDbSvc;
using Jt.SingleService.Lib.DI;

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
