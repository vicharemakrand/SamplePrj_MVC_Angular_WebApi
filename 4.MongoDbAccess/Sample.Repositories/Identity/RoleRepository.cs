using Sample.EntityModels.Identity;
using Sample.IRepositories.Identity;
using Sample.Repositories.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;

namespace Sample.Repositories.Identity
{
    public class RoleRepository : BaseRepository<RoleEntityModel>, IRoleRepository
    {

        public RoleEntityModel FindByName(string roleName)
        {
            return DbSet.AsQueryable().Where(x => x.Name == roleName).FirstOrDefault();
        }

        public Task<RoleEntityModel> FindByNameAsync(string roleName)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.Name == roleName);
        }

        public Task<RoleEntityModel> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        }
    }
}
