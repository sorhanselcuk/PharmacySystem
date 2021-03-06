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
    public class AutomatsController : ControllerBase
    {
        private IAutomatService _automatService;

        public AutomatsController(IAutomatService automatService)
        {
            _automatService = automatService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add([FromBody]Automat automat)
        {
            var result = _automatService.Add(automat);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] Automat automat)
        {
            var result = _automatService.Update(automat);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete([FromBody] Automat automat)
        {
            var result = _automatService.Delete(automat);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _automatService.GetById(id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _automatService.GetAll();
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByTownId(int townId)
        {
            var result = _automatService.GetByTownId(townId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
