using Sample.ViewModels;
using Sample.ServiceResponse;
using Sample.EntityModels;
using Sample.IRepositories.Core;
using Sample.EntityModels.Core;
using Sample.ViewModels.Core;
using MongoDB.Bson;

namespace Sample.IDomainServices.Core
{
    public interface IBaseService<T,VM>  where T : BaseEntityModel where VM : BaseViewModel
    {
        ResponseResults<VM> GetAll();
        ResponseResult<VM> GetById(ObjectId id);
        ResponseResult<VM> Save(VM viewModel);
    }
}
