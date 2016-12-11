using Sample.EntityModels.Queues;
using Sample.IRepositories.Queues;
using Sample.Repositories.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;

namespace Sample.Repositories.Queues
{
    public class RequestQueueRepository : BaseRepository<RequestQueueEntityModel>, IRequestQueueRepository
    {

        public IEnumerable<RequestQueueEntityModel> GetPendingRequestQueue()
        {
            var entityList = DbSet.AsQueryable().Where(o => o.IsRequestSucceed == false);
            return entityList;
        }
    }
 
}
