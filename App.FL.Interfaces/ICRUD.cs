using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FL.Interfaces
{
    public interface ICRUD<T>
    {
        List<T> List();
        T Get(int id);
        bool Add(T obj);
        bool Update(T obj);
        bool Delete(T obj);
    }
}
