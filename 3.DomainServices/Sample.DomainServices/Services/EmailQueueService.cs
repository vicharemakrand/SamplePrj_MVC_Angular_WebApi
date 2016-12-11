using Sample.DomainServices.Core;
using Sample.ServiceResponse;
using Sample.ViewModels;
using System;
using Sample.IDomainServices.AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Sample.Utility;
using Sample.Mails;
using Sample.EntityModels.Queues;
using Sample.ViewModels.Identity.WebApi;
using Sample.IDomainServices.Queues;
using Sample.InfraStructure.Logging;

namespace Sample.DomainServices
{
    public class EmailQueueService : BaseService<EmailQueueEntityModel, EmailQueueViewModel>, IEmailQueueService
    {

        private bool AddEmailIntoQueue(EmailQueueEntityModel entity)
        {
            bool result = false;
            try
            {

                if (entity != null)
                {
                    UnitOfWork.EmailQueueRepository.Add(entity);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                NLogLogger.Instance.Log(ex);
                result = false;
            }

            return result;
        }

        public List<EmailQueueViewModel> GetEmailsFromQueue()
        {
            var result = new List<EmailQueueViewModel>();

            var entityList = UnitOfWork.EmailQueueRepository.GetPendingEmailQueue().ToList();

            if (entityList != null && entityList.Count > 0)
            {
                result = entityList.ToViewModel<EmailQueueEntityModel, EmailQueueViewModel>().ToList();
            }

            return result;
        }

        public BaseResponseResult SendUserRegistrationMail(IdentityUserViewModel viewModel)
        {
            BaseResponseResult result = new BaseResponseResult();

            try
            {
                if (string.IsNullOrEmpty(viewModel.Email) == false)
                {
                    var maiTemplate = new UserRegistrationMail(viewModel.Email, viewModel.InputPassword);
                    var queueViewModel = maiTemplate.CreateEmailQueueViewModel(viewModel.Email);
                    var entity = queueViewModel.ToEntityModel<EmailQueueEntityModel, EmailQueueViewModel>();
                    result.IsSucceed = AddEmailIntoQueue(entity); 

                    if (result.IsSucceed)
                    {
                        result.Message = AppMessages.EMAIL_SUCCEED_MESSAGE;
                    }
                    else
                    {
                        result.Message = AppMessages.EMAIL_FAILED_MESSAGE;
                    }
                }
            }
            catch (ApplicationException)
            {
                result.IsSucceed = false;
                result.Message = AppMessages.EMAIL_FAILED_MESSAGE;
            }

            return result;
        }
    }

}
