using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using WebApiCore.Data;
using WebApiCore.Data.Repositories;
using WebApiCore.Data.Repositories.impl;
using WebApiCore.Data.Services;
using WebApiCore.Data.Services.impl;
using WebApiCore.Data.Services.Impl;

namespace WebApiCore
{
    public class Startup
    {
        public IConfiguration configuation;
        public Startup(IConfiguration configuation)
        {
            this.configuation = configuation;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            string connectionString = configuation.GetConnectionString("DefaultConnection");
            services.AddDbContext<WebApiCoreContext>(builder =>
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("WebApiCore.Api"))

            );
            services
               .AddScoped<ICustomerRepository, EfCustomerRepository>()
               .AddScoped<ICurrentWeatherRepository, EfCurrentWeatherRepository>()
               ;
            services
               .AddScoped<ICustomerService, CustomerService>()
               .AddScoped<ICurrentWeatherService, CurrentWeatherService>()
               ;

            services.AddSwaggerGen(m =>
            {
                m.SwaggerDoc("v1", new OpenApiInfo { Title = "title name", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                m.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(m=>
                {
                    m.SwaggerEndpoint("/swagger/v1/swagger.json", "My V1");
                });

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
