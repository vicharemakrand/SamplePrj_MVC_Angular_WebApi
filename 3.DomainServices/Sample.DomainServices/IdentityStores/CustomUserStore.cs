using Sample.EntityModels.Identity;
using Sample.IDomainServices.AutoMapper;
using Sample.IDomainServices.IdentityStores;
using Sample.IRepositories.Core;
using Sample.ServiceResponse;
using Sample.ViewModels.Identity.WebApi;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sample.DomainServices.IdentityStores
{
    public class CustomUserStore : IUserLoginStore<IdentityUserViewModel, ObjectId>, 
        IUserClaimStore<IdentityUserViewModel, ObjectId>, 
        IUserRoleStore<IdentityUserViewModel, ObjectId>, 
        IUserPasswordStore<IdentityUserViewModel, ObjectId>, 
        IUserSecurityStampStore<IdentityUserViewModel, ObjectId>, 
        IUserStore<IdentityUserViewModel, ObjectId>, IDisposable 
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomUserStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region IUserStore<IdentityUserViewModel, Guid> Members
        public Task CreateAsync(IdentityUserViewModel model)
        {
            if (model == null)
                throw new ArgumentNullException("user");

            var viewModel = GetUserModel(model);

            return unitOfWork.UserRepository.AddAsync(viewModel);
        }

        public Task DeleteAsync(IdentityUserViewModel model)
        {
            if (model == null)
                throw new ArgumentNullException("user");

            var viewModel = GetUserModel(model);

            return unitOfWork.UserRepository.DeleteAsync(viewModel);
        }

        public Task<IdentityUserViewModel> FindByIdAsync(ObjectId userId)
        {
            var model = unitOfWork.UserRepository.FindById(userId);
            return Task.FromResult<IdentityUserViewModel>(GetIdentityUserViewModel(model));
        }

        public Task<IdentityUserViewModel> FindByNameAsync(string email)
        {
            var model = unitOfWork.UserRepository.FindByEmail(email);
            return Task.FromResult<IdentityUserViewModel>(GetIdentityUserViewModel(model));
        }

        public Task UpdateAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException("user");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            return unitOfWork.UserRepository.UpdateAsync(model);
        }
        #endregion

        #region IUserClaimStore<IdentityUserViewModel, Guid> Members
        public Task AddClaimAsync(IdentityUserViewModel viewModel, Claim claim)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            if (claim == null)
                throw new ArgumentNullException("claim");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            var claimEntityModel = new ClaimEntityModel
            {
                ClaimType = claim.Type,
                ClaimValue = claim.Value,
                User = model
            };
            model.Claims.Add(claimEntityModel);

            return unitOfWork.UserRepository.UpdateAsync(model);
        }

        public Task<IList<Claim>> GetClaimsAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            return Task.FromResult<IList<Claim>>(model.Claims.Select(x => new Claim(x.ClaimType, x.ClaimValue)).ToList());
        }

        public Task RemoveClaimAsync(IdentityUserViewModel viewModel, Claim claim)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            if (claim == null)
                throw new ArgumentNullException("claim");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            var claimEntityModel = model.Claims.FirstOrDefault(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value);
            model.Claims.Remove(claimEntityModel);

            return unitOfWork.UserRepository.UpdateAsync(model);
        }
        #endregion

        #region IUserLoginStore<IdentityUserViewModel, Guid> Members
        public Task AddLoginAsync(IdentityUserViewModel viewModel, UserLoginInfo login)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            if (login == null)
                throw new ArgumentNullException("login");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            var externalLoginEntityModel = new ExternalLoginEntityModel
            {
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey,
                User = model
            };
            model.Logins.Add(externalLoginEntityModel);

            return unitOfWork.UserRepository.UpdateAsync(model);
        }

        public Task<IdentityUserViewModel> FindAsync(UserLoginInfo login)
        {
            if (login == null)
                throw new ArgumentNullException("login");

            var identityUser = default(IdentityUserViewModel);

            var externalLoginEntityModel = unitOfWork.ExternalLoginRepository.GetByProviderAndKey(login.LoginProvider, login.ProviderKey);
            if (externalLoginEntityModel != null)
                identityUser = GetIdentityUserViewModel(externalLoginEntityModel.User);

            return Task.FromResult<IdentityUserViewModel>(identityUser);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            return Task.FromResult<IList<UserLoginInfo>>(model.Logins.Select(x => new UserLoginInfo(x.LoginProvider, x.ProviderKey)).ToList());
        }

        public Task RemoveLoginAsync(IdentityUserViewModel viewModel, UserLoginInfo login)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            if (login == null)
                throw new ArgumentNullException("login");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            var loginModel = model.Logins.FirstOrDefault(x => x.LoginProvider == login.LoginProvider && x.ProviderKey == login.ProviderKey);
            model.Logins.Remove(loginModel);

            return unitOfWork.UserRepository.UpdateAsync(model);
        }
        #endregion

        #region IUserRoleStore<IdentityUserViewModel, Guid> Members
        public Task AddToRoleAsync(IdentityUserViewModel viewModel, string roleName)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: roleName.");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");
            var roleEntityModel = unitOfWork.RoleRepository.FindByName(roleName);
            if (roleEntityModel == null)
                throw new ArgumentException("roleName does not correspond to a Role entity.", "roleName");

            model.Roles.Add(roleEntityModel);
            return unitOfWork.UserRepository.UpdateAsync(model);
        }

        public Task<IList<string>> GetRolesAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            return Task.FromResult<IList<string>>(model.Roles.Select(x => x.Name).ToList());
        }

        public Task<bool> IsInRoleAsync(IdentityUserViewModel viewModel, string roleName)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: role.");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            return Task.FromResult<bool>(model.Roles.Any(x => x.Name == roleName));
        }

        public Task RemoveFromRoleAsync(IdentityUserViewModel viewModel, string roleName)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: role.");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            var r = model.Roles.FirstOrDefault(x => x.Name == roleName);
            model.Roles.Remove(r);

            return unitOfWork.UserRepository.UpdateAsync(model);
        }
        #endregion

        #region IUserPasswordStore<IdentityUserViewModel, Guid> Members
        public Task<string> GetPasswordHashAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<string>(viewModel.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<bool>(!string.IsNullOrWhiteSpace(viewModel.PasswordHash));
        }

        public Task SetPasswordHashAsync(IdentityUserViewModel viewModel, string passwordHash)
        {
            viewModel.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }
        #endregion

        #region IUserSecurityStampStore<IdentityUserViewModel, Guid> Members
        public Task<string> GetSecurityStampAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<string>(viewModel.SecurityStamp);
        }

        public Task SetSecurityStampAsync(IdentityUserViewModel viewModel, string stamp)
        {
            viewModel.SecurityStamp = stamp;
            return Task.FromResult(0);
        }
        #endregion

        #region Private Methods
        private UserEntityModel GetUserModel(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            var model = viewModel.ToEntityModel<UserEntityModel, IdentityUserViewModel>();
            return model;
        }

        private IdentityUserViewModel GetIdentityUserViewModel(UserEntityModel model)
        {
            if (model == null)
                return null;

            var viewModel = model.ToViewModel<UserEntityModel, IdentityUserViewModel>();

            return viewModel;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UserStore() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
        #endregion
    }
}
