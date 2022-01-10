using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PermisosRol : EntityClass<PermisosRol>
    {
        public int IdRole { get; set; }
        public int IdPermiso { get; set; }
    }
}
