using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosUso
{
    public class CUAltaEspecie : IAltaEspecie
    {
        public IRepositorioEspecie RepoEspecie { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }


        public CUAltaEspecie(IRepositorioEspecie RepoEsp, IRepositorio<RegistroDeCambios> repoRegistroCambios)
        {
            RepoEspecie = RepoEsp;
            RepoRegistroCambios = repoRegistroCambios;
        }

        public void Add(EspecieDTO obj, string nombreUsuario)
        {
            Especie especie = new Especie() 
            {
                Id = obj.Id,
                NombreCientifico = obj.NombreCientifico,
                NombreComun = obj.NombreComun,
                Descripcion = obj.Descripcion,
                PesoMinimo = obj.PesoMinimo,
                PesoMaximo = obj.PesoMaximo,
                LongitudMinima = obj.LongitudMinima,
                LongitudMaxima = obj.LongitudMaxima,
                ImagenEspecie = obj.ImagenEspecie,
                EstadoCons = obj.EstadoCons,
            };

            RepoEspecie.Add(especie);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = obj.Id,
                TipoDeEntidad = "Especie",
                TipoDeModificacion = "ALTA"

            };



            RepoRegistroCambios.Add(registro);
        }
    }
}
