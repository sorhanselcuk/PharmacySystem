using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add([FromBody]Supplier supplier)
        {
            var result = _supplierService.Add(supplier);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] Supplier supplier)
        {
            var result = _supplierService.Update(supplier);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(int supplierId)
        {
            var result = _supplierService.Delete(new Supplier { Id=supplierId });
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetSuppliers()
        {
            var result = _supplierService.GetSuppliers();
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
