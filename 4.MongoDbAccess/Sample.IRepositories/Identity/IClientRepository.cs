using Sample.EntityModels.Identity;
using Sample.IRepositories.Core;

namespace Sample.IRepositories.Identity
{
    public interface IClientRepository : IBaseRepository<ClientEntityModel>
    {
        ClientEntityModel FindByClientId(string clientId);

    }
}
