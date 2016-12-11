using Sample.EntityModels.Queues;
using Sample.IRepositories.Queues;
using Sample.Repositories.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;

namespace Sample.Repositories.Queues
{
    public class EmailQueueRepository : BaseRepository<EmailQueueEntityModel>, IEmailQueueRepository
    {

        public IEnumerable<EmailQueueEntityModel> GetPendingEmailQueue()
        {
            return DbSet.AsQueryable().Where(x => x.IsSucceedEmailSent == false);
        }
    }
 
}
