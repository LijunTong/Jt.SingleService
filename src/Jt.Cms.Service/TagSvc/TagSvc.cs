using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class TagSvc : BaseSvc<Tag>, ITagSvc, ITransientDIInterface
    {
        private readonly ITagRepo _repository;

        public TagSvc(ITagRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
