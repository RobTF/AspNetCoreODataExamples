using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using ODataExample.Data;
using ODataExample.Data.Repositories;
using ODataExample.Security;

namespace ODataExample
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
            services.AddDbContext<SecurityDbContext>(opt => opt.UseInMemoryDatabase("Example"));

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddHostedService<DataSeedService>();
            services.AddSingleton<IMapper, Mapper>();
            
            services.AddOData();

            services
                .AddAuthentication("Bearer")
                .AddScheme<AuthenticationSchemeOptions, FakeAuthenticationHandler>("Bearer", null);

            services
                .AddControllers(opts => opts.EnableEndpointRouting = false)
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy
                        {
                            ProcessDictionaryKeys = true,
                        },
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Expand().Select().Count().OrderBy().Filter().MaxTop(null);
            });
        }
    }
}
