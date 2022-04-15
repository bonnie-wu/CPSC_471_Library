using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPSC_471_Library.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactFormController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactForm>>> Get()
        {
            return Ok(await _context.ContactForms.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<ContactForm>> CreateContactForm(ContactForm contactform)
        {
            _context.ContactForms.Add(contactform);
           await _context.SaveChangesAsync();

            return Ok(contactform);
        }

    }
}
