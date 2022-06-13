using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddRegistrationService( this IServiceCollection services, WebApplicationBuilder webApplicationBuilder)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                }
                );
            services.AddDataService(webApplicationBuilder.Configuration);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "UserApi",
                    ValidAudience = "UserApi",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKeyApplication2022"))
                };
            });

            services.AddApplicationService();
            return services;
        }
    }
}
