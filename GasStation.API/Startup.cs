using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GasStation.Domain.Interfaces.Entity;
using GasStation.Domain.Interfaces.Repositories;
using GasStation.Domain.Services;
using GasStation.Repositories.Context;
using GasStation.Repositories.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GasStation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "GasStation",
                        Version = "v1",
                        Description = "GasStation",
                        Contact = new OpenApiContact
                        {
                            Name = "Fernando Mendes",
                            Url = new Uri("https://github.com/marraia")
                        }
                    });
            });

            services.AddSingleton(Configuration);

            RegisterServices(services);
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

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GasStation");
            });
        }

        void RegisterServices(IServiceCollection services)
        {
            if (Configuration.GetSection("DefaultDatabase").Value == "Postgres")
            {
                services.AddDbContext<GasStationContext>(
                    options => options.UseNpgsql(Configuration.GetSection("ConnectionString").Value));
            }
            else
            {
                services.AddDbContext<GasStationContext>(options =>
                    options.UseSqlServer(Configuration.GetSection("ConnectionString").Value));
            }

            services.AddScoped<IStationDomainService, StationDomainService>();
            services.AddScoped<IStationRepository, StationRepository>();
        }
    }
}
