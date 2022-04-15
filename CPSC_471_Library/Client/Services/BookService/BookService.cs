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

        /*public async Task RemoveCDVD(int id)
        {
            await http.DeleteAsync($"api/CDVD/{id}");
        }*/

        public async Task UpdateBook(Book book)
        {
            await http.PutAsJsonAsync<Book>($"api/Book", book);
        }

        /*public async Task UpdateCDVD(CDVD cdvd)
        {
            await http.PutAsJsonAsync<CDVD>($"api/CDVD", cdvd);
        }*/
    }
}
