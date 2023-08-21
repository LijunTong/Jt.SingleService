using Jt.SingleService.Core;
using Jt.SingleService.Data;
using Jt.Common.Tool.DI;
using MySqlConnector;
using System.Data.Common;

namespace Jt.SingleService.Service
{
    public class CodeTempSvc : BaseSvc<CodeTemp>, ICodeTempSvc, ITransientDIInterface
    {
        private readonly ICodeTempRepo _repository;

        public CodeTempSvc(ICodeTempRepo repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<List<CodeTemp>>> GetListByUserIdAsync(string userId)
        {
            var data = await _repository.GetListAsync(x => x.UserId == userId && x.IsDel == 0);
            return ApiResponse<List<CodeTemp>>.Succeed(data);
        }

        public async Task<ApiResponse<PagerOutput<CodeTemp>>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId)
        {
            var data = await base.GetPagerListAsync(x => x.UserId == userId, pagerEntity);
            return data;
        }


        public async Task<ApiResponse<List<CodeTemp>>> GetCodeTempsBySchemeAsync(string schemeId)
        {
            string sql = @"SELECT t.* FROM code_scheme_detials AS d 
                LEFT JOIN code_temp AS t
                ON d.temp_id = t.id
                WHERE gen_scheme_id = @gen_scheme_id";
            DbParameter[] dbParameter = new DbParameter[]
            {
                new MySqlParameter{ ParameterName = "@gen_scheme_id",Value = schemeId}
            };
            var data = await _repository.GetListAsync(sql, dbParameter);
            return ApiResponse<List<CodeTemp>>.Succeed(data);
        }
    }
}
