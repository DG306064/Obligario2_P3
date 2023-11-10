using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUVOModificarMinLargoDescripcion : IVOModificarMinLargoDescripcion
    {
        IVODescripcion RepoVODescripcion { get; set; }

        public CUVOModificarMinLargoDescripcion(IVODescripcion repo)
        {
            RepoVODescripcion = repo;
        }

        public void Modificar(int largoMin)
        {
            RepoVODescripcion.CambiarMinLargo(largoMin);
        }
    }
}
