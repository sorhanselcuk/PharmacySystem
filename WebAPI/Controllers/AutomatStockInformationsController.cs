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
    public class AutomatStockInformationsController : ControllerBase
    {
        private IAutomatStockInformationService _automatStockInformationService;

        public AutomatStockInformationsController(IAutomatStockInformationService automatStockInformationService)
        {
            _automatStockInformationService = automatStockInformationService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _automatStockInformationService.GetById(id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
