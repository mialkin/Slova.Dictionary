using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Slova.Dictionary.Db;
using Slova.Dictionary.Extensions;
using Slova.Dictionary.Infrastructure;

namespace Slova.Dictionary
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.SetupCors();
            services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.WriteIndented = true; });

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddDbContext<DictionaryContext>(options =>
                options.UseNpgsql("Host=localhost;Database=slova;Username=postgres;Password=mysecretpassword",
                    x => x.MigrationsAssembly("Slova.Dictionary")));

            services.AddRepositories();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection(); // TODO do I need it?
            app.UseRouting();
            app.UseCors(CorsExtensions.AllowedOrigins); // TODO will I even need this in cluster?
            app.UseEndpoints(endpoints => { endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}"); });
        }
    }
}