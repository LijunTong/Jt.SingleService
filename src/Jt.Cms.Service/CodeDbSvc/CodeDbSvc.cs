using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class CodeDbSvc : BaseSvc<CodeDb>, ICodeDbSvc, ITransientDIInterface
    {
        private readonly ICodeDbRepo _repository;

        public CodeDbSvc(ICodeDbRepo repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<List<CodeDb>>> GetListByUserIdAsync(string userId)
        {
            var data = await _repository.GetListAsync(x => x.UserId == userId);
            return ApiResponse<List<CodeDb>>.Succeed(data);
        }

        public async Task<ApiResponse<PagerOutput<CodeDb>>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId)
        {
            var data = await base.GetPagerListAsync(x => x.UserId == userId, pagerEntity);
            return data;
        }
    }
}
