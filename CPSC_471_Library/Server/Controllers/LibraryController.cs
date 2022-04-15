using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPSC_471_Library.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        public static List<Library> libraries = new List<Library>
        {
            new Library { LibraryBranch = "Kanto", LibraryAddress = "124 Conch St.Kanto OC Y7U 6R3", LibraryId = 010101, LibraryPhone = "(555)-0101"},
            new Library { LibraryBranch = "Emerald", LibraryAddress = "308 Negra Arroyo Lane Emerald City ZZ R4V 2A5", LibraryId = 100100, LibraryPhone = "(555)-0188"},
            new Library { LibraryBranch = "Gravity Falls", LibraryAddress = "1640 Riverside Drive Bedrock TA U0F 0O1", LibraryId = 129129,LibraryPhone = "(555)-0123"},
            new Library { LibraryBranch = "Bedrock", LibraryAddress = "31 Spooner Street Gravity Falls OR E4B 3C2", LibraryId = 727272,LibraryPhone = "(555)-0145"},
        };

        [HttpGet]
        public async Task<ActionResult<List<LibraryEvent>>> getAllLibraries()
        {
            return Ok(libraries);
        }

        [HttpGet("{libraryid}")]
        public async Task<ActionResult<LibraryEvent>> getSingleLibrary(int libraryid)
        {
            var library = libraries.FirstOrDefault(l => l.LibraryId == libraryid);
            if (library == null)
            {
                return NotFound("Sorry, event could not be found. \n");
            }
            return Ok(library);
        }
    }
}
