using DAL;
using Entity;
namespace BLL
{
    public class LibraryService
    {
        private readonly PruebaContext _context; 
        public LibraryService(PruebaContext context)
        {
            _context = context;
        }

        public async Task<Library> Guardar(Library library)
        {
            await _context.Libraries.AddAsync(library);
            return library;
        }
    }
}