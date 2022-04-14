using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPSC_471_Library.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private DataContext context;

        public StaffController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Staff>>> Get()
        {
            return Ok(await context.Staffs.ToListAsync());
        }

        [HttpGet("{num}")]
        public async Task<ActionResult<Staff>> Get(string num)
        {
            var staff = await context.Staffs.FirstOrDefaultAsync(staff_ => staff_.Staff_num == num);
            if (staff == default(Staff))
                return BadRequest("Staff member not found.");
            return Ok(staff);
        }

        [HttpPost]
        public async Task<ActionResult<List<Staff>>> AddStaff(Staff staff)
        {
            context.Staffs.Add(staff);
            await context.SaveChangesAsync();
            return Ok(await context.Staffs.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Staff>>> DelStaff(int id)
        {
            var staff = await context.Staffs.FindAsync(id);
            if (staff == null)
                return BadRequest("Staff member not found.");
            context.Staffs.Remove(staff);
            await context.SaveChangesAsync();
            return Ok(await context.Staffs.ToListAsync());
        }
    }
}
