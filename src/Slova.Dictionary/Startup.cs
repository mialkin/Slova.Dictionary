using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Slova.Dictionary.Db;

namespace Slova.Dictionary
{
    public class Startup
    {
        readonly string _allowedOrigins = "_allowedOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: _allowedOrigins, builder =>
                {
                    builder
                        .WithOrigins("http://localhost:3000")
                        .AllowAnyHeader();
                });
            });

            services.AddControllers();

            services.AddDbContext<DictionaryContext>(options =>
                options.UseNpgsql("Host=localhost;Database=slova;Username=postgres;Password=mysecretpassword"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_allowedOrigins);

            app.UseEndpoints(endpoints => { endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}"); });
        }
    }
}