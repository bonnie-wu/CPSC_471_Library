using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPSC_471_Library.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryCardController : ControllerBase
    {
        private DataContext context;

        public LibraryCardController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<LibraryCard>>> Get()
        {
            return Ok(await context.LibraryCards.ToListAsync());
        }

        [HttpGet("{no}")]
        public async Task<ActionResult<LibraryCard>> Get(string no)
        {
            var card = await context.LibraryCards.FirstOrDefaultAsync(card_ => card_.Card_number == no);
            if (card == default(LibraryCard))
                return BadRequest("Library card not found.");
            return Ok(card);
        }

        [HttpPost]
        public async Task<ActionResult<List<LibraryCard>>> AddCard(LibraryCard card)
        {
            context.LibraryCards.Add(card);
            await context.SaveChangesAsync();
            return Ok(await context.LibraryCards.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<LibraryCard>>> DelLibCard(int id)
        {
            var card = await context.LibraryCards.FindAsync(id);
            if (card == null)
                return BadRequest("Library card not found.");
            context.LibraryCards.Remove(card);
            await context.SaveChangesAsync();
            return Ok(await context.LibraryCards.ToListAsync());
        }
    }
}
