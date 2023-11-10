using ExcepcionesPropias;
using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioAmenaza : IRepositorio<Amenaza>
    {
        IEnumerable<int> IdsDeLasAmenazasDeUnaEspecie(int idEspecie);

        IEnumerable<int> IdsDeLasAmenazasDeUnEcosistema(int idEcosistema);
    }
}
