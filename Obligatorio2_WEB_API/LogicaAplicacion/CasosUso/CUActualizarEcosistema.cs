using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;
using DTOs;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosUso
{
    public class CUActualizarEcosistema : IActualizarEcosistema
    {
        IRepositorioEcosistema RepositorioEcosistema { get; set; }

        public CUActualizarEcosistema(IRepositorioEcosistema repositorio)
        {
            RepositorioEcosistema = repositorio;
        }

        public void Actualizar(EcosistemaDTO obj)
        {
            Ecosistema eco = RepositorioEcosistema.FindById(obj.Id);
            eco.Nombre = obj.Nombre;
            eco.Latitud = obj.Latitud;
            eco.Longitud = obj.Longitud;
            eco.Area = obj.Area;
            eco.Descripcion = obj.Descripcion;
            eco.Pais = obj.Pais;
            eco.EstadoConservacion = obj.EstadoConservacion;
            eco.Amenazas = obj.Amenazas.Select(a => new Amenaza()
            {
                Id = a.Id,
                Descripcion = new Descripcion(a.Descripcion),
                Peligrosidad = a.Peligrosidad,
            });
            eco.ImagenEcosistema = obj.ImagenEcosistema;

            RepositorioEcosistema.Update(eco);
        }
    }
}
