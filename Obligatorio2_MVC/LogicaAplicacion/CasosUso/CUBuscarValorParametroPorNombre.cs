using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBuscarValorParametroPorNombre : IBuscarValorParametroPorNombre
    {
        IRepositorioParametros RepositorioParametros { get; set; }

        public CUBuscarValorParametroPorNombre(IRepositorioParametros repositorio)
        {
            RepositorioParametros = repositorio;
        }
        public string BuscarValorParametroPorNombre(string nombre)
        {
            return RepositorioParametros.BuscarValorPorNombre(nombre);
        }
    }
}
