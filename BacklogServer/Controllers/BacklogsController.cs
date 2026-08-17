using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Services;
using Shared.Models;

namespace BacklogServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BacklogsController : ControllerBase
    {
        [HttpGet("all")]
        public ActionResult<List<BacklogItem>> GetAll()
        {
            return null;
        }
    }
}