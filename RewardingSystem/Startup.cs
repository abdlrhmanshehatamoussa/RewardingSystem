using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using RewardingSystem.Application;
using RewardingSystem.Exceptions;
using RewardingSystem.Filters;
using RewardingSystem.Helpers;
using RewardingSystem.Persistence;
namespace RewardingSystem
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

            //Load application settings
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            AppSettings.Instance.Initialize(this.Configuration);

            //Register the database context
            services.AddDbContext<DatabaseContext>(
                        options =>
                        {
                            options.UseSqlServer(connectionString);
                        }
                    );

            //Register the main services
            services
                        .AddMvc()
                        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                        .AddJsonOptions((options) => { });

            //Injecting dependencies
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AdminFilter>();
            services.AddScoped<LoggedUserFilter>();

            //Swagger
            var info = new OpenApiInfo()
            {
                Version = "V1",
                Title = "Rewarding System",
                Description = "Browser various vouchers from great merchants.",
                Contact = new OpenApiContact()
                {
                    Name = "Abdelrahman Shehata",
                    Email = "abdlrhmanshehata@gmail.com"
                },
                License = null
            };
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", info);
                    c.OperationFilter<AdminFilter>();
                    c.OperationFilter<LoggedUserFilter>();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rewarding System API v1");
            });

            //Exception Handling
            try
            {
                app.UseExceptionHandler(
                c => c.Run(
                    async context =>
                    {
                        var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                        var result = JsonConvert.SerializeObject(new { error = exception.Message });
                        context.Response.ContentType = "application/json";
                        int code = ExceptionMapper.MapException(exception);
                        context.Response.StatusCode = code;
                        await context.Response.WriteAsync(result);
                    }
                )
            );
            }
            catch
            {
                System.Console.WriteLine("Error in Startup");
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
