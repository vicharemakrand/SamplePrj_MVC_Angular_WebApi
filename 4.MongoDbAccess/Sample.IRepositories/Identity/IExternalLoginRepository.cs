using Sample.EntityModels.Identity;
using Sample.IRepositories.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.IRepositories.Identity
{
    public interface IExternalLoginRepository : IBaseRepository<ExternalLoginEntityModel>
    {
        ExternalLoginEntityModel GetByProviderAndKey(string loginProvider, string providerKey);
        Task<ExternalLoginEntityModel> GetByProviderAndKeyAsync(string loginProvider, string providerKey);
        Task<ExternalLoginEntityModel> GetByProviderAndKeyAsync(CancellationToken cancellationToken, string loginProvider, string providerKey);
    }
}
