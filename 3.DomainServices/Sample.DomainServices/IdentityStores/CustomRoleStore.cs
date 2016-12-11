using Sample.EntityModels.Identity;
using Sample.IDomainServices.AutoMapper;
using Sample.IRepositories.Core;
using Sample.ViewModels.Identity.WebApi;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.DomainServices.IdentityStores
{
    public class CustomRoleStore :  
        IRoleStore<IdentityRoleViewModel, ObjectId>, 
        IQueryableRoleStore<IdentityRoleViewModel, ObjectId>, 
        IDisposable
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomRoleStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task CreateAsync(IdentityRoleViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("role");

            var model = GetRoleModel(viewModel);

            return unitOfWork.RoleRepository.AddAsync(model);
        }

        public Task UpdateAsync(IdentityRoleViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException("role");

            var model = unitOfWork.RoleRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityRoleViewModel does not correspond to a Role entity.", "role");

            model = viewModel.ToEntityModel<RoleEntityModel, IdentityRoleViewModel>();

            return unitOfWork.RoleRepository.UpdateAsync(model);
        }

        public Task DeleteAsync(IdentityRoleViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("GetRole");

            var model = GetRoleModel(viewModel);

            return unitOfWork.RoleRepository.DeleteAsync(model);
        }

        public Task<IdentityRoleViewModel> FindByIdAsync(ObjectId roleId)
        {
            var model = unitOfWork.RoleRepository.FindById(roleId);

            var viewModel = model.ToViewModel<RoleEntityModel, IdentityRoleViewModel>();

            return Task.FromResult<IdentityRoleViewModel>(viewModel);
        }

        public Task<IdentityRoleViewModel> FindByNameAsync(string roleName)
        {
            var model = unitOfWork.RoleRepository.FindByName(roleName);
            var viewModel = model.ToViewModel<RoleEntityModel, IdentityRoleViewModel>();

            return Task.FromResult<IdentityRoleViewModel>(viewModel);
        }

        public IQueryable<IdentityRoleViewModel> Roles
        {
            get
            {
                return unitOfWork.RoleRepository
                    .GetAll()
                    .Select(x => GetIdentityRoleViewModel(x))
                    .AsQueryable();
            }
        }

        #region private methods

        private RoleEntityModel GetRoleModel(IdentityRoleViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            var model = viewModel.ToEntityModel<RoleEntityModel, IdentityRoleViewModel>();
            return model;
        }

        private IdentityRoleViewModel GetIdentityRoleViewModel(RoleEntityModel model)
        {
            if (model == null)
                return null;

            return model.ToViewModel<RoleEntityModel, IdentityRoleViewModel>();
        }

        #endregion

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
        // ~RoleStore() {
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
    }
}
