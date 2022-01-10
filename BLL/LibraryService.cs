using DAL;
using Entity;
namespace BLL
{
    public class LibraryService
    {
        private readonly ServiceContext _context;
        public LibraryService(PruebaContext context)
        {
            _context = new ServiceContext(context);
        }

        public async Task<ResponseClass<Library>> Guardar(Library library)
        {
            try
            {
                await _context.AddAsync(library);
                return new ResponseClass<Library>(library);
            }
            catch(Exception ex)
            {
                return new ResponseClass<Library>($"Error en la aplicacion: {ex.Message}");
            }
        }

        public async Task<ResponseClass<Library>> GetLibraries()
        {
            try
            {
                return new ResponseClass<Library>(await _context.GetAsyncLibraries<Library>());
            }
            catch (Exception ex)
            {
                return new ResponseClass<Library>($"Error en la aplicacion: {ex.Message}");
            }
        }

        public async Task<ResponseClass<Library>> GetLibrary(int id)
        {
            try
            {
                var response = await _context.GetAsyncLibrary<Library>(id);
                if(response is null)
                {
                    return new ResponseClass<Library>($"No existe el libro");
                }
                return new ResponseClass<Library>(response);
            }
            catch (Exception ex)
            {
                return new ResponseClass<Library>($"Error en la aplicacion: {ex.Message}");
            }
        }

        public async Task<ResponseClass<Library>> UpdateLibrary(Library library, int id)
        {
            try
            {
                var libraryResponse = await _context.GetAsyncLibrary<Library>(id);
                if (libraryResponse != null)
                {
                    libraryResponse.Title = library.Title;
                    libraryResponse.Author = library.Author;
                    libraryResponse.Publisher = library.Publisher;
                    libraryResponse.Genre = library.Genre;
                    libraryResponse.Price = library.Price;
                    libraryResponse.FechaModificacion = DateTime.Now;
                    await _context.UpdateAsync<Library>(libraryResponse);
                    return new ResponseClass<Library>(library);
                }
                return new ResponseClass<Library>("No se encuentra el libro");
            }
            catch(Exception ex)
            {
                return new ResponseClass<Library>($"Error en la aplicacion: {ex.Message}");
            }
        }

        public async Task<ResponseClass<Library>> DeleteLibrary(int id)
        {
            try
            {
                var libraryResponse = await _context.GetAsyncLibrary<Library>(id);
                if(libraryResponse != null)
                {
                    await _context.DeleteAsync(libraryResponse);
                    return new ResponseClass<Library>(libraryResponse);
                }
                return new ResponseClass<Library>("No se encuentra el libro");
            }
            catch(Exception ex)
            {
                return new ResponseClass<Library>($"Error en la aplicacion: {ex.Message}");
            }
        }
    }
}