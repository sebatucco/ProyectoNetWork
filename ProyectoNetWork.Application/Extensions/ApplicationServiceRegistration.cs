

using ProyectoNetWork.Application.Interface;
using ProyectoNetWork.Application.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceRegistration
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection service)
        {
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddScoped<ISecurityRepository, SecurityRepository>();

            return service;
        }
    }
}
