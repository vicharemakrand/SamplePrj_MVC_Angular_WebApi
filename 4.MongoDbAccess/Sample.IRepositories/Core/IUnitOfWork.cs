using Sample.EntityModels.Core;
using Sample.IRepositories.Identity;
using Sample.IRepositories.Queues;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.IRepositories.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IExternalLoginRepository ExternalLoginRepository { get; set; }
        IRoleRepository RoleRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IRefreshTokenRepository RefreshTokenRepository { get; set; }
        IClientRepository ClientRepository { get; set; }

        IEmailQueueRepository EmailQueueRepository { get; set; }

        IPdfQueueRepository PdfQueueRepository { get; set; }

        IRequestQueueRepository RequestQueueRepository { get; set; }

        IBaseRepository<T> SetDbContext<T>(IBaseRepository<T> repository) where T : BaseEntityModel;
    }
}
