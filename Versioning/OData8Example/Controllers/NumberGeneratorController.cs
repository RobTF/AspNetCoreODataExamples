using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ODataExample.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Authorize]
    public class NumberGeneratorController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetNumber()
        {
            return Ok(56);
        }
    }
}
