using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CmcApi.Database.Entity;
using CmcApi.Services.DataServices;
using Microsoft.AspNetCore.Mvc;

namespace CmcApi.Vendors.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        protected readonly IVendorsDataService localVendorsDataService;
        public VendorsController(IVendorsDataService vendorsDataService)
        {
            localVendorsDataService = vendorsDataService;
        }

        // GET api/v1/vendors
        [HttpGet]
        public ActionResult FindAll()
        {
            var vendors = localVendorsDataService.FindAll();
            return Ok(vendors);
        }

        // GET api/v1/vendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetAsync(int id)
        {
            var vendor = await localVendorsDataService.FindByIdAsync(id);
            return Ok(vendor);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Vendor entity)
        {
            if (entity != null)
            {
                var result = await localVendorsDataService.CreateAsync(entity);
                return Ok(result);
            }

            return BadRequest("Entity is empty.");
        }

        // PUT api/v1/vendors/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Vendor entity)
        {
            if (entity != null)
            {
                var result = await localVendorsDataService.UpdateAsync(id, entity);
                return Ok(result);
            }

            return BadRequest("Entity is empty.");
        }

        // DELETE api/v1/vendors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> SoftDelete(int id)
        {
            var result = await localVendorsDataService.SoftDeleteAsync(id);
            return Ok(result);
        }
    }
}
