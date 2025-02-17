using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Migrations.Data;
using TravelAdvisor.Infrastructure.Migrations.Interfaces;
using TravelAdvisor.Infrastructure.Migrations.Repository;
using TravelAdvisor.Infrastructure.Models.Mapping;
using TravelAdvisor.Infrastructure.Services;

namespace TravelAdvisor.Web
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

             services.AddScoped<IUnitOfWork, UnitOfWork>();
             services.AddScoped<IUserService, UserService>();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DbApplicationContext>(options => options.UseSqlServer(connection));

            var mapperConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new AutoMapping());
            });

            IMapper _mapper = mapperConfig.CreateMapper();
            services.AddSingleton(_mapper);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TravelAdvisor.Web", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TravelAdvisor.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
