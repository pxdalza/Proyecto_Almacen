using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.BE
{
    public class ProductoBE
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public String Categoria_Nombre { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public Decimal Precio { get; set; }
    }
}
