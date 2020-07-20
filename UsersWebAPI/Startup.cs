using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UsersWebAPI.App_Start;
using UsersWebAPI.Helpers;
using UsersWebAPI.Models;
using UsersWebAPI.Services;

namespace UsersWebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MarketContext>(options => options.UseSqlServer(WebApiConfig.DATABASE_CONNECTION));
            services.AddControllers();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IMarketService, MarketService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}