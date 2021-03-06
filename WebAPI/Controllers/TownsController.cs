using Business.Abstract;
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
    public class TownsController : ControllerBase
    {
        private ITownService _townService;

        public TownsController(ITownService townService)
        {
            _townService = townService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _townService.GetAll();
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllByCityId(int cityId)
        {
            var result = _townService.GetAllByCityId(cityId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetTownById(int townId)
        {
            var result = _townService.GetTownById();
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
