using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class ServiceContext
    {
        private readonly PruebaContext _context;

        public ServiceContext(PruebaContext context)
        {   
            _context = context;
        }

        public async Task<int> AddAsync<T>(T entity)
        {
            await _context.AddAsync(entity!);
            await _context.AddAsync(new Log() { Action = "Insertar" });
            return (await _context.SaveChangesAsync());
        }

        public async Task<List<Library>> GetAsyncLibraries<T>()
        {
            return (await _context.Libraries.ToListAsync());
        }

        public async Task<Library?> GetAsyncLibrary<T>(int id)
        {
            return await _context.Libraries.FindAsync(id);
        }

        public async Task<int> UpdateAsync<T>(T entity)
        {
            _context.Update(entity!);
            await _context.AddAsync(new Log() { Action = "Actualizar" });
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync<T>(T entity)
        {
            _context.Remove(entity!);
            await _context.AddAsync(new Log() { Action = "Eliminar" });
            return await (_context.SaveChangesAsync());
        }

        public async Task<Usuario> GetUsuerAsync(string correo)
        {
            return await _context.Users.Where(u => u.Correo == correo).FirstAsync();
        }

        public async Task<List<Rol>> GetRolesAsync(int idUser)
        {
            var rolesUsers = await _context.UsersRols.Where(r => r.IdUser == idUser).ToListAsync();
            var listRoles = new List<Rol>();
            foreach (var role in rolesUsers)
            {
                var rol = await _context.Roles.FindAsync(role.IdRole);
                var permisosRol = await _context.PermisosRols.Where(p => p.IdRole == role.IdRole).ToListAsync();
                var listPermisos = new List<Permiso>();
                foreach (var permiso in permisosRol)
                {
                    var permisoRol = await _context.Permisos.FindAsync(permiso.IdPermiso);
                    listPermisos.Add(permisoRol!);
                }
                rol!.Permisos = listPermisos;
                listRoles.Add(rol);
            }
            return listRoles;
        }

        public async Task<Rol> GetRoleByNameAsync(string role)
        {
            var rol = await _context.Roles.Where(r => r.Nombre == role).FirstAsync();
            var permisosRol = await _context.PermisosRols.Where(p => p.IdRole == rol.Id).ToListAsync();
            var listPermisos = new List<Permiso>();
            foreach (var permiso in permisosRol)
            {
                var permisoRol = await _context.Permisos.FindAsync(permiso.IdPermiso);
                listPermisos.Add(permisoRol!);
            }
            rol!.Permisos = listPermisos;
            return rol;
        }
    }
}
