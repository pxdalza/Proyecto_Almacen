using App.BL.BE;
using App.FL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using App.FL.Extensions;

namespace App.Dl.DALC
{
    public class ProductoDALC : ICRUD<ProductoBE>
    {


        private String cnxStr = ConfigurationManager.ConnectionStrings["cnxString"].ConnectionString;

        public bool Add(ProductoBE obj)
        {

            bool state = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd= new SqlCommand("SP_Insert_Product", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;
                    //se agregan parametros
                    AddParameters(ref cmd, obj);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    state = true;
                    cn.Close();
                }
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

            using (SqlConnection cn = new SqlConnection(cnxStr))
            {

                SqlCommand cmd = new SqlCommand("SP_Delete_Product", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 600;
                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = obj.ProductoId;

                cn.Open();
                
                cmd.ExecuteNonQuery();
                state = true;
                cn.Close();
                
            }

            return state;
        }

        public ProductoBE Get(int id)
        {
            ProductoBE producto = new ProductoBE();

            try
            {

                using (SqlConnection cn = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("SP_GET_Product", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 700;

                    cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = id;

                    cn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        producto = ReadData(dr);
                    }

                    cn.Close();

                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return producto;
        }

        public List<ProductoBE> List()
        {
            List<ProductoBE> list = new List<ProductoBE>();

            try
            {

                using (SqlConnection cn = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("SP_List_Product", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 700;
                    cn.Open();

                    SqlDataReader  dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        list.Add(ReadData(dr));
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

        public bool Update(ProductoBE obj)
        {
            bool state = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("SP_Update_Product", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;
                    //se agregan parametros
                    cmd.Parameters.Add("@ProductoId", SqlDbType.Int).Value = obj.ProductoId;
                    AddParameters(ref cmd, obj);


                    cn.Open();
                    cmd.ExecuteNonQuery();
                    state = true;
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return state;
        }

        private ProductoBE ReadData(SqlDataReader dr)
        {
            ProductoBE producto = new ProductoBE();

            producto.ProductoId = dr.GetInt32(dr.GetOrdinal("ProductoId"));
            producto.Nombre = dr.GetString(dr.GetOrdinal("Nombe"));

            var isExist = dr.ContainsColumn("CategoriaId");
            producto.CategoriaId = (isExist) ? dr.GetInt32(dr.GetOrdinal("CategoriaId")) : 0;

            producto.Categoria_Nombre = dr.GetString(dr.GetOrdinal("Categoria"));
            producto.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"));
            producto.Precio = dr.GetDecimal(dr.GetOrdinal("Precio"));

            return producto;
        }

        private void AddParameters(ref SqlCommand cmd, ProductoBE obj)
        {
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = obj.Nombre;
            cmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = obj.CategoriaId;
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
            cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = obj.Precio;
        }
    }
}
