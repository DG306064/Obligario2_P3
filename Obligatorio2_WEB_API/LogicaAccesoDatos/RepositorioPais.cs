using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioPais : IRepositorioPais
    {
        public EmpresaContext Contexto { get; set; }

        public RepositorioPais(EmpresaContext ctx)
        {
            Contexto = ctx;
        }


        public void Add(Pais obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> FindAll()
        {
          
            return Contexto.Paises.ToList();
            
        }

        public Pais FindById(int id)
        {
            if (id == 0) throw new Exception("El id no puede ser 0");

            var pais = Contexto.Paises.Include(p=>p.Nombre)
                                      .SingleOrDefault(p => p.Id == id);

            if (pais is null) throw new Exception("El id no existe en la base de datos.");

            return pais;
        }

        public void Remove(Pais obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Pais obj)
        {
            throw new NotImplementedException();
        }

        public string ObtenerNombreDePaisEnEcosistema(Ecosistema eco)
        {
            if (eco.Pais.Id == 0) throw new Exception("El id del pais ingresado no es correcto");
            string nombrePais = Contexto.Ecosistemas.Include(e => e.Pais)
                                                    .SingleOrDefault(p => p.Id == eco.Pais.Id).Nombre.Value;
            if (nombrePais.IsNullOrEmpty()) throw new Exception("El id no existe en la base de datos");

            return nombrePais;
        }
    }
}
