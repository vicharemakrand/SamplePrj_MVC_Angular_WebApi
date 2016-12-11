using Sample.EntityModels.Queues;
using Sample.IRepositories.Core;
using System.Collections.Generic;

namespace Sample.IRepositories.Queues
{
    public interface IEmailQueueRepository : IBaseRepository<EmailQueueEntityModel>
    {
        IEnumerable<EmailQueueEntityModel> GetPendingEmailQueue();
    }
}
