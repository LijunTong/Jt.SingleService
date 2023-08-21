using Jt.SingleService.Core;
using Jt.SingleService.Data;
using Jt.Common.Tool.DI;

namespace Jt.SingleService.Service
{
    public class SysLogSvc : BaseSvc<SysLog>, ISysLogSvc, ITransientDIInterface
    {
        private readonly ISysLogRepo _repository;

        public SysLogSvc(ISysLogRepo repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<List<ActionStatsDto>>> GetActionStatsAsync()
        {
            var data = await _repository.GetActionStatsAsync();
            return ApiResponse<List<ActionStatsDto>>.Succeed(data);
        }

        public async Task<ApiResponse<List<KeyValueDto<long>>>> GetIpStatsAsync()
        {
            var data = await _repository.GetIpStatsAsync();
            return ApiResponse<List<KeyValueDto<long>>>.Succeed(data);
        }

        public async Task<ApiResponse<PagerOutput<SysLog>>> GetLogsPagerListAsync(GetLogPagerReq req)
        {
            var data = await base.GetPagerListAsync(x => x.Type == req.Type, req);
            return data;
        }

        public async Task<ApiResponse<List<ActionStatsDto>>> GetTodayActionStatsAsync(DateTime dateTime)
        {
            var data = await _repository.GetTodayActionStatsAsync(dateTime);
            return ApiResponse<List<ActionStatsDto>>.Succeed(data);
        }

        public async Task<ApiResponse<List<KeyValueDto<long>>>> GetTodayIpStatsAsync(DateTime dateTime)
        {
            var data = await _repository.GetTodayIpStatsAsync(dateTime);
            return ApiResponse<List<KeyValueDto<long>>>.Succeed(data);
        }

        public async Task<ApiResponse<long>> GetTodayTotalStatsAsync(DateTime dateTime)
        {
            var data = await _repository.GetTodayTotalStatsAsync(dateTime);
            return ApiResponse<long>.Succeed(data);
        }

        public async Task<ApiResponse<long>> GetTotalStatsAsync()
        {
            var data = await _repository.GetTotalStatsAsync();
            return ApiResponse<long>.Succeed(data);
        }
    }
}
