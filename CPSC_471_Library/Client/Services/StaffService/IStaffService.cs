namespace CPSC_471_Library.Client.Services.StaffService
{
    public interface IStaffService
    {
        public List<Staff> Staffs { get; set; }
        public List<LibraryCard> Cards { get; set; }
        public List<Hold> Holds { get; set; }
        public List<Loan> Loans { get; set; }

        Task<Staff> GetStaffMember(string num);
        Task<LibraryCard> AddLibraryCard(LibraryCard card);

        Task GetLibraryCards();
        Task<Book> AddBook(Book book);
        Task<Book> GetBook(string title);
        Task<string> AddLoan(Loan loan);
        Task GetStaff();
        Task GetLoans();
        Task<Staff> AddStaff(Staff staff);
        Task HoldItem(Hold hold);
        Task GetHolds();
        Task<string> RemoveLoan(string num, string title);
        Task<string> RemoveStaff(string num);
        Task<string> RemoveCard(string num);
    }
}
