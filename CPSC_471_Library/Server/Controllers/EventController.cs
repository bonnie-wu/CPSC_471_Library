using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CPSC_471_Library.Shared;

namespace CPSC_471_Library.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public static List<Event> Events = new List<Event> { 
            new Event {EventName = "Storytime for Toddlers", EventId = 1},
            new Event {EventName = "Coding for Teens", EventId = 2}
        };        
    
        [HttpGet("{EventId}")]
        public async Task<ActionResult<Events>> GetEvents()
        {
            return Ok(Events);
        }
    }

}
