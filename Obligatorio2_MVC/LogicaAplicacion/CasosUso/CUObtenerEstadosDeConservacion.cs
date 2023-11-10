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
    public class CUObtenerEstadosDeConservacion : IObtenerEstadosDeConservacion
    {

        public IRepositorio<EstadoConservacion> RepoEstado { get; set; }

        public CUObtenerEstadosDeConservacion(IRepositorio<EstadoConservacion> repoEstado)
        {
            RepoEstado = repoEstado;

        }



        public IEnumerable<EstadoConservacion> ObtenerEstadosDeConservacion()
        {
            return RepoEstado.FindAll();
        }
    }
}
