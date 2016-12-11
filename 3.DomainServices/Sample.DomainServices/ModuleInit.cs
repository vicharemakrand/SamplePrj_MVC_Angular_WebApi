using Sample.Common.MEF;
using Sample.DomainServices.IdentityStores;
using Sample.IDomainServices.IdentityStores;
using Sample.IDomainServices.Queues;
using Sample.ViewModels.Identity.WebApi;

using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using System;
using System.ComponentModel.Composition;

namespace Sample.DomainServices
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType<IEmailQueueService, EmailQueueService>();
            registrar.RegisterType<IPdfQueueService, PdfQueueService>();
            registrar.RegisterType<IRequestQueueService, RequestQueueService>();
            registrar.RegisterType(typeof(IUserStore<IdentityUserViewModel, ObjectId>), typeof(CustomUserStore));
            registrar.RegisterType(typeof(IRoleStore<IdentityRoleViewModel, ObjectId>) , typeof(CustomRoleStore));

            registrar.RegisterType<IClientService, ClientService>();
            registrar.RegisterType<IRefreshTokenService, RefreshTokenService>();
        }
    }
}
