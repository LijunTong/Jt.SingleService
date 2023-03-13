using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.CodeTempSvc;
using MySqlConnector;
using System.Data.Common;

namespace Jt.SingleService.Service.UserSvc
{
    public class CodeTempSvc : BaseSvc<CodeTemp>, ICodeTempSvc, ITransientInterface
    {
        private readonly ICodeTempRepo _repository;

        public CodeTempSvc(ICodeTempRepo repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<CodeTemp>> GetListByUserIdAsync(string userId)
        {
            return await _repository.GetListAsync(x => x.UserId == userId);
        }

        public async Task<List<CodeTemp>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId)
        {
            return await _repository.GetListAsync(x => x.UserId == userId, pagerEntity);
        }


        public async Task<List<CodeTemp>> GetCodeTempsBySchemeAsync(string schemeId)
        {
            string sql = @"SELECT t.* FROM code_scheme_detials AS d 
                LEFT JOIN code_temp AS t
                ON d.temp_id = t.id
                WHERE gen_scheme_id = @gen_scheme_id";
            DbParameter[] dbParameter = new DbParameter[]
            {
                new MySqlParameter{ ParameterName = "@gen_scheme_id",Value = schemeId}
            };
            return await _repository.GetListAsync(sql, dbParameter);
        }
    }
}
