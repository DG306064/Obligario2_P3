using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUVOModificarMaxLargoNombre : IVOModificarMaxLargoNombre
    {
        IVONombre RepoVONombre { get; set; }

        public CUVOModificarMaxLargoNombre(IVONombre repo)
        {
            RepoVONombre = repo;
        }
        public void Modificar(int largoMax)
        {
            RepoVONombre.CambiarMaxLargo(largoMax);
        }
    }
}
