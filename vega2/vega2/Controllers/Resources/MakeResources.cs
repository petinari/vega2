using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using vega2.Models;

namespace vega2.Controllers.Resources
{
    public class MakeResources
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ModelResource> Models { get; set; }

        public MakeResources()
        {
            Models = new Collection<ModelResource>();   
        }
    }
}
