using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UI.WF.ViewModel
{
    public class ProductoViewModel
    {
        public int ProductoId { get; set; }
        public String Nombre { get; set; }
        public String Categoria { get; set; }
        public String Descripcion { get; set; }
        public Decimal Precio { get; set; }
    }
}
