using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Parametros;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioParametros : IRepositorio<Parametro>
    {
        string BuscarValorPorNombre(string nombre);
        Parametro BuscarParametroPorNombre(string nombre);
    }
}
