using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUAsignarAmenazaAEspecie : IAsignarAmenazaAEspecie
    {
        public IRepositorioEspecie repoEspecie { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }

        public CUAsignarAmenazaAEspecie(IRepositorioEspecie RepoEsp, IRepositorio<RegistroDeCambios> repoRegistroCambios)
        {
            repoEspecie = RepoEsp;
            RepoRegistroCambios = repoRegistroCambios;
        }

        

        public void AsignarLaAmenaza(int IdEspecie, int IdAmenaza, string nombreUsuario)
        {
            repoEspecie.AsignarUnaAmenaza(IdEspecie, IdAmenaza);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = IdEspecie,
                TipoDeEntidad = "Especie",
                TipoDeModificacion = "AMENAZA ASIGNADA"

            };



            RepoRegistroCambios.Add(registro);
        }
    }
}
