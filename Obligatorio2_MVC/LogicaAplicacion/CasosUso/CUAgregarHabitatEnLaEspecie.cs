using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUAgregarHabitatEnLaEspecie : IAgregarHabitatEnLaEspecie
    {
        public IRepositorioEspecie RepoEspecie { get; set; }

        public CUAgregarHabitatEnLaEspecie(IRepositorioEspecie Repoespecie)
        {
            RepoEspecie = Repoespecie;
        }


        public void AgregarHabitatEnLaEspecie(int idEspecie, int idHabitat)
        {
            RepoEspecie.AgregarHabitatEnLaEspecie(idEspecie, idHabitat);
        }
    }
}
