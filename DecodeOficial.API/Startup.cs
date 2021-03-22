using DecodeOficial.Application.Mapper;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Domain.Interfaces.Servicies;
using DecodeOficial.Domain.Servicies;
using DecodeOficial.Infrastructure.Data.Context;
using DecodeOficial.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace DecodeOficial.API
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
            var connection = Configuration["ConnectionString"];
            services.AddDbContext<DecodeContext>
                (options => options.UseSqlServer(connection));

            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            services.AddScoped<IServicePerson, ServicePerson>();
            services.AddScoped<IServiceProfession, ServiceProfession>();
            services.AddScoped<IServiceHobby, ServiceHobby>();
            services.AddScoped<IServicePeopleHobbies, ServicePeopleHobbies>();

            services.AddScoped<IRepositoryPerson, RepositoryPerson>();
            services.AddScoped<IRepositoryProfession, RepositoryProfession>();
            services.AddScoped<IRepositoryHobby, RepositoryHobby>();
            services.AddScoped<IRepositoryPeopleHobbies, RepositoryPeopleHobbies>();

            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            var assembly = AppDomain.CurrentDomain.Load("DecodeOficial.Application");
            services.AddMediatR(assembly);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Decode",
                    Description = "ASP.NET Core Web API Project",
                    Contact = new OpenApiContact
                    {
                        Name = "Rafael Delgado",
                        Email = "rafa12del@hotmail.com",
                        Url = new Uri("https://github.com/delgadorafael"),
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "API Decode v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSerilogRequestLogging();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<DecodeContext>();
            context.Database.Migrate();
        }
    }
}
