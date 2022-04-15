using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace CPSC_471_Library.Client.Services.BookService
{
    public class BookService : IBookService
    {
        private HttpClient http;
        private NavigationManager navigationManager;

        public BookService(HttpClient http, NavigationManager navigationManager)
        {
            this.http = http;
            this.navigationManager = navigationManager;
        }

        public HttpClient Http { get; }

        public async Task<List<Book>> GetBooks()
        {
            var result = await http.GetFromJsonAsync<List<Book>>("api/Book");
            if (result != null)
                return result;
            throw new Exception("No books");
        }

        public async Task<Book> GetSingleBook(int id)
        {
            var result = await http.GetFromJsonAsync<Book>($"api/Book/{id}");
            if (result != null)
                return result;
            throw new Exception("Book not found.");
        }

        // This is for staff ui
        public async Task RemoveBook(int id)
        {
            var result = await http.DeleteAsync($"api/Book/{id}");
            if (result != null)
            {
                await GetBooks();
                navigationManager.NavigateTo("browse");
            }   
        }


        public async Task UpdateBook(Book book)
        {
            await http.PutAsJsonAsync<Book>($"api/Book", book);
        }

        public async Task<List<Book>> FilterBook(string filter)
        {
            var result = await http.GetFromJsonAsync<List<Book>>($"api/Book/f/{filter}");
            if (result != null)
                return result;
            throw new Exception("No books");
        }
    }
}
