using Microsoft.EntityFrameworkCore;

namespace CPSC_471_Library.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Book> Books => Set<Book>();
    }
}
