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
    public class PersonsController : ControllerBase
    {
        private IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetPerson(string idCardNumber)
        {
            var result = _personService.GetPerson(idCardNumber);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
