using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ODataExample.Data.EdmModels;

namespace ODataExample.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SecurityDbContext _dbContext;

        public AccountRepository(SecurityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<AccountEdm> Get() => _dbContext.Accounts;
    }
}
