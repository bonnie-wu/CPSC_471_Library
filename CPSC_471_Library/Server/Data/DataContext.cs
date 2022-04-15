using Microsoft.EntityFrameworkCore;

namespace CPSC_471_Library.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>().HasData(
                new Library { 
                    LibraryBranch = "Kanto", 
                    LibraryAddress = "124 Conch St. \n Kanto OC Y7U 6R3", 
                    Id = 010101, LibraryPhone = "(555)-0101" },
                new Library { LibraryBranch = "Emerald",
                    LibraryAddress = "308 Negra Arroyo Lane \n Emerald City ZZ R4V 2A5",
                    Id = 100100, LibraryPhone = "(555)-0188" },
                new Library { LibraryBranch = "Bedrock",
                    LibraryAddress = "1640 Riverside Drive \n Bedrock TA U0F 0O1",
                    Id = 129129,
                    LibraryPhone = "(555)-0123" },
                new Library { LibraryBranch = "Gravity Falls",
                    LibraryAddress = "31 Spooner Street \n Gravity Falls OR E4B 3C2",
                    Id = 727272,
                    LibraryPhone = "(555)-0145" },
                new Library { LibraryBranch = "Gotham",
                    LibraryAddress = "221B Baker St. \n Gotham NJ H9X 2D3",
                    Id = 101010,
                    LibraryPhone = "(555)-0100" },
                new Library { LibraryBranch = "Zion",
                    LibraryAddress = "742 Evergreen Terrace \n Zion AA T9P 1A7",
                    Id = 777777,
                    LibraryPhone = "(555)-0122" }
            );

            modelBuilder.Entity<LibraryEvent>().HasData(
                new LibraryEvent
                {
                    EventName = "Kids Reading Day",
                    Id = 1,
                    EventDate = new DateTime(2022, 4, 12, 17, 0, 0),
                    EventDuration = 1,
                    EventLibraryId = 010101
                },
                new LibraryEvent
                {
                    EventName = "Book Fair",
                    Id = 2,
                    EventDate = new DateTime(2022, 4, 4, 10, 0, 0),
                    EventDuration = 9,
                    EventLibraryId = 101010
                },
                new LibraryEvent
                {
                    EventName = "Tutoring Day",
                    Id = 3,
                    EventDate = new DateTime(2022, 4, 20, 16, 0, 0),
                    EventDuration = 2,
                    EventLibraryId = 100100
                },
                new LibraryEvent
                {
                    EventName = "Tutoring Day",
                    Id = 4,
                    EventDate = new DateTime(2022, 4, 20, 16, 0, 0),
                    EventDuration = 2,
                    EventLibraryId = 129129
                }
            );
        }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<LibraryEvent> LibraryEvents { get; set; }
        public DbSet<Library> Libraries {get; set; }
    }
}