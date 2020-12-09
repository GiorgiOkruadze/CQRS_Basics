using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.ApplicationServices.Mappers;
using CQRS.CoreServices.Repositorys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MediatR;
using CQRS.DatabaseEntity.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CQRS_Basics
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
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddAutoMapper(typeof(ObjectsMapper));

            var assembly = AppDomain.CurrentDomain.Load("CQRS.ApplicationServices");
            services.AddMediatR(assembly);
            ///services.AddMediatR(typeof(Startup));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("CQRSBasic", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "CQRS Basics",
                    Version = "4",
                    Description = "Giorgi Okruadze Test Api",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "oqruadze1997@gmail.com",
                        Name = "Giorgi Okruadze",
                        Url = new Uri("https://www.facebook.com/gio.oqruadze")
                    }
                });
            });


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/CQRSBasic/swagger.json", "CQRS Basics");
                options.RoutePrefix = "";
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
