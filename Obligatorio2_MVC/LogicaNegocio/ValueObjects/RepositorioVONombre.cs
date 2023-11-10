using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioVONombre : IVONombre
    {

        public void CambiarMaxLargo(int largo)
        {
            if (largo == 0) throw new Exception("El valor ingresado debe ser mayor a 0");
            Nombre.MaxLargoCharNombre = largo;
        }

        public void CambiarMinLargo(int largo)
        {
            if (largo == 0) throw new Exception("El valor ingresado debe ser mayor a 0");
            Nombre.MinLargoCharNombre = largo;
        }
    }
}
