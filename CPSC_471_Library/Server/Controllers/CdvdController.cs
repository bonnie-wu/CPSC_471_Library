using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPSC_471_Library.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CdvdController : ControllerBase
    {
        private DataContext context;

        public CdvdController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CDVD>>> Get()
        {
            return Ok(await context.Cdvds.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CDVD>> Get(int id)
        {
            var cdvd = await context.Cdvds.FindAsync(id);
            if (cdvd == null)
                return BadRequest("Cdvd not found.");
            return Ok(cdvd);
        }

        [HttpGet("cdvds/{title}")]
        public async Task<ActionResult<CDVD>> GetCdvdByTitle(string title)
        {
            var cdvd = await context.Cdvds.SingleOrDefaultAsync(cdvd_ => cdvd_.Title == title);
            if (cdvd == null)
                return BadRequest("Cdvd not found.");
            return Ok(cdvd);
        }

        [HttpGet("f/{genre}")]
        public async Task<ActionResult<List<CDVD>>> GetCdvdsByGenre(string genre)
        {
            var cdvd = context.Cdvds.Where<CDVD>(_cdvd => _cdvd.Genre == genre);
            if (cdvd == null)
                return BadRequest("Cdvd not found.");
            return Ok(await cdvd.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<CDVD>>> AddCdvd(CDVD cdvd)
        {
            context.Cdvds.Add(cdvd);
            await context.SaveChangesAsync();
            return Ok(await context.Cdvds.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<CDVD>>> UpdateCdvd(CDVD request)
        {
            var cdvd = await context.Cdvds.FindAsync(request.Id);
            if (cdvd == null)
                return BadRequest("Cdvd not found.");
            cdvd.Title = request.Title;
            cdvd.Location = request.Location;
            cdvd.Producer = request.Producer;
            cdvd.Copies = request.Copies;
            cdvd.Distribution = request.Distribution;
            cdvd.Genre = request.Genre;
            cdvd.ReleaseYear = request.ReleaseYear;

            await context.SaveChangesAsync();

            return Ok(await context.Cdvds.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CDVD>>> Del(int id)
        {
            var cdvd = await context.Cdvds.FindAsync(id);
            if (cdvd == null)
                return BadRequest("cdvd not found.");
            context.Cdvds.Remove(cdvd);
            await context.SaveChangesAsync();
            return Ok(await context.Cdvds.ToListAsync());
        }
    }
}
