using Data.Entities;
using ProjektASP.Models;

namespace ProjektASP.Mappers
{
    public class LibraryMapper
    {
        public static Library FromEntity(LibraryEntity entity)
        {
            return new Library()
            {
                Id = entity.Id,
                Title = entity.Title,
                Autor = entity.Autor,
                PageNumber = entity.PageNumber,
                ISBN = entity.ISBN,
                DateOfRelease = entity.DateOfRelease,
                Rating = entity.Rating,
            };
        }

        public static LibraryEntity ToEntity(Library model)
        {
            return new LibraryEntity()
            {
                Id = model.Id,
                Title = model.Title,
                Autor = model.Autor,
                PageNumber = model.PageNumber,
                ISBN = model.ISBN,
                DateOfRelease = model.DateOfRelease,
                Rating = model.Rating
            };
        }
    }
}
