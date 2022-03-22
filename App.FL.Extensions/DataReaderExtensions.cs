using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FL.Extensions
{
    public static class DataReaderExtensions
    {
        //Indicamos si el valor de la columna es null
        public static bool IsDBNull(this IDataReader dr, string columnName)
        {
            return dr[columnName] == DBNull.Value;
        }
        //indicamos que la columna existe
        public static bool ContainsColumn(this IDataReader dr, string columnName)
        {
            try
            {
                return dr.GetOrdinal(columnName) >= 0;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
    }
}
