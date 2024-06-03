using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudWPF.BLL
{
    class productosBLL
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public string fechaIngreso { get; set; }

        public int proveedor { get; set; } 
    }
}
