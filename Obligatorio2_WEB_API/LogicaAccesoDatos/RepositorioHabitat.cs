using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesPropias;
using LogicaNegocio.Dominio;

namespace LogicaAccesoDatos
{
    public class RepositorioHabitat : IRepositorioHabitat
    {
        public EmpresaContext Contexto { get; set; }

        public RepositorioHabitat(EmpresaContext ctx)
        {

            Contexto = ctx;
        }

        public void Add(Habitat obj)
        {
            if (obj != null)
            {
                obj.Validate();

                if (obj.Ecosistema == null) throw new HabitatException("EL HABITAT DEBE CONTENER UN ECOSISTEMA");

                try
                {
                    Contexto.Entry(obj.Ecosistema).State = EntityState.Unchanged;
                    Contexto.Habitats.Add(obj);
                    Contexto.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new HabitatException("No se pudo realizar el alta", ex);

                }

            }
            else
            {
                throw new HabitatException("No se provee un habitat");
            }
        }

      

        public IEnumerable<Habitat> FindAll()
        {
            throw new NotImplementedException();
        }

        public Habitat FindById(int id)
        {
            return Contexto.Habitats.Include(h=>h.Ecosistema)
                                    .SingleOrDefault(h=>h.Id == id);
        }

        public void Remove(Habitat obj)
        {
            if (obj == null) throw new HabitatException("El habitat no puede ser nulo");

            var aBorrar = Contexto.Habitats.Find(obj.Id);

            if (aBorrar != null)
            {
                Contexto.Habitats.Remove(aBorrar);
                Contexto.SaveChanges();
            }
            else
            {
                throw new HabitatException("No existe el habitat a borrar");
            }
        }

        public void Update(Habitat obj)
        {
            if (obj != null)
            {
                 obj.Validate();

                Contexto.Habitats.Update(obj);
                Contexto.SaveChanges();

            }
            else
            {
                throw new HabitatException("El habitat proporcionado no existe");
            }
        }

        public void AsignarElEcosistema(int idEspecie, int idEcosistema)
        {
            if (idEspecie == 0) throw new HabitatException("OCURRIÓ UN PROBLEMA ASIGNANDO EL ECOSISTEMA");
            if (idEcosistema == 0) throw new HabitatException("OCURRIÓ UN PROBLEMA ASIGNANDO EL ECOSISTEMA");

            var Habitat = Contexto.Especies
                .Where(especie => especie.Id == idEspecie)
                .SelectMany(especie => especie.Habitats).Include(habitat=>habitat.Ecosistema)
                .SingleOrDefault(habitat => habitat.Ecosistema.Id == idEcosistema);

            if (Habitat.Habita == false)
            {
                Habitat.Habita = true;
            }
            else
            {
                Habitat.Habita = false;
            }

            Update(Habitat);

        }
    }
}
