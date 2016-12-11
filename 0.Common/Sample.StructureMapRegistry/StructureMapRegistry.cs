using Sample.DomainServices;
using Sample.DomainServices.IdentityStores;
using Sample.IDomainServices.Queues;
using Sample.IRepositories.Core;
using Sample.IRepositories.Identity;
using Sample.IRepositories.Queues;
using Sample.Repositories.Core;
using Sample.Repositories.Identity;
using Sample.Repositories.Queues;
using Sample.ViewModels.Identity.WebApi;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using StructureMap;
using System;

namespace Sample.IOCRegistry
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            For<IUnitOfWork>().Use<UnitOfWork>();

            For<IEmailQueueService>().Use<EmailQueueService>();
            For<IUserStore<IdentityUserViewModel, ObjectId>>().Use<CustomUserStore>();
            For<IRoleStore<IdentityRoleViewModel, ObjectId>>().Use<CustomRoleStore>(); 
            For<IPdfQueueService>().Use<PdfQueueService>();
            For<IRequestQueueService>().Use<RequestQueueService>();

            For<IEmailQueueRepository>().Use<EmailQueueRepository>();
            For<IUserRepository>().Use<UserRepository>();
            For<IRoleRepository>().Use<RoleRepository>();
            For<IExternalLoginRepository>().Use<ExternalLoginRepository>();

            For<IPdfQueueRepository>().Use<PdfQueueRepository>();
            For<IRequestQueueRepository>().Use<RequestQueueRepository>();

        }

    }
}
