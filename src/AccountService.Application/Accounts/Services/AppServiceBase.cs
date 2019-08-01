using AccountService.Application.Accounts.Interfaces;
using AccountServices.Domain.Interfaces.Services;

namespace AccountService.Application.Accounts.Services
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }
    }
}
