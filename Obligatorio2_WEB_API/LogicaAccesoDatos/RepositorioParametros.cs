using ExcepcionesPropias;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioParametros : IRepositorioParametros
    {
        public EmpresaContext Contexto { get; set; }

        public RepositorioParametros(EmpresaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public string BuscarValorPorNombre(string nombre)
        {
            var resultado = Contexto.Parametros
                    .Where(par=>par.Nombre == nombre)
                    .Select(par=>par.Valor)
                    .SingleOrDefault();

            return resultado;
       
        }

        public Parametro BuscarParametroPorNombre(string nombre)
        {
            return Contexto.Parametros.Where(par => par.Nombre == nombre).SingleOrDefault();
        }


        public Parametro FindById(int id)
        {
            var parametro = Contexto.Parametros.Where(p => p.Id == id)
                                               .SingleOrDefault();

            return parametro;
        }

        public void Remove(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Parametro obj)
        {
            if (obj != null)
            {

                Contexto.Parametros.Update(obj);
                Contexto.SaveChanges();

            }
            else
            {
                throw new ParametrosException("No se encontró el parametro");
            }
        }
        public IEnumerable<Parametro> FindAll()
        {
            var parametros = Contexto.Parametros.ToList();

            return parametros;
        }

        
    }
}
