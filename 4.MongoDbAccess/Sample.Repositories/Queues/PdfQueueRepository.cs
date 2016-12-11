using Sample.EntityModels.Queues;
using Sample.IRepositories.Queues;
using Sample.Repositories.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;

namespace Sample.Repositories.Queues
{
    public class PdfQueueRepository : BaseRepository<PdfQueueEntityModel>, IPdfQueueRepository
    {

        public IEnumerable<PdfQueueEntityModel> GetPendingPdfQueue()
        {
            var entityList = DbSet.AsQueryable().Where(o => o.IsPdfGenerationSucceed == false);
            return entityList;
        }
    }
 
}
