using System.Net.Http.Json;

namespace CPSC_471_Library.Client.Services.LibraryService
{
    public class LibraryService : ILibraryService
    {
        private readonly HttpClient http;

        public LibraryService(HttpClient http)
        {
            this.http = http;
        }

        public List<Library> Libraries { get; set; }

        public async Task GetAllLibraries()
        {
            var result = await http.GetFromJsonAsync<List<Library>>("/api/Library");
            if (result != null)
            {
                Libraries = result;
            }
        }

        public Task<Library> GetSingleLibrary(int libID)
        {
            throw new NotImplementedException();
        }
    }
}
