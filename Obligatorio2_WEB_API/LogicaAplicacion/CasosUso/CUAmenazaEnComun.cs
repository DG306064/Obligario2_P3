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
    public class CUAmenazaEnComun : IAmenazaEnComun
    {
        public IRepositorioEspecie RepoEspecie { get; set; }
        public CUAmenazaEnComun(IRepositorioEspecie repo)
        {
            RepoEspecie = repo;
        }


        public Amenaza AmenazaENComun(int idEspecie, int idEcosistema)
        {
            return RepoEspecie.AmenazaEnComun(idEspecie, idEcosistema);
        }
    }
}
