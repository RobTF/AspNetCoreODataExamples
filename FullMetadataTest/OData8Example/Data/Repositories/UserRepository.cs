using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ODataExample.Data.EdmModels;

namespace ODataExample.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SecurityDbContext _dbContext;

        public UserRepository(SecurityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<UserEdm> Get() => _dbContext.Users;

        public IQueryable<UserEdm> GetUsersByAccount(Guid accountId) =>
            _dbContext.Users.Where(u => u.AccountId == accountId);
    }
}
