using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    public class RepositorioVODescripcion : IVODescripcion
    {
        public void CambiarMaxLargo(int largo)
        {
            if (largo == 0) throw new Exception("El valor ingresado debe ser mayor a 0");
            Descripcion.MaxLargoCharDescripcion = largo;
        }

        public void CambiarMinLargo(int largo)
        {
            if (largo == 0) throw new Exception("El valor ingresado debe ser mayor a 0");
            Descripcion.MinLargoCharDescripcion = largo;
        }
    }
}
