using ProtoWeb.Infra.CrossCutting.Net.Word;
using ProtoWeb.Infra.Data.MainContext.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProtoWeb.Service.Rest.MainContext.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
        }

        [HttpGet()]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(new { version = "1.0", description = "Bienvenidos a la API ProtoWeb" });
        }
    }
}
