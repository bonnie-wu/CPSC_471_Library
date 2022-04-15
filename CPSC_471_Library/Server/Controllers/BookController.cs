using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPSC_471_Library.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {

        };
        private DataContext context;

        public BookController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            return Ok(await context.Books.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
                return BadRequest("Book not found.");
            return Ok(book);
        }

        [HttpGet("books/{title}")]
        public async Task<ActionResult<Book>> GetBookByTitle(string title)
        {
            var book = await context.Books.SingleOrDefaultAsync(book_ => book_.Title == title);
            if (book == null)
                return BadRequest("Book not found.");
            return Ok(book);
        }

        [HttpGet("f/{genre}")]
        public async Task<ActionResult<List<Book>>> GetBooksByGenre(string genre)
        {
            var book = context.Books.Where<Book>(_book => _book.Genre == genre);
            if (book == null)
                return BadRequest("Book not found.");
            return Ok(await book.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();
            return Ok(await context.Books.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Book>>> UpdateBook(Book request)
        {
            var book = await context.Books.FindAsync(request.Id);
            if (book == null)
                return BadRequest("Book not found.");
            book.Title = request.Title;
            book.Location = request.Location;
            book.Author = request.Author;
            book.Copies = request.Copies;
            book.Distribution = request.Distribution;
            book.Genre = request.Genre;
            book.Publisher = request.Publisher;

            await context.SaveChangesAsync();

            return Ok(await context.Books.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> Del(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
                return BadRequest("Book not found.");
            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return Ok(await context.Books.ToListAsync());
        }
    }
}
