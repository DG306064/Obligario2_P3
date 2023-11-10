using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioHabitat : IRepositorio<Habitat>
    {
        void AsignarElEcosistema(int idEspecie, int idEcosistema);
    }
}
