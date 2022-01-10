using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure;

namespace BLL
{
    public class LoginService
    {
        private readonly ServiceContext _context;
        public LoginService(PruebaContext context)
        {
            _context = new ServiceContext(context);
        }

        public async Task<ResponseClass<Usuario>> Login(string correo, string password)
        {
            try
            {
                var response = await _context.GetUsuerAsync(correo);
                
                if (response != null)
                {
                    response.Roles = await _context.GetRolesAsync(response.Id);
                    var verify = HashPassword.Verify(password, response.Hash);
                    if(verify) { return new ResponseClass<Usuario>(response); }
                    return new ResponseClass<Usuario>("Contraseña incorrecta");
                }
                return new ResponseClass<Usuario>("No existe el usuario");
            }
            catch (Exception ex)
            {
                return new ResponseClass<Usuario>($"Error en la aplicacion: {ex.Message}");
            }
        }

        public async Task<ResponseClass<Rol>> GetRolesByName(string role)
        {
            try
            {
                var response = await _context.GetRoleByNameAsync(role);
                if( response != null)
                {
                    return new ResponseClass<Rol>(response);
                }
                return new ResponseClass<Rol>("No existe el rol");
            }
            catch (Exception ex)
            {
                return new ResponseClass<Rol>($"Error en la aplicacion: {ex.Message}");
            }
        }
    }
}
