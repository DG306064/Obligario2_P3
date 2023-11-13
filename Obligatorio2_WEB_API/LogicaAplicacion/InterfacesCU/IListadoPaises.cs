using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IListadoPaises
    {

        IEnumerable<PaisDTO> Listado();
       
    }
}
