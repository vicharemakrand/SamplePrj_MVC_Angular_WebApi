using Sample.EntityModels.Queues;
using Sample.IRepositories.Core;
using System.Collections.Generic;

namespace Sample.IRepositories.Queues
{
    public interface IRequestQueueRepository : IBaseRepository<RequestQueueEntityModel>
    {
        IEnumerable<RequestQueueEntityModel> GetPendingRequestQueue();
    }
}
