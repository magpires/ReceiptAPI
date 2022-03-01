using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ReceiptAPI.Context;
using ReceiptAPI.Repositories;
using ReceiptAPI.Repositories.Interfaces;
using ReceiptAPI.Services;
using ReceiptAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI
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
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            var connectionString = Configuration.GetConnectionString("Default");

            services.AddDbContext<ReceiptContext>(options =>
            {

                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                string connectionString;
                if (env == "Development")
                {
                    connectionString = Configuration.GetConnectionString("Default");
                }
                else
                {
                    //Connection String used at runtime by Heroku
                    var connectionStringHeroku = Environment.GetEnvironmentVariable("CLEARDB_DATABASE_URL");
                    connectionStringHeroku = connectionStringHeroku.Replace("mysql://", string.Empty);
                    var userPassSide = connectionStringHeroku.Split("@")[0];
                    var hostSide = connectionStringHeroku.Split("@")[1];

                    var connUser = userPassSide.Split(":")[0];
                    var connPass = userPassSide.Split(":")[1];
                    var connHost = hostSide.Split("/")[0];
                    var connDb = hostSide.Split("/")[1].Split("?")[0];

                    connectionString = $"Server={connHost};Database={connDb};Uid={connUser};Pwd={connPass};SslMode=None;";

                }
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ReceiptContext).Assembly.FullName));

            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = Configuration["AppName"], Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddCors();

            // Repositories dependency injections
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Services dependency injections
            services.AddScoped<ICustomerService, CustomerService>();
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
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", Configuration["AppName"]));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
