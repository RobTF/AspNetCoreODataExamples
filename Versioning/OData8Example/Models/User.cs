using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ODataExample.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GroupName { get; set; }
    }
}
