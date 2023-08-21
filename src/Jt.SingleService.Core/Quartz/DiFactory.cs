using Jt.Common.Tool.DI;
using Quartz;
using Quartz.Spi;

namespace Jt.SingleService.Core
{
    public class DiFactory : IJobFactory, ITransientDIInterface
    {
        private readonly IServiceProvider _serviceProvider;

        public DiFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _serviceProvider.GetService(bundle.JobDetail.JobType) as IJob;
        }

        public void ReturnJob(IJob job) { }
    }
}
