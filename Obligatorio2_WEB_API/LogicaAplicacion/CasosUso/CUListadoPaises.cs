using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoPaises : IListadoPaises
    {
        public IRepositorioPais RepoPais { get; set; }

        public CUListadoPaises(IRepositorioPais repoPais)
        {
            RepoPais = repoPais;
        }



        public IEnumerable<Pais> Listado()
        {
            return RepoPais.FindAll();
        }
    }
}
