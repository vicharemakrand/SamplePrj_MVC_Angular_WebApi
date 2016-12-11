using Sample.EntityModels.Queues;
using Sample.IDomainServices.Core;
using Sample.ServiceResponse;
using Sample.ViewModels;
using Sample.ViewModels.Identity.WebApi;
using System.Collections.Generic;

namespace Sample.IDomainServices.Queues
{
    public interface IEmailQueueService : IBaseService<EmailQueueEntityModel, EmailQueueViewModel>
    {
        BaseResponseResult SendUserRegistrationMail(IdentityUserViewModel viewModel);
        List<EmailQueueViewModel> GetEmailsFromQueue();
    }
}
