namespace CPSC_471_Library.Client.Services.CdvdService
{
    public interface ICdvdService
    {
        Task<List<CDVD>> GetCdvds();
        Task<CDVD> GetSingleCdvd(int id);
        Task RemoveCdvd(int id);
        Task UpdateCdvd(CDVD cdvd);
        Task<List<CDVD>> FilterCdvd(string filter);
    }
}
