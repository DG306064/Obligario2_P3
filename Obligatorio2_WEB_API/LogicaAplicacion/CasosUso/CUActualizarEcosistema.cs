using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;

namespace LogicaAplicacion.CasosUso
{
    public class CUActualizarEcosistema : IActualizarEcosistema
    {
        IRepositorioEcosistema RepositorioEcosistema { get; set; }

        public CUActualizarEcosistema(IRepositorioEcosistema repositorio)
        {
            RepositorioEcosistema = repositorio;
        }

        public void Actualizar(Ecosistema obj)
        {
            RepositorioEcosistema.Update(obj);
        }
    }
}
