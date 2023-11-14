using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;
using DTOs;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IObtenerUsuarioParaLogear
    {
        UsuarioDTO ObtenerUsuarioParaLogear(string alias, string password);
    }
}
