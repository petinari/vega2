﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega2.Models;

namespace vega2.Persistence
{
    public class VegaDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }

        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {

        }
    }
}
