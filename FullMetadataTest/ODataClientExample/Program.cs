using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OData.Client;
using ODataExampleCommon;

namespace ODataClientExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var context = new DataContainer(new Uri("http://localhost:5001/"));
            context.MergeOption = MergeOption.NoTracking;
            
            // go through the accounts
            foreach(var account in context.Accounts)
            {
                Console.WriteLine("Account: {0}", account.Name);
            }

            // project the ID of an account
            var accountId = (
                from a in context.Accounts
                where a.Name == "Customer 1"
                select new
                {
                    Id = a.Id,
                }).FirstOrDefault();

            // get a query to the GetUsers() for the account we chose
            var keyPath = context.Accounts.GetKeyPath(accountId.Id.ToString());
            var accountObj = new DataServiceQuerySingle<Account>(context.Accounts.Context, keyPath);
            var query = accountObj.CreateFunctionQuery<User>("GetUsers", true);

            // project on GetUsers()
            var users =
                from u in query
                select new
                {
                    Name = u.Name,
                };

            // output the result
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }


            Console.WriteLine("Done. Press a key to close.");
            Console.ReadKey();
        }
    }
}
