using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Usuario : EntityClass<Usuario>
    {
        public string Correo { get; set; }
        public string Hash { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [NotMapped]
        public List<Rol> Roles { get; set; }

        public Usuario()
        {
            Correo = "";
            Hash = "";
            Nombres = "";
            Apellidos = "";
        }
    }
}
