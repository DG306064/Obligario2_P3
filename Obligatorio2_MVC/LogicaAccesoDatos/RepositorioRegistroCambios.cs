using ExcepcionesPropias;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioRegistroCambios : IRepositorio<RegistroDeCambios>
    {
        public EmpresaContext Contexto { get; set; }

        public RepositorioRegistroCambios(EmpresaContext ctx)
        {
            Contexto = ctx;
        }


        public void Add(RegistroDeCambios obj)
        {
            if (obj != null)
            {

                obj.Validate();

                try
                {
                    Contexto.Registros.Add(obj);
                    Contexto.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw new CambiosException("No se pudo registrar la modificación de la entidad");

                } 

            }
            else
            {
                throw new CambiosException("No se provee un registro para su creación");
            }
        }

        public IEnumerable<RegistroDeCambios> FindAll()
        {
            throw new NotImplementedException();
        }

        public RegistroDeCambios FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void remove(RegistroDeCambios obj)
        {
            throw new NotImplementedException();
        }

        public void Update(RegistroDeCambios obj)
        {
            throw new NotImplementedException();
        }
    }
}
