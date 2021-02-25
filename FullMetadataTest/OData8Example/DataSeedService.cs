using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ODataExample.Data;

namespace ODataExample
{
    public class DataSeedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DataSeedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SecurityDbContext>();

            if (dbContext.Accounts.Count() == 0)
            {
                await dbContext.Accounts.AddRangeAsync(SeedData.Accounts());
                await dbContext.SaveChangesAsync();

                await dbContext.Users.AddRangeAsync(SeedData.Users());
                await dbContext.SaveChangesAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
