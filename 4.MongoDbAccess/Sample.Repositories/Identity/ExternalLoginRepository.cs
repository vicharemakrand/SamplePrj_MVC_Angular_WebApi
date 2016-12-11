using Sample.EntityModels.Identity;
using Sample.IRepositories.Identity;
using Sample.Repositories.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Repositories.Identity
{
    public class ExternalLoginRepository : BaseRepository<ExternalLoginEntityModel>, IExternalLoginRepository
    {

        public ExternalLoginEntityModel GetByProviderAndKey(string loginProvider, string providerKey)
        {
            return DbSet.AsQueryable().Where(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey).FirstOrDefault();
        }

        public Task<ExternalLoginEntityModel> GetByProviderAndKeyAsync(string loginProvider, string providerKey)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }

        public Task<ExternalLoginEntityModel> GetByProviderAndKeyAsync(CancellationToken cancellationToken, string loginProvider, string providerKey)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey, cancellationToken);
        }
    }
}
