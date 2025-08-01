using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GWL.Application.Services
{
    public static class ServiceExtesions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
