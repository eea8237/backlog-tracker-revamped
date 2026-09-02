using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// using Shared.Services;
using Shared.Models;

namespace BacklogServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BacklogsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<BacklogItem>> GetAll()
        {
            return null;
        }

        [HttpGet("{backlogId}")]
        public ActionResult<Backlog> GetBacklog(int backlogId)
        {
            
            return null;
        }

        // method for adding backlog
        [HttpPost]
        public ActionResult<Backlog> Post([FromBody] Backlog backlog)
        {
            Console.WriteLine($"Added backlog: {backlog}");
            return backlog;
        }

        // method for changing backlog
        [HttpPut("{backlogId}")]
        public ActionResult<Backlog> Put(int backlogId, [FromBody] Backlog updatedBacklog)
        {
            Console.WriteLine($"Updated backlog {backlogId}: \n{updatedBacklog}");
            return updatedBacklog;
        }

        // method for deleting backlog
        [HttpDelete]
        public ActionResult<string> Delete(int id)
        {
            return $"deleted product with id {id}";
        }

        // add a separate controller for users i think
    }
}