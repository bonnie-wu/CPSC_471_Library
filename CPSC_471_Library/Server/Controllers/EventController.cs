using Microsoft.AspNetCore.Mvc;

namespace CPSC_471_Library.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly DataContext _context;

        public EventController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<LibraryEvent>>> getAllEvents()
        {
            var libEvents = await _context.LibraryEvents.ToListAsync();
            return Ok(libEvents);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<LibraryEvent>> getSingleEvent(int Id)
        {
            var libEvent = _context.LibraryEvents.FirstOrDefault(h => h.Id == Id);
            if (libEvent == null)
            {
                return NotFound("Sorry, event could not be found. \n");
            }
            return Ok(libEvent);
        }
    }
}
