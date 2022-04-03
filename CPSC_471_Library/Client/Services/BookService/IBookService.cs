namespace CPSC_471_Library.Client.Services.BookService
{
    public interface IBookService
    {
        List<Book> Books { get; set; }

        Task GetBooks();
        Task<Book> GetSingleBook(int id);
    }
}
