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

        [HttpGet("{title}/{no}")]
        public async Task<ActionResult<Loan>> GetLoan(string title, string no)
        {
            var loan = await context.Loans.FirstOrDefaultAsync(loan_ => !(loan_.Card_number != no || loan_.Title != title));
            if (loan == null)
                return BadRequest("No loan found.");
            return Ok(loan);
        }

        [HttpGet("card/{no}")]
        public async Task<ActionResult<List<Loan>>> Get(string no)
        {
            var loan = context.Loans.Where<Loan>(loan_ => loan_.Card_number == no);
            if (loan == null)
                return BadRequest("No loans found.");
            return Ok(await context.Loans.ToListAsync());
        }

        [HttpGet("date/{due}")]
        public async Task<ActionResult<List<Loan>>> GetByDueDate(string due)
        {
            var loan = context.Loans.Where<Loan>(loan_ => loan_.Due_date == due);
            if (loan == null)
                return BadRequest("No loans found.");
            return Ok(await context.Loans.ToListAsync());
        }

        [HttpPost]
        public async Task AddLoan(Loan loan)
        {
            context.Loans.Add(loan);
            await context.SaveChangesAsync();
        }

        [HttpDelete("{title}/{no}")]
        public async Task RemoveLoan(string title, string no)
        {
            var loan = await context.Loans.FirstOrDefaultAsync(loan_ => !(loan_.Card_number != no || loan_.Title != title));
            if (loan == null)
                return;
            context.Loans.Remove(loan);
            await context.SaveChangesAsync();
        }
    }
}
