using Data.Entities;
using ProjektASP.Mappers;

namespace ProjektASP.Models
{
    public class EFLibraryService : ILibraryService
    {
        private AppDbContext _context;

        public EFLibraryService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Library> GetAllLibraries()
        {
            return _context.Library.Select(e => LibraryMapper.FromEntity(e)).ToList();
        }

        public Library GetLibraryById(int id)
        {
            return LibraryMapper.FromEntity(_context.Library.Find(id));
        }

        public void AddLibrary(Library library)
        {
            var e = _context.Library.Add(LibraryMapper.ToEntity(library));
            _context.SaveChanges();
        }

        public void UpdateLibrary(Library library)
        {
            _context.Library.Update(LibraryMapper.ToEntity(library));
            _context.SaveChanges();
        }

        public void DeleteLibrary(int id)
        {
            LibraryEntity? find = _context.Library.Find(id);
            if ( find != null)
            {
                _context.Library.Remove(find);
            }
        }

        public List<LibraryEntity> FindAllPublishingHouseForViewModel()
        {
            return _context.Library.ToList();
        }
    }
}
