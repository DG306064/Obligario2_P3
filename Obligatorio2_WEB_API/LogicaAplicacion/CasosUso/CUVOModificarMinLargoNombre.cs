using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUVOModificarMinLargoNombre : IVOModificarMinLargoNombre
    {
        IVONombre RepoVONombre { get; set; }

        public CUVOModificarMinLargoNombre(IVONombre repo)
        {
            RepoVONombre = repo;
        }
        public void Modificar(int largoMin)
        {
            RepoVONombre.CambiarMinLargo(largoMin);
        }
    }
}
