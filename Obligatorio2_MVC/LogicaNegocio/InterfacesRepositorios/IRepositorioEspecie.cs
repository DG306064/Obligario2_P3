using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEspecie : IRepositorio<Especie>
    {
        IEnumerable<Habitat> ObtenerHabitatsDeLaEspecie(int idEspecie);

        void AgregarHabitatEnLaEspecie(int idEspecie, int idHabitat);

        IEnumerable<Ecosistema> EcosistemasQueAunNoTienenPosibleHabitatConEsaEspecie(int idEspecie);

        void AsignarUnaAmenaza(int IdEspecie, int IdAmenaza);
        Amenaza AmenazaEnComun(int IdEpecie, int IdEcosistema);

        bool EstadosDeConservacionCompatibles(int IdEpecie, int IdEcosistema);

        IEnumerable<Especie> EspeciesOrdenadasPorNombreCientifico();

        IEnumerable<Especie> EspeciesEnPeligroDeExtincion();

        IEnumerable<Especie> especiesFiltradasPorEcosistema(string ecosistema);
        int ObtenerIdUltimaEspecie();

        bool ExisteNombreEspecie(string nombreEspecie);
        bool ExisteNombreCientificoEspecie(string nombreCientificoEspecie);
        Especie EspeciePorNombreCientifico(string nombre);

        IEnumerable<Amenaza> ObtenerAmenazas(int idEspecie);

        IEnumerable<Especie> BuscarEspeciesPorRangoDePeso(int pesoMin, int pesoMax);



    }

}
