using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Dto;
using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Repositories.Dto;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Core.Utils;
using Jt.SingleService.Service.CodeGenSchemeSvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace Jt.SingleService.Service.UserSvc
{
    public class CodeGenSchemeSvc : BaseSvc<CodeGenScheme>, ICodeGenSchemeSvc, ITransientInterface
    {
        private readonly ICodeGenSchemeRepo _repository;
        private readonly ICodeSchemeDetialsRepo _schemeDetialsRepository;
        private readonly CHelperSnowflake _snowflake;

        public CodeGenSchemeSvc(ICodeGenSchemeRepo repository, ICodeSchemeDetialsRepo schemeDetialsRepository,
            CHelperSnowflake snowflake) : base(repository)
        {
            _repository = repository;
            _schemeDetialsRepository = schemeDetialsRepository;
            _snowflake = snowflake;
        }

        public async Task<List<CodeGenScheme>> GetListByUserIdAsync(string userId)
        {
            return await _repository.GetListAsync(x => x.UserId == userId);
        }

        public async Task<List<CodeGenScheme>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId)
        {
            return await _repository.GetListAsync(x => x.UserId == userId, pagerEntity);

        }

        public async Task<List<CodeSchemeDetialsDto>> GetSchemeDetialsAsync(string schemeId)
        {
            return await _schemeDetialsRepository.GetSchemeDetialsAsync(schemeId);
        }

        public async Task InsertSchemeAsync(CodeGenScheme entity, List<CodeTempDto> temps)
        {
            using (var tran = await _repository.BeginTransactionAsync())
            {
                try
                {
                    List<CodeSchemeDetials> codeSchemeDetials = new List<CodeSchemeDetials>();
                    if (entity.Id == _snowflake.NextId().ToString())
                    {
                        await _repository.InsertAsync(entity);
                    }
                    else
                    {
                       await  _repository.UpdateAsync(entity);
                    }
                    await _repository.SaveAsync();
                    foreach (var temp in temps)
                    {
                        CodeSchemeDetials detials = new CodeSchemeDetials
                        {
                            GenSchemeId = entity.Id,
                            TempId = temp.Id,
                            FileName = temp.FileName,
                            CreateTime = DateTime.Now,
                            Creater = "",
                            Updater = "",
                            UpTime = DateTime.Now,
                        };
                        codeSchemeDetials.Add(detials);
                    }
                    await _schemeDetialsRepository.UseTransactionAsync(tran.GetDbTransaction());
                    await _schemeDetialsRepository.DeleteAsync(x => x.GenSchemeId == entity.Id);
                    await _schemeDetialsRepository.InsertListAsync(codeSchemeDetials);
                    await _schemeDetialsRepository.SaveAsync();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
    }
}
