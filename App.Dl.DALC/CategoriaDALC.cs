using App.BL.BE;
using App.FL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Dl.DALC
{
    public class CategoriaDALC : ICRUD<CategoriaBE>
    {
        private String cnxStr = ConfigurationManager.ConnectionStrings["cnxString"].ConnectionString;

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
            List<CategoriaBE> list = new List<CategoriaBE>();

            try
            {

                using (SqlConnection cn = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("SP_GET_Category", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 700;
                    cn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        CategoriaBE categoriaBE = new CategoriaBE();
                        categoriaBE.CategoriaId = dr.GetInt32(dr.GetOrdinal("CategoriaId"));
                        categoriaBE.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                        list.Add(categoriaBE);
                    }
                    cn.Close();

                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return list;
        }

        public bool Update(CategoriaBE obj)
        {
            throw new NotImplementedException();
        }
    }
}
