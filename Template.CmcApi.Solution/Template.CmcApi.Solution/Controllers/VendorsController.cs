using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CmcApi.Services.DataServices;
using Microsoft.AspNetCore.Mvc;

namespace CmcApi.Vendors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        protected readonly IVendorsDataService localVendorsDataService;
        public VendorsController(IVendorsDataService vendorsDataService)
        {
            localVendorsDataService = vendorsDataService;
        }

        // GET api/values
        [HttpGet]
        [Route("values")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("")]
        public ActionResult FindAll()
        {
            var vendors = localVendorsDataService.FindAll();
            return Ok(vendors);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
