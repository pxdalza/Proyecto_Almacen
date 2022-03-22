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
    public class CategoriaBC : ICRUD<CategoriaBE>
    {
        private CategoriaDALC categoriaDALC = new CategoriaDALC();

        public bool Add(CategoriaBE obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(CategoriaBE obj)
        {
            throw new NotImplementedException();
        }

        public CategoriaBE Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoriaBE> List()
        {
            List<CategoriaBE> categorias;

            try
            {
                categorias = categoriaDALC.List();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return categorias;
        }

        public bool Update(CategoriaBE obj)
        {
            throw new NotImplementedException();
        }
    }
}
