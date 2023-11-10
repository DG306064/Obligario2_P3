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
    public class CUObtenerEspeciePorNombreCientifico : IObtenerEspeciePorNombreCientifico
    {
        public IRepositorioEspecie repoEspecie { get; set; }

        public CUObtenerEspeciePorNombreCientifico(IRepositorioEspecie RepoEsp)
        {
            repoEspecie = RepoEsp;
        }
        public Especie IObtenerEspeciePorNombreCientifico(string nombre)
        {
            return repoEspecie.EspeciePorNombreCientifico(nombre);
        }
    }
}
