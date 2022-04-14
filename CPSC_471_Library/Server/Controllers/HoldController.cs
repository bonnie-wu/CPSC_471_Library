using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPSC_471_Library.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoldController : ControllerBase
    {
        private DataContext context;

        public HoldController(DataContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Hold>>> Get()
        {
            return Ok(await context.Holds.ToListAsync());
        }

        [HttpPost]
        public async Task AddCard(Hold hold)
        {
            context.Holds.Add(hold);
            await context.SaveChangesAsync();
        }

        /*[HttpDelete("{title, card_number}")]
        public async Task<ActionResult<List<Book>>> Del(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
                return BadRequest("Library card not found.");
            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return Ok(await context.Books.ToListAsync());
        }*/
    }
}
