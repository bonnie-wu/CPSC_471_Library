using System.Net.Http.Json;

namespace CPSC_471_Library.Client.Services.BookService
{
    public class BookService : IBookService
    {
        private HttpClient http;

        public BookService(HttpClient http)
        {
            this.http = http;
        }

        public List<Book> Books { get; set; } = new List<Book>();
        public HttpClient Http { get; }

        public async Task GetBooks()
        {
            var result = await http.GetFromJsonAsync<List<Book>>("api/Book");
            if (result != null)
                Books = result;
        }

        public async Task<Book> GetSingleBook(int id)
        {
            var result = await http.GetFromJsonAsync<Book>($"api/Book/{id}");
            if (result != null)
                return result;
            throw new Exception("Book not found.");
        }
    }
}
