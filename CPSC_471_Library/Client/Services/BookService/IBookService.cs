namespace CPSC_471_Library.Client.Services.BookService
{
    public interface IBookService
    {

        Task<List<Book>> GetBooks();
        Task<Book> GetSingleBook(int id);
        Task RemoveBook(int id);
        Task UpdateBook(Book book);
        Task<List<Book>> FilterBook(string filter);
    }
}
