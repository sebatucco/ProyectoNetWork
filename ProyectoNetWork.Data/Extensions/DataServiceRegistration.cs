
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoNetWork.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataServiceRegistration
    {
        public static IServiceCollection AddDataService(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<DataContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("SQLServerConnection"))
                   );
        }
    }
}
