using Sample.EntityModels.Identity;
using Sample.EntityModels.Queues;
using Sample.IDomainServices.Core;
using Sample.ServiceResponse;
using Sample.ViewModels;
using Sample.ViewModels.Identity.WebApi;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.IDomainServices.IdentityStores
{
    public interface IRefreshTokenService : IBaseService<RefreshTokenEntityModel, RefreshTokenViewModel>
    {
        Task<bool> AddRefreshToken(RefreshTokenViewModel token);
        Task<bool> RemoveRefreshToken(string refreshTokenId);
        Task<bool> RemoveRefreshToken(RefreshTokenViewModel refreshToken);
        Task<RefreshTokenViewModel> FindRefreshToken(string refreshTokenId);
        List<RefreshTokenViewModel> GetAllRefreshTokens();
    }
}
