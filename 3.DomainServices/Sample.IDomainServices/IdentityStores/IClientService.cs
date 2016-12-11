using Sample.EntityModels.Identity;
using Sample.IDomainServices.Core;
using Sample.ViewModels.Identity.WebApi;

namespace Sample.IDomainServices.IdentityStores
{
    public interface IClientService : IBaseService<ClientEntityModel, ClientViewModel>
    {
        ClientViewModel FindClient(string clientId);
        
    }
}
