using Sample.ViewModels;
using Sample.ViewModels.Core;

namespace Sample.ServiceResponse
{
    public class ResponseResult<VM> : BaseResponseResult
        where VM: BaseViewModel
    {
        public VM ViewModel { get; set; }
    }
}
