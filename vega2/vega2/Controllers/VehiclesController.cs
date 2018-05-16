using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega2.Controllers.Resources;
using vega2.Models;
using vega2.Persistence;

namespace vega2.Controllers
{
    [Produces("application/json")]
    [Route("api/Vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext vegaDbContext;

        public VehiclesController(IMapper mapper, VegaDbContext vegaDbContext)
        {
            this.mapper = mapper;
            this.vegaDbContext = vegaDbContext;
        }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody]VehicleResouces vehicleResources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = vegaDbContext.Models.Find(vehicleResources.ModelId);

            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid ModelId");
                return BadRequest(ModelState);
            }

            var vehicle = mapper.Map<VehicleResouces, Vehicle>(vehicleResources);
            vehicle.LastUpdate = DateTime.Now;
            vegaDbContext.Vehicles.Add(vehicle);
            vegaDbContext.SaveChanges();

            var res = mapper.Map<Vehicle, VehicleResouces>(vehicle);

            return Ok(res);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(int id, [FromBody]VehicleResouces vehicleResources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = vegaDbContext.Models.Find(vehicleResources.ModelId);

            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid ModelId");
                return BadRequest(ModelState);
            }

            var vehicle = vegaDbContext.Vehicles.Include(v => v.Features).SingleOrDefault(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            mapper.Map(vehicleResources, vehicle);
            vehicle.LastUpdate = DateTime.Now;
          

            vegaDbContext.SaveChanges();

            var res = mapper.Map<Vehicle, VehicleResouces>(vehicle);

            return Ok(res);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var vehicle = vegaDbContext.Vehicles.Find(id);
            if (vehicle != null)
            {
                vegaDbContext.Remove(vehicle);
                vegaDbContext.SaveChanges();
                return Ok(id);
            }
            return NotFound();
           
          
        }
        [HttpGet("{id}")]
        public IActionResult GetVehicle(int id)
        {
            var vehicle = vegaDbContext.Vehicles.Include(v => v.Features).SingleOrDefault(v => v.Id == id);
            if (vehicle != null)
            {
                var vehicleResource = mapper.Map<Vehicle, VehicleResouces>(vehicle);
                return Ok(vehicleResource);
            }
            return NotFound();

        }
    }
}