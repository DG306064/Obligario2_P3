using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPais : IRepositorio<Pais>
    {
        string ObtenerNombreDePaisEnEcosistema(Ecosistema eco);
    }
}
