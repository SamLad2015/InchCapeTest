using AutoMapper;
using InchCapeTest.Entities;
using InchCapeTest.Helpers;
using InchCapeTest.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using InchCapeTest.MappingProfiles;
using InchCapeTest.Repositories;
using InchCapeTest.Services;
using Microsoft.EntityFrameworkCore;

namespace InchCapeTest
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
            services.AddOptions();
            services.AddDbContext<TestDbContext>(opt => 
                opt.UseInMemoryDatabase(databaseName: "InchCapetestDb"));
            services.AddCustomCors("AllowAllOrigins");
            services.AddScoped<IReadRepository<MakeEntity>, ReadRepository<MakeEntity>>();
            services.AddScoped<IWriteRepository<MakeEntity>, WriteRepository<MakeEntity>>();
            services.AddScoped<IReadRepository<QuoteTypeEntity>, ReadRepository<QuoteTypeEntity>>();
            services.AddScoped<IWriteRepository<QuoteTypeEntity>, WriteRepository<QuoteTypeEntity>>();
            services.AddScoped<IReadRepository<VehicleTypeEntity>, ReadRepository<VehicleTypeEntity>>();
            services.AddScoped<IWriteRepository<VehicleTypeEntity>, WriteRepository<VehicleTypeEntity>>();
            services.AddScoped<IReadRepository<VehicleEntity>, ReadRepository<VehicleEntity>>();
            services.AddScoped<IWriteRepository<VehicleEntity>, WriteRepository<VehicleEntity>>();
            services.AddScoped<IWriteRepository<AprRangeEntity>, WriteRepository<AprRangeEntity>>();
            services.AddScoped<IVehiclePropertyService, VehiclePropertyService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });
            services.AddControllers();
            services.AddVersioning();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(MakeMappings));
            services.AddAutoMapper(typeof(QuoteTypeMappings));
            services.AddAutoMapper(typeof(VehicleTypeMappings));
            services.AddAutoMapper(typeof(VehicleMappings));
            services.AddAutoMapper(typeof(AprRangeMappings));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            ILoggerFactory loggerFactory, 
            IWebHostEnvironment env, 
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.AddProductionExceptionHandling(loggerFactory);
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAllOrigins");
            app.UseExceptionHandler("/error"); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
        }
    }
}