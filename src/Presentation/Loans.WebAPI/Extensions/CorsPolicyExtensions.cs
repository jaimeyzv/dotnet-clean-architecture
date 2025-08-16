namespace Loans.WebAPI.Extensions
{
    public static class CorsPolicyExtensions
    {
        public static void ConfigureCorsPolicy(this IServiceCollection services)
        {          
            const string CorsPolicy = "SwaCors";
            services.AddCors(opt =>
            {
                opt.AddPolicy(CorsPolicy, p => p
                    .WithOrigins(                        
                        "http://localhost:4200",                                // Angular dev server
                        "https://purple-smoke-0edbde40f.2.azurestaticapps.net"  // replace with your Static Web App URL
                    )
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
        }
    }
}
