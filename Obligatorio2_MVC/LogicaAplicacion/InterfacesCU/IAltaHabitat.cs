using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IAltaHabitat 
    {
        void Alta(Habitat obj, string nombreUsuario);
    }
}
