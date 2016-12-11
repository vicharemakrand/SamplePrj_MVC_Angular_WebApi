using Sample.EntityModels.Queues;
using Sample.IDomainServices.Core;
using Sample.ViewModels;
using System.Collections.Generic;

namespace Sample.IDomainServices.Queues
{
    public interface IRequestQueueService : IBaseService<RequestQueueEntityModel, RequestQueueViewModel>
    {
        List<RequestQueueViewModel> GetPendingRequestQueue();
        bool ProcessPendingRequests();
    }
}
