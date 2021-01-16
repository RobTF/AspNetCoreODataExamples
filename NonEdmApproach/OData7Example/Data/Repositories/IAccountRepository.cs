using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ODataExample.Data.EdmModels;

namespace ODataExample.Data.Repositories
{
    public interface IAccountRepository
    {
        IQueryable<AccountEdm> Get();
    }
}
