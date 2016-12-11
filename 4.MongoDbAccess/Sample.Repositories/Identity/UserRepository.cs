using Sample.EntityModels.Identity;
using Sample.IRepositories.Identity;
using Sample.Repositories.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Repositories.Identity
{
    public class UserRepository : BaseRepository<UserEntityModel>, IUserRepository
    {

        public UserEntityModel FindByEmail(string email)
        {
            return DbSet.AsQueryable().Where(x => x.Email == email).FirstOrDefault();
        }

        public Task<UserEntityModel> FindByEmailAsync(string email)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<UserEntityModel> FindByEmailAsync(CancellationToken cancellationToken, string email)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }

        public UserEntityModel FindByUserName(string username)
        {
            return DbSet.AsQueryable().Where(x => x.UserName == username).FirstOrDefault();
        }

        public Task<UserEntityModel> FindByUserNameAsync(string username)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.UserName == username);
        }

        public Task<UserEntityModel> FindByUserNameAsync(CancellationToken cancellationToken, string username)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        }
    }
}
