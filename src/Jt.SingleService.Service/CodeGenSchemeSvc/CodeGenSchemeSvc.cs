using Jt.SingleService.Data.Dto;
using Jt.SingleService.Lib.Extensions;
using Jt.SingleService.Core.Models;
using Jt.SingleService.Data.Repositories.Dto;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Lib.Utils;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Service.CodeGenSchemeSvc;
using Microsoft.EntityFrameworkCore.Storage;
using Jt.SingleService.Lib.DI;

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

        public async Task InsertSchemeAsync(CodeGenSchemeDto dto)
        {
            using (var tran = await _repository.BeginTransactionAsync())
            {
                try
                {
                    List<CodeSchemeDetials> codeSchemeDetials = new List<CodeSchemeDetials>();
                    if (dto.CodeGenScheme.Id.IsNullOrWhiteSpace())
                    {
                        dto.CodeGenScheme.Id = _snowflake.NextId().ToString();
                        dto.CodeGenScheme.Creater = dto.UserId;
                        dto.CodeGenScheme.CreateTime = DateTime.Now;
                        dto.CodeGenScheme.Updater = dto.UserId;
                        dto.CodeGenScheme.UpTime = DateTime.Now;
                        await _repository.InsertAsync(dto.CodeGenScheme);
                    }
                    else
                    {
                        var entity = await GetEntityByIdAsync(dto.CodeGenScheme.Id);
                        entity.Updater = dto.UserId;
                        entity.UpTime = DateTime.Now;
                        entity.Name = dto.CodeGenScheme.Name;
                        entity.Des = dto.CodeGenScheme.Des;
                        await  _repository.UpdateAsync(entity);
                    }
                    await _repository.SaveAsync();
                    foreach (var temp in dto.Temps)
                    {
                        CodeSchemeDetials detials = new CodeSchemeDetials
                        {
                            Id = _snowflake.NextId().ToString(),
                            GenSchemeId = dto.CodeGenScheme.Id,
                            TempId = temp.Id,
                            FileName = temp.FileName,
                            CreateTime = DateTime.Now,
                            Creater = dto.UserId,
                            Updater = dto.UserId,
                            UpTime = DateTime.Now,
                        };
                        codeSchemeDetials.Add(detials);
                    }
                    await _schemeDetialsRepository.UseTransactionAsync(tran.GetDbTransaction());
                    await _schemeDetialsRepository.DeleteAsync(x => x.GenSchemeId == dto.CodeGenScheme.Id);
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
