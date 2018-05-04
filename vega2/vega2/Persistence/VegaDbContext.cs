using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vega2.Persistence
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {

        }
    }
}
