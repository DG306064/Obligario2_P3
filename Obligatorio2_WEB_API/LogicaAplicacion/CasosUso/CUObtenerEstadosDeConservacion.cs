using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosUso
{
    public class CUObtenerEstadosDeConservacion : IObtenerEstadosDeConservacion
    {

        public IRepositorio<EstadoConservacion> RepoEstado { get; set; }

        public CUObtenerEstadosDeConservacion(IRepositorio<EstadoConservacion> repoEstado)
        {
            RepoEstado = repoEstado;

        }



        public IEnumerable<EstadoConservacionDTO> ObtenerEstadosDeConservacion()
        {
            var estados = RepoEstado.FindAll();

            var estadosDTO = estados.Select(e => new EstadoConservacionDTO()
            {
                Id = e.Id,
                Nombre = e.Nombre.Value,
                Valor = e.Valor
            });

            return estadosDTO;
        }
    }
}
