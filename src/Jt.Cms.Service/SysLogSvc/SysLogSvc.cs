using Jt.Cms.Data.Dto;
using Jt.Cms.Data.Tables;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Service.SysLogSvc;
using Jt.Cms.Lib.DI;

namespace Jt.Cms.Service.UserSvc
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
