using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEcosistema : IRepositorio<Ecosistema>
    {
        void AsignarUnaAmenaza(int IdEcosistema, int IdAmenaza);

        int CantidadDeEspeciesHabitandoUnEcosistema(int IdEcosistema);

       

        bool ExisteNombreEcosistema(string nombreEcosistema);

        IEnumerable<Amenaza> ObtenerAmenazas(int idEcoistema);

        IEnumerable<Ecosistema> EcosistemasQueNoPuedeHabitarUnaEspecie(string nombreEspecie);

        Ecosistema BuscarECosistemaPorNombre(string nombreEcosistema);





    }
}
