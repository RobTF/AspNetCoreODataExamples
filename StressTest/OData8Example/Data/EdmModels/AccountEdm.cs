using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ODataExample.Data.EdmModels
{
    public class AccountEdm
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Some internal field trhat should not be exposed via the API.
        /// </summary>
        [Required]
        [StringLength(80)]
        public string InternalField { get; set; }
    }
}
