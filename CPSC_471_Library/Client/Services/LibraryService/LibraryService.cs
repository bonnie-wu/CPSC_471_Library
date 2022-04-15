using System.Net.Http.Json;

namespace CPSC_471_Library.Client.Services.LibraryService
{
    public class LibraryService : ILibraryService
    {
        private readonly HttpClient _http;

        public LibraryService(HttpClient http)
        {
            _http = http;
        }

        public List<Library> Libraries { get; set; }

        public async Task GetAllLibraries()
        {
            var result = await _http.GetFromJsonAsync<List<Library>>("/api/Library");
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
