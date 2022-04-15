using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPSC_471_Library.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private DataContext context;

        public LoanController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Loan>>> Get()
        {
            return Ok(await context.Loans.ToListAsync());
        }

        [HttpGet("{type}/{title}/{no}")]
        public async Task<ActionResult<Loan>> GetLoan(string type, string title, string no)
        {
            var loan = await context.Loans.FirstOrDefaultAsync(loan_ => !(loan_.Card_number != no || loan_.Title != title) && loan_.Type == type);
            if (loan == null)
                return BadRequest("No loan found.");
            return Ok(loan);
        }

        [HttpPost]
        public async Task<ActionResult<List<Loan>>> AddLoan(Loan loan)
        {
            context.Loans.Add(loan);
            await context.SaveChangesAsync();
            return Ok(await context.Loans.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Loan>>> RemoveLoan(int id)
        {
            var loan = await context.Loans.FindAsync(id);
            if (loan == null)
                return BadRequest("No such loan");
            context.Loans.Remove(loan);
            await context.SaveChangesAsync();
            return Ok(await context.Loans.ToListAsync());
        }
    }
}
