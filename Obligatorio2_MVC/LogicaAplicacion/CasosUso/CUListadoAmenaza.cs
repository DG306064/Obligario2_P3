using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoAmenaza : IListadoAmenaza
    {
        public IRepositorioAmenaza RepoAmenaza { get; set; }

        public CUListadoAmenaza(IRepositorioAmenaza repoAmenaza)
        {
            RepoAmenaza = repoAmenaza;
        }


        public IEnumerable<Amenaza> ListadoAmenaza()
        {
            return RepoAmenaza.FindAll();
        }
    }
}
