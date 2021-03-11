using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ODataExample.Data.EdmModels;

namespace ODataExample.Data
{
    public class SecurityDbContext : DbContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserEdm> Users { get; set; }

        public DbSet<AccountEdm> Accounts { get; set; }
    }
}
