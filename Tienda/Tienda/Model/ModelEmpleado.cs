using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tienda.Model
{
    class ModelEmpleado
    {

        public  int id { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }
        public string cedula { set; get; }
        public string direccion { set; get; }
        public int edad { set; get; }
        public string telefono { set; get; }
        public string correo { set; get; }
    }
}
