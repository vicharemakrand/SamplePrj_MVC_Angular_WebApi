using Sample.DomainServices.Core;
using Sample.EntityModels.Identity;
using Sample.IDomainServices.AutoMapper;
using Sample.ViewModels.Identity.WebApi;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Sample.IDomainServices.IdentityStores;
using System;
using Sample.InfraStructure.Logging;

namespace Sample.DomainServices.IdentityStores
{
    public class RefreshTokenService : BaseService<RefreshTokenEntityModel, RefreshTokenViewModel> , IRefreshTokenService
    {
        public async Task<bool> AddRefreshToken(RefreshTokenViewModel token)
        {
            var existingToken = UnitOfWork.RefreshTokenRepository.Get(r => r.Subject == token.Subject && r.ClientId == token.ClientId);
            if (existingToken != null)
            {
                var result = await RemoveRefreshToken(existingToken.TokenId);
            }

            var tokenEntity = token.ToEntityModel<RefreshTokenEntityModel, RefreshTokenViewModel>();
            try
            {
                await UnitOfWork.RefreshTokenRepository.AddAsync(tokenEntity);
                return true;
            }
            catch (Exception ex)
            {
                NLogLogger.Instance.Log(ex);
                return false;
            }
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await UnitOfWork.RefreshTokenRepository.FindByTokenIdAsync(refreshTokenId);
            if (refreshToken != null)
            {
                try
                {
                    await UnitOfWork.RefreshTokenRepository.DeleteAsync(refreshToken);
                    return true;
                }
                catch (Exception ex)
                {
                    NLogLogger.Instance.Log(ex);
                    return false;
                }
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshTokenViewModel refreshToken)
        {
            var tokenEntity = refreshToken.ToEntityModel<RefreshTokenEntityModel, RefreshTokenViewModel>();
             await UnitOfWork.RefreshTokenRepository.DeleteAsync(tokenEntity);
            return true;
        }

        public async Task<RefreshTokenViewModel> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await UnitOfWork.RefreshTokenRepository.FindByTokenIdAsync(refreshTokenId);
            var tokenViewModel = refreshToken.ToViewModel<RefreshTokenEntityModel, RefreshTokenViewModel>();
            return tokenViewModel;
        }

        public List<RefreshTokenViewModel> GetAllRefreshTokens()
        {
            return UnitOfWork.RefreshTokenRepository
                .GetAll()
                .ToViewModel<RefreshTokenEntityModel, RefreshTokenViewModel>()
                .ToList();
        }
    }
}
