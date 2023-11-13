using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosUso
{
    public class CUAmenazaEnComun : IAmenazaEnComun
    {
        public IRepositorioEspecie RepoEspecie { get; set; }
        public CUAmenazaEnComun(IRepositorioEspecie repo)
        {
            RepoEspecie = repo;
        }


        public AmenazaDTO AmenazaENComun(int idEspecie, int idEcosistema)
        {
            var a = RepoEspecie.AmenazaEnComun(idEspecie, idEcosistema);

            var amenaza = new AmenazaDTO()
            {
                Id = a.Id,
                Descripcion = a.Descripcion.Value,
                Peligrosidad = a.Peligrosidad,
            };

            return amenaza;
        }
    }
}
