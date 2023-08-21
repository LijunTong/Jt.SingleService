using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class ColumnSvc : BaseSvc<Column>, IColumnSvc, ITransientDIInterface
    {
        private readonly IColumnRepo _repository;

        public ColumnSvc(IColumnRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
