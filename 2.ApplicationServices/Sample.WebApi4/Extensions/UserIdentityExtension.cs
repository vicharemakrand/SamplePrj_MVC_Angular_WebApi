using Sample.Utility;
using Microsoft.AspNet.Identity;
using System;
using System.Security.Principal;

public static class UserIdentityExtension
    {
        public static Guid GetUserGuid(this IIdentity identity)
        {
            return AppMethods.GetGuid(identity.GetUserId());
        }
    }
