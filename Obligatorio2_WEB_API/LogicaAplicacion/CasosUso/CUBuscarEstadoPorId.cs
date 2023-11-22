using DTOs;
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
    public class CuBuscarEstadoPorId : IBuscarEstadoPorId
    {
        IRepositorio<EstadoConservacion> RepoEstados { get; set; }

        public CuBuscarEstadoPorId(IRepositorio<EstadoConservacion> repositorio)
        {
            RepoEstados = repositorio;
        }
        public EstadoConservacionDTO Buscar(int id)
        {
            var estado = RepoEstados.FindById(id);
            return new EstadoConservacionDTO
            {
                Id = estado.Id,
                Nombre = estado.Nombre.Value,
                Valor = estado.Valor
            };
        }
    }
}
