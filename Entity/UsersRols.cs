using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UsersRols : EntityClass<UsersRols>
    {
        public int IdUser { get; set; }
        public int IdRole { get; set; }
    }
}
