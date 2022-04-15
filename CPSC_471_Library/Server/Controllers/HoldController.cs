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
        public async Task<ActionResult<List<Hold>>> AddHold(Hold hold)
        {
            context.Holds.Add(hold);
            await context.SaveChangesAsync();
            return Ok(await context.Holds.ToListAsync());
        }
    }
}
