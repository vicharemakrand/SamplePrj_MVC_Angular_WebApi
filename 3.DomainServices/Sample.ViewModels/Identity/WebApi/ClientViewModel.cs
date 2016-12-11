using Sample.Utility;
using Sample.ViewModels.Core;
using System;

namespace Sample.ViewModels.Identity.WebApi
{
    public class ClientViewModel : BaseViewModel
    {
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }
        public ApplicationTypes ApplicationType { get; set; }
        public bool Active { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        public string AllowedOrigin { get; set; }
    }
}
