using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Common.Tool.DI;
using Jt.Common.Tool.Extension;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Jt.Cms.Service
{
    public class CodeGenSchemeSvc : BaseSvc<CodeGenScheme>, ICodeGenSchemeSvc, ITransientDIInterface
    {
        private readonly ICodeGenSchemeRepo _repository;
        private readonly ICodeSchemeDetialsRepo _schemeDetialsRepository;
        private readonly IIDSvc _snowflake;
        private readonly ILogger<CodeGenSchemeSvc> _logger;

        public CodeGenSchemeSvc(ICodeGenSchemeRepo repository, ICodeSchemeDetialsRepo schemeDetialsRepository,
            IIDSvc snowflake, ILogger<CodeGenSchemeSvc> logger) : base(repository)
        {
            _repository = repository;
            _schemeDetialsRepository = schemeDetialsRepository;
            _snowflake = snowflake;
            _logger = logger;
        }

        public async Task<ApiResponse<CodeGenScheme>> GetCodeGenSchemeAsync(string schemeId)
        {
            var data = await _repository.GetCodeGenSchemeAsync(schemeId);
            return ApiResponse<CodeGenScheme>.Succeed(data);
        }

        public async Task<ApiResponse<List<CodeGenScheme>>> GetListByUserIdAsync(string userId)
        {
            var data = await _repository.GetListAsync(x => x.UserId == userId);
            return ApiResponse<List<CodeGenScheme>>.Succeed(data);
        }

        public async Task<ApiResponse<PagerOutput<CodeGenScheme>>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId)
        {
            var data =  await base.GetPagerListAsync(x => x.UserId == userId, pagerEntity);
            return data;
        }

        public async Task<ApiResponse<List<CodeSchemeDetials>>> GetSchemeDetialsAsync(string schemeId)
        {
            var data = await _schemeDetialsRepository.GetSchemeDetialsAsync(schemeId);
            return ApiResponse<List<CodeSchemeDetials>>.Succeed(data);
        }

        public async Task<ApiResponse<bool>> InsertSchemeAsync(CodeGenSchemeDto dto)
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
                        var entity = await _repository.GetByIdAsync(dto.CodeGenScheme.Id);
                        entity.Updater = dto.UserId;
                        entity.UpTime = DateTime.Now;
                        entity.Name = dto.CodeGenScheme.Name;
                        entity.Des = dto.CodeGenScheme.Des;
                        await _repository.UpdateAsync(entity);
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
                catch (Exception ex)
                {
                    tran.Rollback();
                    _logger.LogError(ex, "InsertSchemeAsync");
                    return ApiResponse<bool>.SystemError("ÐÂÔöÒì³£");
                }
            }

            return ApiResponse<bool>.Succeed(true);
        }
    }
}
