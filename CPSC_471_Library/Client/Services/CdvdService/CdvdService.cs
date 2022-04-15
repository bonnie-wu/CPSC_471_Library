using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace CPSC_471_Library.Client.Services.CdvdService
{
    public class CdvdService : ICdvdService
    {
        private HttpClient http;
        private NavigationManager navigationManager;

        public CdvdService(HttpClient http, NavigationManager navigationManager)
        {
            this.http = http;
            this.navigationManager = navigationManager;
        }

        public HttpClient Http { get; }

        public async Task<List<CDVD>> GetCdvds()
        {
            var result = await http.GetFromJsonAsync<List<CDVD>>("api/Cdvd");
            if (result != null)
                return result;
            throw new Exception("No CD/DVD's");
        }

        public async Task<CDVD> GetSingleCdvd(int id)
        {
            var result = await http.GetFromJsonAsync<CDVD>($"api/Cdvd/{id}");
            if (result != null)
                return result;
            throw new Exception("CD/DVD not found.");
        }

        // This is for staff ui
        public async Task RemoveCdvd(int id)
        {
            var result = await http.DeleteAsync($"api/Cdvd/{id}");
            if (result != null)
            {
                navigationManager.NavigateTo("browse");
            }   
        }


        public async Task UpdateCdvd(CDVD Cdvd)
        {
            await http.PutAsJsonAsync<CDVD>($"api/Cdvd", Cdvd);
        }

    }
}
