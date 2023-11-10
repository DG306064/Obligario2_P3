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
        public IRepositorio<Pais> RepoPais { get; set; }

        public CUListadoPaises(IRepositorio<Pais> repoPais)
        {
            RepoPais = repoPais;
        }



        public IEnumerable<Pais> Listado()
        {
            return RepoPais.FindAll();
        }
    }
}
