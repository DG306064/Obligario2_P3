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
    public class CUBuscarEspeciePorId : IBuscarEspeciePorId
    {
        public IRepositorioEspecie RepoEspecie { get; set; }

        public CUBuscarEspeciePorId(IRepositorioEspecie repoEspecie)
        {
            RepoEspecie = repoEspecie;
        }

        public Especie Buscar(int id)
        {
            return RepoEspecie.FindById(id);
        }
    }
}
