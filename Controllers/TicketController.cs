using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Models;
using Newtonsoft.Json;
using TicketingSystem.Repositories;
namespace TicketingSystem.Controllers
{

    public class TicketController : ControllerBase
    {

        [HttpGet]
        [Route("tickets")]
        public IActionResult Get()
        {
            return Ok(TicketRepository.GetAll());
        }

        [HttpGet]
        [Route("tickets/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(TicketRepository.Get(id));
        }

        [HttpPost]
        [Route("tickets")]
        public IActionResult Post([FromBody] Ticket ticket)
        {
            TicketRepository.Save(ticket);
            return Ok(ticket);
        }

        [HttpPut]
        [Route("tickets")]
        public IActionResult Put([FromBody] Ticket ticket)
        {
            TicketRepository.Update(ticket);
            return Ok(ticket);
        }

        [HttpDelete]
        [Route("tickets/{id}")]
        public IActionResult Delete(int id)
        {
            TicketRepository.Delete(id);
            return Ok();
        }
    }
}
