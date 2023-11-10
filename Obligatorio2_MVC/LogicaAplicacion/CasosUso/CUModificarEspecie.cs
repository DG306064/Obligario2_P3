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
    public class CUModificarEspecie : IModificarEspecie
    {
        public IRepositorioEspecie RepoEspecie { get; set; }

        public CUModificarEspecie(IRepositorioEspecie repoEspecie)
        {
            RepoEspecie = repoEspecie;
        }

        public void ModificarEspecie(Especie obj)
        {
            RepoEspecie.Update(obj);
        }
    }
}
