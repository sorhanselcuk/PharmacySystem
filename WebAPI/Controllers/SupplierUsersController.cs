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
    public class SupplierUsersController : ControllerBase
    {
        private ISupplierUserService _supplierUserService;

        public SupplierUsersController(ISupplierUserService supplierUserService)
        {
            _supplierUserService = supplierUserService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _supplierUserService.GetUsers();
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _supplierUserService.GetUserById(userId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByUserName(string userName)
        {
            var result = _supplierUserService.GetUserByUserName(userName);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByEmail(string eMail)
        {
            var result = _supplierUserService.GetUserByEmail(eMail);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByFullName(string fullName)
        {
            var result = _supplierUserService.GetUserByFullName(fullName);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
