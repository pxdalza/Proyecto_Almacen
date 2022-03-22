using App.BL.BE;
using App.UI.WF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UI.WF.UTIL
{
    public static class Util_Cast
    {
        public static ProductoBE ConvertirFromViewModelToBE(ProductoViewModel obj)
        {
            return new ProductoBE
            {
                ProductoId = obj.ProductoId,
                Descripcion = obj.Descripcion,
                Nombre = obj.Nombre,
                Precio = obj.Precio
            };
        }
    }
}
