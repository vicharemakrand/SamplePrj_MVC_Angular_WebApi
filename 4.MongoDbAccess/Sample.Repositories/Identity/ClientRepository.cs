using Sample.EntityModels.Identity;
using Sample.IRepositories.Identity;
using Sample.Repositories.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Sample.Repositories.Identity
{
    public class ClientRepository : BaseRepository<ClientEntityModel>, IClientRepository
    {
        public ClientEntityModel FindByClientId(string clientId)
        {
            return DbSet.AsQueryable().Where(x => x.ClientId == clientId).FirstOrDefault();
        }
    }
}
