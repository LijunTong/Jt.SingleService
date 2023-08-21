using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Common.Tool.DI;
using Jt.Common.Tool.Extension;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Jt.Cms.Service
{
    public class ArticleSvc : BaseSvc<Article>, IArticleSvc, ITransientDIInterface
    {
        private readonly IArticleRepo _repository;
        private readonly IIDSvc _snowflake;
        private readonly ILogger<ArticleSvc> _logger;
        private readonly ICacheSvc _cacheSvc;
        private readonly IArticleCollectRepo _articleCollectRepo;
        private readonly IArticleLikeRepo _articleLikeRepo;
        private readonly IArticleReadRepo _articleReadRepo;
        private readonly IArticleCommentRepo _articleCommentRepo;

        public ArticleSvc(IArticleRepo repository,
                          IIDSvc snowflake,
                          ILogger<ArticleSvc> logger,
                          ICacheSvc cacheSvc,
                          IArticleCollectRepo articleCollectRepo,
                          IArticleLikeRepo articleLikeRepo,
                          IArticleReadRepo articleReadRepo,
                          IArticleCommentRepo articleCommentRepo) : base(repository)
        {
            _repository = repository;
            _snowflake = snowflake;
            _logger = logger;
            _cacheSvc = cacheSvc;
            _articleCollectRepo = articleCollectRepo;
            _articleLikeRepo = articleLikeRepo;
            _articleReadRepo = articleReadRepo;
            _articleCommentRepo = articleCommentRepo;
        }

        public async Task<ApiResponse<bool>> AddArticleAsync(AddArticleReq req)
        {
            Article article = req.CopyValue<AddArticleReq, Article>();
            article.Id = _snowflake.NextId().ToString();
            article.PublishTime = DateTime.Now;
            article.Creater = req.UserId;
            article.CreateTime = DateTime.Now;
            article.Updater = req.UserId;
            article.UpTime = DateTime.Now;

            _ = await _repository.InsertAsync(article);
            var flag = await _repository.SaveAsync();
            return ReturnFlag(flag, "发表失败");
        }

        public async Task<ApiResponse<bool>> PublishArticleAsync(PublishArticleReq req)
        {
            var article = await _repository.GetByIdAsync(req.ArticleId);
            if (article == null)
            {
                return ApiResponse<bool>.OperationFail("文章不存在");
            }

            article.PublishTime = DateTime.Now;
            article.Status = 2;
            article.Updater = req.UserId;
            article.UpTime = DateTime.Now;

            await _repository.UpdateAsync(article);
            var flag = await _repository.SaveAsync();
            return ReturnFlag(flag, "发布失败");
        }

        public async Task<ApiResponse<bool>> UpdateArticleAsync(AddArticleReq req)
        {
            var article = await _repository.GetByIdAsync(req.ArticleId);
            if (article == null)
            {
                return ApiResponse<bool>.OperationFail("文章不存在");
            }

            article.Title = req.Title;
            article.Content = req.Content;
            article.IsTop = req.IsTop;
            article.PublicType = req.PublicType;
            article.Updater = req.UserId;
            article.UpTime = DateTime.Now;

            await _repository.UpdateAsync(article);
            return ReturnFlag(await _repository.SaveAsync(), "编辑失败");
        }

        public async Task<ApiResponse<bool>> DelArticleAsync(AddArticleReq req)
        {
            var article = await _repository.GetByIdAsync(req.ArticleId);
            if (article == null)
            {
                return ApiResponse<bool>.OperationFail("文章不存在");
            }

            article.IsDel = 1;
            article.Updater = req.UserId;
            article.UpTime = DateTime.Now;

            await _repository.UpdateAsync(article);
            return ReturnFlag(await _repository.SaveAsync(), "删除失败");
        }

        public async Task<ApiResponse<bool>> AddArticleCollectAsync(AddArticleCollectReq req)
        {
            try
            {
                var article = await _repository.GetByIdAsync(req.ArticleId);
                if (article == null)
                {
                    return ApiResponse<bool>.OperationFail("文章不存在");
                }
                bool flag = false;
                var exists = await _articleCollectRepo.GetFirstAsync(x => x.ArticleId == req.ArticleId && x.UserId == req.UserId);
                if (exists != null)
                {
                    if (exists.IsCollect == 0)
                    {
                        exists.IsCollect = 1;
                        Expression<Func<ArticleCollect, object>>[] expressions = {
                            x=>x.IsCollect,
                            x=>x.Updater,
                            x=>x.UpTime
                        };
                        await _articleCollectRepo.UpdateFieldsAsync(exists, expressions);
                        flag = (await _articleCollectRepo.SaveAsync()) == 1;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    ArticleCollect collect = new ArticleCollect()
                    {
                        Id = _snowflake.NextId().ToString(),
                        ArticleId = req.ArticleId,
                        UserId = req.UserId,
                        IsCollect = 1,
                        CollectTime = DateTime.Now,
                        CreateTime = DateTime.Now,
                        Creater = req.UserId,
                        Updater = req.UserId,
                        UpTime = DateTime.Now,
                    };
                    await _articleCollectRepo.InsertAsync(collect);
                    flag = (await _articleCollectRepo.SaveAsync()) == 1;
                }
                return ReturnFlag(flag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"AddArticleCollectAsync: ex:{ex.Message}");
                return ApiResponse<bool>.SystemError("收藏失败");
            }
        }

        public async Task<ApiResponse<bool>> DelArticleCollectAsync(AddArticleCollectReq req)
        {
            try
            {
                var article = await _repository.GetByIdAsync(req.ArticleId);
                if (article == null)
                {
                    return ApiResponse<bool>.OperationFail("文章不存在");
                }

                bool flag = false;
                var exists = await _articleCollectRepo.GetFirstAsync(x => x.ArticleId == req.ArticleId && x.UserId == req.UserId);
                if (exists != null)
                {
                    if (exists.IsCollect == 1)
                    {
                        exists.IsCollect = 0;
                        Expression<Func<ArticleCollect, object>>[] expressions = {
                            x=>x.IsCollect,
                            x=>x.Updater,
                            x=>x.UpTime
                        };
                        await _articleCollectRepo.UpdateFieldsAsync(exists, expressions);
                        flag = (await _articleCollectRepo.SaveAsync()) == 1;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = true;
                }
                return ReturnFlag(flag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"AddArticleCollectAsync: ex:{ex.Message}");
                return ApiResponse<bool>.SystemError("取消收藏失败");
            }
        }


        public async Task<ApiResponse<bool>> AddArticleLikeAsync(AddArticleCollectReq req)
        {
            try
            {
                var article = await _repository.GetByIdAsync(req.ArticleId);
                if (article == null)
                {
                    return ApiResponse<bool>.OperationFail("文章不存在");
                }

                bool flag = false;
                var exists = await _articleLikeRepo.GetFirstAsync(x => x.ArticleId == req.ArticleId && x.UserId == req.UserId);
                if (exists != null)
                {
                    if (exists.IsLike == 0)
                    {
                        exists.IsLike = 1;
                        Expression<Func<ArticleLike, object>>[] expressions = {
                            x=>x.IsLike,
                            x=>x.Updater,
                            x=>x.UpTime
                        };
                        await _articleLikeRepo.UpdateFieldsAsync(exists, expressions);
                        flag = (await _articleLikeRepo.SaveAsync()) == 1;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    ArticleLike like = new ArticleLike()
                    {
                        Id = _snowflake.NextId().ToString(),
                        ArticleId = req.ArticleId,
                        UserId = req.UserId,
                        IsLike = 1,
                        LikeTime = DateTime.Now,
                        CreateTime = DateTime.Now,
                        Creater = req.UserId,
                        Updater = req.UserId,
                        UpTime = DateTime.Now,
                    };
                    await _articleLikeRepo.InsertAsync(like);
                    flag = (await _articleLikeRepo.SaveAsync()) == 1;
                }
                return ReturnFlag(flag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"AddArticleLikeAsync: ex:{ex.Message}");
                return ApiResponse<bool>.SystemError("点赞失败");
            }
        }

        public async Task<ApiResponse<bool>> DelArticleLikeAsync(AddArticleCollectReq req)
        {
            try
            {
                var article = await _repository.GetByIdAsync(req.ArticleId);
                if (article == null)
                {
                    return ApiResponse<bool>.OperationFail("文章不存在");
                }

                bool flag = false;
                var exists = await _articleLikeRepo.GetFirstAsync(x => x.ArticleId == req.ArticleId && x.UserId == req.UserId);
                if (exists != null)
                {
                    if (exists.IsLike == 1)
                    {
                        exists.IsLike = 0;
                        Expression<Func<ArticleLike, object>>[] expressions = {
                            x=>x.IsLike,
                            x=>x.Updater,
                            x=>x.UpTime
                        };
                        await _articleLikeRepo.UpdateFieldsAsync(exists, expressions);
                        flag = (await _articleLikeRepo.SaveAsync()) == 1;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = true;
                }
                return ReturnFlag(flag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"DelArticleLikeAsync: ex:{ex.Message}");
                return ApiResponse<bool>.SystemError("取消点赞失败");
            }
        }

        public async Task<ApiResponse<bool>> AddArticleReadAsync(AddArticleCollectReq req)
        {
            try
            {
                var article = await _repository.GetByIdAsync(req.ArticleId);
                if (article == null)
                {
                    return ApiResponse<bool>.OperationFail("文章不存在");
                }

                ArticleRead read = new ArticleRead()
                {
                    Id = _snowflake.NextId().ToString(),
                    ArticleId = req.ArticleId,
                    UserId = req.UserId,
                    ReadTime = DateTime.Now,
                    CreateTime = DateTime.Now,
                    Creater = req.UserId,
                    Updater = req.UserId,
                    UpTime = DateTime.Now,
                };
                await _articleReadRepo.InsertAsync(read);
                var flag = (await _articleReadRepo.SaveAsync()) == 1;
                return ReturnFlag(flag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"AddArticleReadAsync: ex:{ex.Message}");
                return ApiResponse<bool>.SystemError("添加阅读记录失败");
            }
        }

        public async Task<ApiResponse<bool>> AddArticleCommentAsync(AddArticleCommentReq req)
        {
            try
            {
                var article = await _repository.GetByIdAsync(req.ArticleId);
                if (article == null)
                {
                    return ApiResponse<bool>.OperationFail("文章不存在");
                }
                bool flag = false;
                ArticleComment comment = new ArticleComment()
                {
                    Id = _snowflake.NextId().ToString(),
                    ArticleId = req.ArticleId,
                    UserId = req.UserId,
                    PublishTime = DateTime.Now,
                    Content = req.Content,
                    IsAuthor = req.AuthorId == req.UserId ? 1 : 0,
                    IsTop = 0,
                    Creater = req.UserId,
                    CreateTime = DateTime.Now,
                    Updater = req.UserId,
                    UpTime = DateTime.Now,
                };
                await _articleCommentRepo.InsertAsync(comment);
                flag = (await _articleCommentRepo.SaveAsync()) == 1;
                return ReturnFlag(flag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"AddArticleCommentAsync: ex:{ex.Message}");
                return ApiResponse<bool>.SystemError("评论失败");
            }
        }


        public Task<ApiResponse<bool>> DelArticleCommentAsync(AddArticleCommentReq req)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<PagerOutput<Article>>> GetArticleByColumnAsync(GetArticleByColumnReq req)
        {
            try
            {
                var list = await _repository.GetArticleByColumnAsync(req);
                PagerOutput<Article> pager = new PagerOutput<Article>()
                {
                    Data = list,
                    Total = req.Total
                };

                return ApiResponse<PagerOutput<Article>>.Succeed(pager);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetArticleByColumnAsync: ex:{ex.Message}");
                return ApiResponse<PagerOutput<Article>>.SystemError("根据栏目获取文章异常");
            }
        }
    }
}
