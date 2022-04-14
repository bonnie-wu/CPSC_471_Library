using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CPSC_471_Library.Client.Services.LibraryEventService
{
    public class LibraryEventService : ILibraryEventService
    {
        private readonly HttpClient http;

        public LibraryEventService(HttpClient http)
        {
            this.http = http;
        }

        public List<LibraryEvent> LibEvents { get; set; } = new List<LibraryEvent>();

        public async Task getAllEvents()
        {
            var result = await http.GetFromJsonAsync<List<LibraryEvent>>("/api/Event");
            if(result != null)
            {
                LibEvents = result;
            }
        }

        public Task<LibraryEvent> getSingleEvent(int eventid)
        {
            throw new NotImplementedException();
        }
    }
}
