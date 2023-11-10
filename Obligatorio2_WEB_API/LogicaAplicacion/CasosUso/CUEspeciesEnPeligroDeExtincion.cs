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

    public class CUEspeciesEnPeligroDeExtincion : IEspeciesEnPeligroDeExtincion
    {

        public IRepositorioEspecie RepoEspecie { get; set; }
        public CUEspeciesEnPeligroDeExtincion(IRepositorioEspecie repo)
        {
            RepoEspecie = repo;
        }

        public IEnumerable<Especie> EspeciesENPeligroDeExtincion()
        {
            return RepoEspecie.EspeciesEnPeligroDeExtincion();
        }
    }
}
