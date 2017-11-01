using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Model
{
    class ModelFactura
    {
        
        public  string cliente { set; get; }
        public  string[] producto { set; get; }
        public string cantidad { set; get; }
        public  string monto { set; get; }
        public  string fecha { set; get; }

    }
}
