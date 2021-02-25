using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ODataExample.Data.EdmModels
{
    public class UserEdm
    {
        [Key]
        public Guid Id { get; set; }

        public Guid AccountId { get; set; }

        public string Name { get; set; }

        public string PasswordHash { get; set; }

        public string GroupName { get; set; }
    }
}
