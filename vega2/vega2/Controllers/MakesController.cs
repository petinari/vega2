using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega2.Controllers.Resources;
using vega2.Models;
using vega2.Persistence;

namespace vega2.Controllers
{
    public class MakesController : Controller
    {
        private readonly VegaDbContext vegaDbContext;
        private readonly IMapper mapper;

        public MakesController(VegaDbContext vegaDbContext, IMapper mapper)
        {
            this.vegaDbContext = vegaDbContext;
            this.mapper = mapper;
        }

        [HttpGet("/api/makes")]
        public IEnumerable<MakeResources> GetMakes()
        {
            var makes = vegaDbContext.Makes.Include(m => m.Models).ToList();

            return mapper.Map<List<Make>, List<MakeResources>>(makes);
        }
    }
}