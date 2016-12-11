using Sample.EntityModels.Core;
using Sample.EntityModels.Identity;
using Sample.IRepositories.Core;
using Sample.IRepositories.Identity;
using Sample.IRepositories.Queues;
using MongoDB.Driver;
using StructureMap.Attributes;
using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Repositories.Core
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IMongoDatabase database;
        private IClientRepository clientRepository;
        private IExternalLoginRepository externalLoginRepository;
        private IRefreshTokenRepository refreshTokenRepository;
        private IRoleRepository roleRepository;
        private IUserRepository userRepository;

        private IEmailQueueRepository emailQueueRepository;
        private IPdfQueueRepository pdfQueueRepository;
        private IRequestQueueRepository requestQueueRepository;

        public UnitOfWork(IMongoDatabase database)
        {
            this.database = database;
        }

        [SetterProperty]
        public IClientRepository ClientRepository
        {
            get { return clientRepository; }
            set
            {
                clientRepository = value;
                clientRepository.Database = database;
            }
        }

        [SetterProperty]
        public IExternalLoginRepository ExternalLoginRepository
        {
            get { return externalLoginRepository; }
            set
            {
                externalLoginRepository = value;
                externalLoginRepository.Database = database;
            }
        }

        [SetterProperty]
        public IRefreshTokenRepository RefreshTokenRepository
        {
            get { return refreshTokenRepository; }
            set
            {
                refreshTokenRepository = value;
                refreshTokenRepository.Database = database;
            }
        }

        [SetterProperty]
        public IRoleRepository RoleRepository
        {
            get { return roleRepository; }
            set
            {
                roleRepository = value;
                roleRepository.Database = database;
            }
        }

        [SetterProperty]
        public IUserRepository UserRepository
        {
            get { return userRepository; }
            set
            {
                userRepository = value;
                userRepository.Database = database;
            }
        }

        [SetterProperty]
        public IEmailQueueRepository EmailQueueRepository
        {
            get { return emailQueueRepository; }
            set
            {
                emailQueueRepository = value;
                emailQueueRepository.Database = database;
            }
        }

        [SetterProperty]
        public IPdfQueueRepository PdfQueueRepository
        {
            get { return pdfQueueRepository; }
            set
            {
                pdfQueueRepository = value;
                pdfQueueRepository.Database = database;
            }
        }

        [SetterProperty]
        public IRequestQueueRepository RequestQueueRepository
        {
            get { return requestQueueRepository; }
            set
            {
                requestQueueRepository = value;
                requestQueueRepository.Database = database;
            }
        }

        public IBaseRepository<T> SetDbContext<T>(IBaseRepository<T> repository) where T : BaseEntityModel
        {
            requestQueueRepository.Database = database;
            return repository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
