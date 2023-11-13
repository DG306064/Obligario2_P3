using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;
using DTOs;

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
            eco.Amenazas = ConvertirAmenazas(obj.Amenazas);
            eco.ImagenEcosistema = obj.ImagenEcosistema;

            RepositorioEcosistema.Update(eco);
        }

        public IEnumerable<Amenaza> ConvertirAmenazas(IEnumerable<AmenazaDTO> amenazas)
        {
            return amenazas.Select(a => new Amenaza()
            {
                Id = a.Id,
                Descripcion = a.Descripcion,
                Peligrosidad = a.Peligrosidad
            });
        }
    }
}
