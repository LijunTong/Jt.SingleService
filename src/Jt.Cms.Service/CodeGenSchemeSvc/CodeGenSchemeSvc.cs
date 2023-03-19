using Jt.Cms.Data.Dto;
using Jt.Cms.Lib.Extensions;
using Jt.Cms.Core.Models;
using Jt.Cms.Data.Repositories.Dto;
using Jt.Cms.Data.Tables;
using Jt.Cms.Lib.Utils;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Service.CodeGenSchemeSvc;
using Microsoft.EntityFrameworkCore.Storage;
using Jt.Cms.Lib.DI;

namespace Jt.Cms.Service.UserSvc
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
                    string id = _snowflake.NextId().ToString();
                    List<CodeSchemeDetials> codeSchemeDetials = new List<CodeSchemeDetials>();
                    if (dto.CodeGenScheme.Id.IsNullOrWhiteSpace())
                    {
                        dto.CodeGenScheme.Id = id;
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
                            GenSchemeId = id,
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
                    await _schemeDetialsRepository.DeleteAsync(x => x.GenSchemeId == id);
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
