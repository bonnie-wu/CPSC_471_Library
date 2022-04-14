using Microsoft.AspNetCore.Mvc;

namespace CPSC_471_Library.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public static List<LibraryEvent> libEvents = new List<LibraryEvent>
        {
            new LibraryEvent { EventName = "Reading with toddlers ", EventId = 1 },
            new LibraryEvent { EventName = "Coding with teens ", EventId = 2 }
        };

        [HttpGet]
        public async Task<ActionResult<List<LibraryEvent>>> getAllEvents()
        {
            return Ok(libEvents);
        }

        [HttpGet("{eventid}")]
        public async Task<ActionResult<LibraryEvent>> getSingleEvent(int eventid)
        {
            var libEvent = libEvents.FirstOrDefault(h => h.EventId == eventid);
            if (libEvent == null)
            {
                return NotFound("Sorry, event could not be found. \n");
            }
            return Ok(libEvent);
        }
    }
}
