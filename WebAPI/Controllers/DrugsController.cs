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
    public class DrugsController : ControllerBase
    {
        private IDrugService _drugService;

        public DrugsController(IDrugService drugService)
        {
            _drugService = drugService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add([FromBody]Drug drug)
        {
            var result = _drugService.Add(drug);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] Drug drug)
        {
            var result = _drugService.Update(drug);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(int drugId)
        {
            var result = _drugService.Delete(new Drug { Id=drugId });
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _drugService.GetDrugs();
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetDrugsBySupplierId(int supplierId)
        {
            var result = _drugService.GetDrugsBySupplierId(supplierId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetDrugsWithPrescription()
        {
            var result = _drugService.GetDrugsWithPrescription();
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetDrugsWithoutPrescription()
        {
            var result = _drugService.GetDrugsWithoutPrescription();
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
        
    }
}
