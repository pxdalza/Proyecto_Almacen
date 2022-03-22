using App.BL.BE;
using App.Dl.DALC;
using App.FL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.BC
{
    public class ProductoBC : ICRUD<ProductoBE>
    {
        private ProductoDALC productoDALC = new ProductoDALC();
        public bool Add(ProductoBE obj)
        {
            bool state = false;

            try
            {
                state = productoDALC.Add(obj);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return state;
        }

        public bool Delete(ProductoBE obj)
        {
            bool state = false;

            try
            {
                state = productoDALC.Delete(obj);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return state;
        }

        public ProductoBE Get(int id)
        {
            ProductoBE producto;
            
            try
            {
                producto = productoDALC.Get(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return producto;

        }

        public List<ProductoBE> List()
        {
            List<ProductoBE> productos;
            try
            {
                productos = productoDALC.List().OrderBy(x => x.Nombre).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return productos;
        }

        public bool Update(ProductoBE obj)
        {
            bool state = false;

            try
            {
                state = productoDALC.Update(obj);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return state;
        }
    }
}
