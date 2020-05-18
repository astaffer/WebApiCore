using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WAC.Models.Config;
using WAC.Repository;
using WAC.Repository.Abstract;
using WAC.Rest;
using WAC.Rest.Abstract;
using WAC.Services;
using WAC.Services.Abstract;

namespace WebApiCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));
            services.AddSingleton<IWalletRepository, WalletRepository>();
            services.AddSingleton<ICurrencyRates, CurrencyRates>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddOptions();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
