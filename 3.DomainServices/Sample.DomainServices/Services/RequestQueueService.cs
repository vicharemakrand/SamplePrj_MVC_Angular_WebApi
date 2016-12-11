using Sample.DomainServices.Core;
using Sample.ViewModels;
using Sample.IDomainServices;
using Sample.IDomainServices.AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System;
using Sample.EntityModels.Queues;
using Sample.IRepositories.Queues;
using Sample.IDomainServices.Queues;

namespace Sample.DomainServices
{
    public class RequestQueueService : BaseService<RequestQueueEntityModel, RequestQueueViewModel>, IRequestQueueService
    {

        public List<RequestQueueViewModel> GetPendingRequestQueue()
        {
            var result = new List<RequestQueueViewModel>();

            var entityList = UnitOfWork.RequestQueueRepository.GetPendingRequestQueue().ToList();

            if (entityList != null && entityList.Count > 0)
            {
                result = entityList.ToViewModel<RequestQueueEntityModel, RequestQueueViewModel>().ToList();
            }

            return result;
        }

        private void UpdateRequestQueue(RequestQueueViewModel requestViewModel,bool isSucceed)
        {
           var existingEntity = UnitOfWork.RequestQueueRepository.FindById(requestViewModel.Id);
                existingEntity.IsRequestSucceed = isSucceed;
            UnitOfWork.RequestQueueRepository.Update(existingEntity);
        }

        public bool ProcessPendingRequests()
        {
            throw new NotImplementedException();
        }
    }
}
