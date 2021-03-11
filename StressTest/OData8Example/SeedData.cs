using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ODataExample.Data.EdmModels;

namespace ODataExample
{
    public static class SeedData
    {
        public static IEnumerable<AccountEdm> Accounts()
        {
            return new[]
            {
                new AccountEdm
                {
                    Id = new Guid("1C82F39E-462E-4E76-AC84-7FB9CA4827B9"),
                    Name = "Customer 1",
                    InternalField = "AHG5892D",
                },
                new AccountEdm
                {
                    Id = new Guid("CD755916-4834-42C4-93F2-8933BB57F62D"),
                    Name = "Customer 2",
                    InternalField = "AUUIJ298",
                },
                new AccountEdm
                {
                    Id = new Guid("826D5E58-85D2-4AE5-932F-A491F8CBC979"),
                    Name = "Customer 3",
                    InternalField = "028JYIAO",
                },
            };
        }

        public static IEnumerable<UserEdm> Users()
        {
            return new[]
            {
                new UserEdm
                {
                    Id = new Guid("2CA28D1C-59C9-41EC-96FC-F8D09F625401"),
                    AccountId = new Guid("CD755916-4834-42C4-93F2-8933BB57F62D"),
                    Name = "User 1",
                    PasswordHash = "jferw098mwe890",
                    GroupName = "Retail",
                },
                new UserEdm
                {
                    Id = new Guid("8ADD10EB-BA1A-4F4E-B353-1941C0A63802"),
                    AccountId = new Guid("826D5E58-85D2-4AE5-932F-A491F8CBC979"),
                    Name = "User 2",
                    PasswordHash = "fj892j48923fjwe89f",
                    GroupName = "CustomerSupport",
                },
                new UserEdm
                {
                    Id = new Guid("BCE039B8-FF34-4A8C-98D2-1AA3221BBF6A"),
                    AccountId = new Guid("CD755916-4834-42C4-93F2-8933BB57F62D"),
                    Name = "User 3",
                    PasswordHash = "jolikjcwioj234ioj",
                    GroupName = "Retail",
                },
                new UserEdm
                {
                    Id = new Guid("229CF8C1-830E-4B7F-9F9D-69B4224B0514"),
                    AccountId = new Guid("1C82F39E-462E-4E76-AC84-7FB9CA4827B9"),
                    Name = "User 4",
                    PasswordHash = "fk2982389jf983",
                    GroupName = "CustomerSupport",
                },
                new UserEdm
                {
                    Id = new Guid("F550EA00-B8EB-4DD9-A550-F95E0A8058EE"),
                    AccountId = new Guid("CD755916-4834-42C4-93F2-8933BB57F62D"),
                    Name = "User 5",
                    PasswordHash = ";f[sdopkw309k",
                    GroupName = "Retail",
                },
                new UserEdm
                {
                    Id = new Guid("6161B27C-CABD-4076-B216-93C5D19BBF39"),
                    AccountId = new Guid("CD755916-4834-42C4-93F2-8933BB57F62D"),
                    Name = "User 6",
                    PasswordHash = "vjer8j4398vmnwiou",
                    GroupName = "Retail",
                },
                new UserEdm
                {
                    Id = new Guid("AFDC6D89-B8B7-4A88-A79F-27F11544D438"),
                    AccountId = new Guid("1C82F39E-462E-4E76-AC84-7FB9CA4827B9"),
                    Name = "User 7",
                    PasswordHash = "retywqreywtqry89",
                    GroupName = "Retail",
                },
                new UserEdm
                {
                    Id = new Guid("50308880-35CA-41A8-9627-29AEA0579846"),
                    AccountId = new Guid("1C82F39E-462E-4E76-AC84-7FB9CA4827B9"),
                    Name = "User 8",
                    PasswordHash = "cxzbhxzvnhcz",
                    GroupName = "Retail",
                },
                new UserEdm
                {
                    Id = new Guid("9902008A-8738-4293-A640-6180CB7A090A"),
                    AccountId = new Guid("826D5E58-85D2-4AE5-932F-A491F8CBC979"),
                    Name = "User 9",
                    PasswordHash = "53490853409",
                    GroupName = "CustomerSupport",
                },
                new UserEdm
                {
                    Id = new Guid("77B9AA17-0417-468F-AE70-766FFE30BDD0"),
                    AccountId = new Guid("826D5E58-85D2-4AE5-932F-A491F8CBC979"),
                    Name = "User 10",
                    PasswordHash = "khfgpoihkgfoik",
                    GroupName = "Retail",
                },
            };
        }
    }
}
