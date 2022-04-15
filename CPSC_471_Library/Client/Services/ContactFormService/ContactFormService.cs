using System.Net.Http.Json;

namespace CPSC_471_Library.Client.Services.ContactFormService
{
    public class ContactFormService : IContactFormService
    {
        private readonly HttpClient _http;

        public ContactFormService(HttpClient http)
        {
            _http = http;
        }
        public List<ContactForm> SubmittedContactForms { get; set; }

        public async Task CreateContactForm(ContactForm contactform)
        {
            var result = await _http.PostAsJsonAsync("api/ContactForm", contactform);
        }
    }
}
