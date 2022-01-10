using Entity;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using Infraestructure;

namespace DAL
{
    public class PruebaContext : DbContext
    {
        public PruebaContext(DbContextOptions options) : base(options) { }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Usuario> Users { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<PermisosRol> PermisosRols { get; set; }
        public DbSet<UsersRols> UsersRols { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {

            model.Entity<UsersRols>()
                .HasOne<Rol>().WithMany()
                .HasForeignKey(u => u.IdRole);

            model.Entity<UsersRols>()
                .HasOne<Usuario>().WithMany()
                .HasForeignKey(u => u.IdUser);

            model.Entity<PermisosRol>()
                .HasOne<Rol>().WithMany()
                .HasForeignKey(r => r.IdRole);

            model.Entity<PermisosRol>()
                .HasOne<Permiso>().WithMany()
                .HasForeignKey(u => u.IdPermiso);

            model.Entity<Library>()
                .HasData(GetLibraries());
            model.Entity<Usuario>()
                .HasData(GetUsers());
            model.Entity<Rol>()
                .HasData(GetRoles());
            model.Entity<Permiso>()
                .HasData(GetPermisos());
            model.Entity<PermisosRol>()
                .HasData(GetPermisosRols());
            model.Entity<UsersRols>()
                .HasData(GetUsersRols());
        }

        public List<UsersRols> GetUsersRols()
        {
            var lista = new List<UsersRols>();
            lista.Add(new UsersRols()
            {
                Id = 1,
                IdRole = 1,
                IdUser = 1
            });
            return lista;
        }
        public List<PermisosRol> GetPermisosRols()
        {
            var lista = new List<PermisosRol>();
            lista.Add(new PermisosRol()
            {
                Id = 1,
                IdPermiso = 1,
                IdRole = 1
            });
            lista.Add(new PermisosRol()
            {
                Id = 2,
                IdPermiso = 2,
                IdRole = 1
            });
            lista.Add(new PermisosRol()
            {
                Id = 3,
                IdPermiso = 3,
                IdRole = 1
            });
            lista.Add(new PermisosRol()
            {
                Id = 4,
                IdPermiso = 4,
                IdRole = 1
            });
            return lista;
        }
        public List<Permiso> GetPermisos()
        {
            var permisos = new List<Permiso>();
            permisos.Add(new Permiso()
            {
                Id = 1,
                Nombre = "GuardarLibro",
                Descripcion = "Permiso para guardar libros",
            });
            permisos.Add(new Permiso()
            {
                Id = 2,
                Nombre = "BuscarLibro",
                Descripcion = "Permiso para Buscar Libros",
            });
            permisos.Add(new Permiso()
            {
                Id = 3,
                Nombre = "ActualizarLibro",
                Descripcion = "Permiso para Actualizar Libros",
            });
            permisos.Add(new Permiso()
            {
                Id = 4,
                Nombre = "EliminarLibro",
                Descripcion = "Permiso para Eliminar Libros",
            });
            return permisos;
        }
        public List<Rol> GetRoles()
        {
            var roles = new List<Rol>();
            roles.Add(new Rol() { Id = 1, Nombre = "Administrador", Descripcion = "Rol con privilegios" });
            return roles;
        }
        public List<Usuario> GetUsers()
        {
            var list = new List<Usuario>();
            list.Add(new Usuario()
            {
                Id = 1,
                Correo = "Admin@gmail.com",
                Hash = HashPassword.Hash("Admin"),
                Nombres = "Fernando",
                Apellidos = "Vega"
            });
            return list;
        }

        public List<Library> GetLibraries()
        {
            var list = new List<Library>();
            list.Add(new Library()
            {
                Id = 1,
                Title = "The Monk Who Sold His Ferrari",
                Author = "Robin Sharma",
                Publisher = "Jaiko Publishing House",
                Genre = "Fiction",
                Price = 141
            });
            list.Add(new Library()
            {
                Id = 2,
                Title = "The Theory Of Everything",
                Author = "Stephen W Hawking",
                Publisher = "Jaiko Publishing House",
                Genre = "Engineering & Technology",
                Price = 149
            });
            list.Add(new Library()
            {
                Id = 3,
                Title = "Rich Dad Poor Dad",
                Author = "Robert T. Kiyosaki",
                Publisher = "Plata Publishing",
                Genre = "Personal Finance",
                Price = 288
            });
            return list;
        }
    }

}