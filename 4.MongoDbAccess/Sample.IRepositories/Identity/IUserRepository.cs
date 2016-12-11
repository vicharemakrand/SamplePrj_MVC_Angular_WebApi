using Sample.EntityModels.Identity;
using Sample.IRepositories.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.IRepositories.Identity
{
    public interface IUserRepository  : IBaseRepository<UserEntityModel>
    {
        UserEntityModel FindByUserName(string username);
        Task<UserEntityModel> FindByUserNameAsync(string username);
        Task<UserEntityModel> FindByUserNameAsync(CancellationToken cancellationToken, string username);

        UserEntityModel FindByEmail(string email);
        Task<UserEntityModel> FindByEmailAsync(string email);
        Task<UserEntityModel> FindByEmailAsync(CancellationToken cancellationToken, string email);
    }
}
