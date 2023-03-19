using Jt.Cms.Core.Models;
using Jt.Cms.Data.Tables;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Service.CodeDbSvc;
using Jt.Cms.Lib.DI;

namespace Jt.Cms.Service.UserSvc
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
