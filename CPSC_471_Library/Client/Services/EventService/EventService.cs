using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace CPSC_471_Library.Client.Services.EventService
{
    public class EventService : IEventService
    {
        private readonly HttpClient http;

        public EventService(HttpClient http)
        {
            this.http = http;
        }

        public List<Event> Events { get; set; } = new List<Event>();

        public HttpClient Http { get; }
        public async Task GetEvents()
        {
            var result = await http.GetFromJsonAsync<List<Event>>("api/Events");
            if (result != null)
            {
                Events = result;
            }
            
        }

        public async Task<Event> GetSingleEvent(int EventId)
        {
            var result = await http.GetFromJsonAsync<Event>($"api/Events/{EventId}");
            if (result != null)
                return result;
            throw new Exception("Sorry, Event not found.");
        }
    }
}
