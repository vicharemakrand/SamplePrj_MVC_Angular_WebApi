using Sample.DomainServices.Core;
using Sample.EntityModels.Identity;
using Sample.IDomainServices.AutoMapper;
using Sample.ViewModels.Identity.WebApi;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Sample.IDomainServices.IdentityStores;

namespace Sample.DomainServices.IdentityStores
{
    public class ClientService : BaseService<ClientEntityModel, ClientViewModel> , IClientService
    {
        public async Task<RefreshTokenViewModel> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await UnitOfWork.RefreshTokenRepository.FindByTokenIdAsync(refreshTokenId);
            var tokenViewModel = refreshToken.ToViewModel<RefreshTokenEntityModel, RefreshTokenViewModel>();
            return tokenViewModel;
        }

        public ClientViewModel FindClient(string clientId)
        {
            var clientEntity = UnitOfWork.ClientRepository.FindByClientId(clientId);
            var clientViewModel = clientEntity.ToViewModel<ClientEntityModel, ClientViewModel>();

            return clientViewModel;
        }

    }
}
