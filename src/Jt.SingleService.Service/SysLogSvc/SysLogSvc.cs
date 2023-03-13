using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Dto;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.SysLogSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class SysLogSvc : BaseSvc<SysLog>, ISysLogSvc, ITransientInterface
    {
        private readonly ISysLogRepo _repository;

        public SysLogSvc(ISysLogRepo repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<ActionStatsDto>> GetActionStatsAsync()
        {
            return await _repository.GetActionStatsAsync();
        }

        public async Task<List<KeyValueDto<long>>> GetIpStatsAsync()
        {
            return await _repository.GetIpStatsAsync();
        }

        public async Task<List<ActionStatsDto>> GetTodayActionStatsAsync(DateTime dateTime)
        {
            return await _repository.GetTodayActionStatsAsync(dateTime);
        }

        public async Task<List<KeyValueDto<long>>> GetTodayIpStatsAsync(DateTime dateTime)
        {
            return await _repository.GetTodayIpStatsAsync(dateTime);
        }

        public async Task<long> GetTodayTotalStatsAsync(DateTime dateTime)
        {
            return await _repository.GetTodayTotalStatsAsync(dateTime);
        }

        public async Task<long> GetTotalStatsAsync()
        {
            return await _repository.GetTotalStatsAsync();
        }
    }
}
