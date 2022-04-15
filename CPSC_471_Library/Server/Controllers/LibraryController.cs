using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPSC_471_Library.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly DataContext _context;

        public LibraryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Library>>> GetAllLibraries()
        {
            var libraries = await _context.Libraries.ToListAsync();
            return Ok(libraries);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Library>> getSingleLibrary(int Id)
        {
            var library = _context.Libraries.FirstOrDefault(l => l.Id == Id);
            if (library == null)
            {
                return NotFound("Sorry, branch could not be found. \n");
            }
            return Ok(library);
        }
    }
}
