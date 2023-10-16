﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatru.Helper;

namespace Teatru.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JwtController : ControllerBase
    { 
        [HttpGet]
        public IActionResult Jwt()
        {
            return new ObjectResult(JwtToken.GenerateJwtToken());
        }
    }
}
