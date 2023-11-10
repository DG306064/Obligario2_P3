using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioPais : IRepositorio<Pais>
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
            throw new NotImplementedException();
        }

        public void remove(Pais obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Pais obj)
        {
            throw new NotImplementedException();
        }
    }
}
