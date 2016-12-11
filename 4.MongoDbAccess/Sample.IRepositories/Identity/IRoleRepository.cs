using Sample.EntityModels.Identity;
using Sample.IRepositories.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.IRepositories.Identity
{
    public interface IRoleRepository : IBaseRepository<RoleEntityModel>
    {
        RoleEntityModel FindByName(string roleName);
        Task<RoleEntityModel> FindByNameAsync(string roleName);
        Task<RoleEntityModel> FindByNameAsync(CancellationToken cancellationToken, string roleName);
    }
}
