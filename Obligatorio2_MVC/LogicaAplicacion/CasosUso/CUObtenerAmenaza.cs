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
    public class CUObtenerAmenaza : IObtenerAmenaza
    {
        public IRepositorioAmenaza RepoAmenaza { get; set; }

        public CUObtenerAmenaza(IRepositorioAmenaza repoAmenaza)
        {
            RepoAmenaza = repoAmenaza;
        }
        public Amenaza ObtenerAmenaza(int idAmenaza)
        {
            return RepoAmenaza.FindById(idAmenaza);

        }
    }
}
