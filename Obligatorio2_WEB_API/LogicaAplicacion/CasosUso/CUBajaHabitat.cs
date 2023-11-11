using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBajaHabitat : IBajaHabitat
    {
        IRepositorioHabitat RepoHabitat { get; set; }
        IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }

        public CUBajaHabitat(IRepositorioHabitat repoHabitat, IRepositorio<RegistroDeCambios> repoRegistroCambios)
        {
            RepoHabitat = repoHabitat;
            RepoRegistroCambios = repoRegistroCambios;
        }

        public void Baja(HabitatDTO obj, string nombreUsuario)
        {
            RepoHabitat.Remove(new Habitat() { Id = obj.Id });

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = obj.Id,
                TipoDeEntidad = "Habitat",
                TipoDeModificacion = "BAJA"

            };

            RepoRegistroCambios.Add(registro);
        }
    }
}
