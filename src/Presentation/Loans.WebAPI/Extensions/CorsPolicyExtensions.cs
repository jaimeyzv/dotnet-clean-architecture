namespace Loans.WebAPI.Extensions
{
    public static class CorsPolicyExtensions
    {
        public static void ConfigureCorsPolicy(this IServiceCollection services)
        {
            const string DevCors = "DevCors";
            services.AddCors(opt =>
            {
                opt.AddPolicy(DevCors, p => p
                    .WithOrigins("http://localhost:4200") // Angular dev
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials() // only if you actually use cookies/auth
                );
            });

        }
    }
}
