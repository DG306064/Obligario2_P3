using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;
using DTOs;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IAmenazasDeUnaEspecie
    {
        IEnumerable<AmenazaDTO> AmenazasDeLaEspecie(int idEspecie);
    }
}
