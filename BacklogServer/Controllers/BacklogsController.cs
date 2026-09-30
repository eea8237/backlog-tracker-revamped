using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// using Shared.Services;
using Shared.Models;
using BacklogServer.Services;

namespace BacklogServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BacklogsController : ControllerBase
    {
        private BacklogService _backlogService;

        public BacklogsController(BacklogService backlogService)
        {
            _backlogService = backlogService;
        }

        [HttpGet]
        public ActionResult<List<BacklogItem>> GetAll()
        {
            var backlogs =  _backlogService.GetBacklogs(); 
            return Ok(backlogs);
        }

        [HttpGet("{backlogId}:int")]
        public ActionResult<Backlog> Get(int backlogId)
        {
            var backlog = _backlogService.GetBacklog(backlogId); 
            
            if (backlog is null) return NotFound();
            else return Ok(backlog);
        }

        // method for adding backlog
        [HttpPost]
        public ActionResult<Backlog> Post([FromBody] Backlog backlog)
        {
            _backlogService.AddBacklog(backlog); 
            
            Console.WriteLine($"Added backlog: {backlog}");
            return Created();
        }

        // method for changing backlog
        [HttpPut("{backlogId}:int")]
        public ActionResult<Backlog> Put(int backlogId, [FromBody] Backlog updatedBacklog)
        {
            _backlogService.UpdateBacklog(backlogId, updatedBacklog);
            
            Console.WriteLine($"Updated backlog {backlogId}: \n{updatedBacklog}");
            return Ok(_backlogService.GetBacklog(backlogId));
        }

        // method for deleting backlog
        [HttpDelete("{backlogId}:int")]
        public ActionResult<string> Delete(int backlogId)
        {
            _backlogService.RemoveBacklog(backlogId);
            return NoContent();
        }

        // add a separate controller for users i think
    }
}