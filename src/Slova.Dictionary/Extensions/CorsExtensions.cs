using Microsoft.Extensions.DependencyInjection;

namespace Slova.Dictionary.Extensions
{
    public static class CorsExtensions
    {
        public const string AllowedOrigins = "AllowedOrigins";

        public static void SetupCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowedOrigins, builder =>
                {
                    builder
                        .WithOrigins("http://localhost:3000")
                        .AllowAnyHeader();
                });
            });
        }
    }
}