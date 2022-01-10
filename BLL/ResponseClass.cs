using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ResponseClass<T>
    {
        public ResponseClass(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

        public ResponseClass(T entity)
        {
            Error = false;
            Objeto = entity;
        }

        public ResponseClass(List<T> objects)
        {
            Error = false;
            Objects = objects;
        }
        public bool Error { get; set; }
        public string? Mensaje { get; set; }
        public T? Objeto { get; set; }
        public List<T>? Objects { get; set; }
    }
}
