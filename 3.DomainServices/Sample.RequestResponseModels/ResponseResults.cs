using Sample.ViewModels;
using Sample.ViewModels.Core;
using System.Collections.Generic;

namespace Sample.ServiceResponse
{
    public class ResponseResults<VM> : BaseResponseResult  where VM: BaseViewModel
    {
        public List<VM> ViewModels { get; set; } 
    }
}
