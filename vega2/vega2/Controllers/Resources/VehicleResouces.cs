using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using vega2.Models;

namespace vega2.Controllers.Resources
{

    public class VehicleResouces
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        [Required]
        public ContactResources Contact { get; set; }
        public ICollection<int> Features { get; set; }

        public VehicleResouces()
        {
            Features = new Collection<int>();
        }

    }
}
