using System.ComponentModel.Composition;
using Sample.Common.MEF;
using Sample.Repositories.Core;
using Sample.IRepositories.Core;
using Sample.Repositories.Identity;
using Sample.IRepositories.Identity;
using Sample.Repositories.Queues;
using Sample.IRepositories.Queues;
using MongoDB.Driver;
using System.Configuration;
using Sample.EntityModels.Identity;

namespace Sample.Repositories
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType<IEmailQueueRepository, EmailQueueRepository>();
            registrar.RegisterType<IPdfQueueRepository, PdfQueueRepository>();
            registrar.RegisterType<IRequestQueueRepository, RequestQueueRepository>();
            registrar.RegisterType<IUnitOfWork, UnitOfWork>();
            registrar.RegisterType<IUserRepository, UserRepository>();
            registrar.RegisterType<IRoleRepository, RoleRepository>();
            registrar.RegisterType<IExternalLoginRepository, ExternalLoginRepository>();
            registrar.RegisterType<IRefreshTokenRepository, RefreshTokenRepository>();
            registrar.RegisterType<IClientRepository, ClientRepository>();
            registrar.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            registrar.RegisterType<IMongoClient, MongoClient>(ConfigurationManager.ConnectionStrings["MongoDbConnection"].ConnectionString);
            registrar.RegisterInstanceSingleton(typeof(IMongoDatabase),DataSeeder.GetDataBase());
            
        }
    }
}
