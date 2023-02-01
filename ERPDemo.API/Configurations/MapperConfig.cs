using ERPDemo.API.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ERPDemo.API.Configurations
{
    public static class MapperConfig
    {
        public static IServiceCollection UseApiMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(ApiMapper));
            return service;
        }
    }
}
