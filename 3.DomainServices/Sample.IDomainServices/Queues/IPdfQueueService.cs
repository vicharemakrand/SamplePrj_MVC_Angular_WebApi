using Sample.EntityModels.Queues;
using Sample.IDomainServices.Core;
using Sample.ViewModels;
using System.Collections.Generic;

namespace Sample.IDomainServices.Queues
{
    public interface IPdfQueueService : IBaseService<PdfQueueEntityModel, PdfQueueViewModel>
    {
        List<PdfQueueViewModel> GetPendingPdfQueue();
        bool ProcessPendingPdfs();
        //List<PdfResultViewModel> GetRequestsForEmailQueue();
    }
}
