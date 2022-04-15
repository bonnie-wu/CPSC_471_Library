namespace CPSC_471_Library.Client.Services.LibraryService
{
    public interface ILibraryService
    {
        List<Library> Libraries { get; set; }
        Task GetAllLibraries();
        Task<Library> GetSingleLibrary(int libID);
    }
}
