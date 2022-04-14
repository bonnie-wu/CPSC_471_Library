using Microsoft.EntityFrameworkCore;

namespace CPSC_471_Library.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Book> Books => Set<Book>();

        public DbSet<LibraryCard> LibraryCards { get; set; }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Hold> Holds { get; set; }
    }
}
