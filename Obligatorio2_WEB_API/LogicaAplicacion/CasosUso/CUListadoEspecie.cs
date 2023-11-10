using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoEspecie : IListadoEspecie
    {
        public IRepositorioEspecie RepoEspecie { get; set; }
        public CUListadoEspecie(IRepositorioEspecie repo)
        {
            RepoEspecie = repo;
        }


        public IEnumerable<Especie> Listado()
        {
            return RepoEspecie.FindAll();

        }
    }
}
 
 




