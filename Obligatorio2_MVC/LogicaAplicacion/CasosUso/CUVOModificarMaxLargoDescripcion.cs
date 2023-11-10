using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUVOModificarMaxLargoDescripcion : IVOModificarMaxLargoDescripcion
    {
        IVODescripcion RepoVODescripcion { get; set; }

        public CUVOModificarMaxLargoDescripcion(IVODescripcion repo)
        {
            RepoVODescripcion = repo;
        }
        public void Modificar(int largoMax)
        {
            RepoVODescripcion.CambiarMaxLargo(largoMax);
        }
    }
}
