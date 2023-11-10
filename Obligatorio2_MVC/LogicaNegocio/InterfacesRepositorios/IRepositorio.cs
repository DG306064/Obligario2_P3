using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T>
    {

        void Add(T obj);
        void remove(T obj);
        void Update(T obj);
        IEnumerable<T> FindAll();
        T FindById(int id);

    }
}
