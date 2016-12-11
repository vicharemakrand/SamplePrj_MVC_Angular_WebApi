using Sample.EntityModels.Identity;
using Sample.IRepositories.Core;
using System.Threading.Tasks;

namespace Sample.IRepositories.Identity
{
    public interface IRefreshTokenRepository : IBaseRepository<RefreshTokenEntityModel>
    {
        Task<RefreshTokenEntityModel> FindByTokenIdAsync(string tokenId);
    }
}
