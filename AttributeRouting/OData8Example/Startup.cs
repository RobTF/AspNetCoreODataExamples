using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ODataExample.Data;
using ODataExample.Data.EdmModels;
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

            services.AddOData(opts => opts
                .Count()
                .Filter()
                .Expand()
                .Select()
                .OrderBy()
                .SetMaxTop(null)
                .AddModel(EdmModelBuilder.GetEdmModel()));

            services
                .AddAuthentication("Bearer")
                .AddScheme<AuthenticationSchemeOptions, FakeAuthenticationHandler>("Bearer", null);

            services.AddControllers();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/$odata-routes", ODataRouteDumper.DumpAllODataRoutes);
                endpoints.MapControllers();
            });
        }
    }
}
