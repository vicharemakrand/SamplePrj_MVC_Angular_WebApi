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
    public class RefreshTokenRepository : BaseRepository<RefreshTokenEntityModel>, IRefreshTokenRepository
    {
        public Task<RefreshTokenEntityModel> FindByTokenIdAsync(string tokenId)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.TokenId == tokenId);
        }
    }
}
