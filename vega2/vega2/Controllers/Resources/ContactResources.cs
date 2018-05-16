using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vega2.Controllers.Resources
{
    public class ContactResources
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
    }
}
