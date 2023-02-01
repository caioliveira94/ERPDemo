using ERPDemo.ApplicationService;
using ERPDemo.Data.Repositories;
using ERPDemo.Domain.Interfaces.DataAccess;
using ERPDemo.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ERPDemo.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            #region Repository
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped(typeof(IGrupoRepository), typeof(GrupoRepository));
            #endregion

            #region Services
            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
            services.AddScoped(typeof(IGrupoService), typeof(GrupoService));
            #endregion
        }
    }
}
