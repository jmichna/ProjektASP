using Data.Entities;

namespace ProjektASP.Models
{
    public interface ILibraryService
    {
        IEnumerable<Library> GetAllLibraries();
        Library GetLibraryById(int id);
        void AddLibrary(Library library);
        void UpdateLibrary(Library library);
        void DeleteLibrary(int id);
        List<LibraryEntity> FindAllPublishingHouseForViewModel();
    }
}
