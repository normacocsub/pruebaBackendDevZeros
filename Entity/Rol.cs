using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Rol : EntityClass<Rol>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [NotMapped]
        public List<Permiso> Permisos { get; set; }
    }
}
