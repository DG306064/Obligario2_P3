using ExcepcionesPropias;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioAmenaza : IRepositorioAmenaza
    {
        public EmpresaContext Contexto { get; set; }

        public RepositorioAmenaza(EmpresaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Amenaza obj)
        {
           
            throw new NotImplementedException();
        }

        public IEnumerable<Amenaza> FindAll()
        {
            return Contexto.Amenazas.ToList();
        }

        public Amenaza FindById(int id)
        {
            if (id == 0) throw new AmenazaException("NO SE OBTUVO LA AMENAZA");
            return Contexto.Amenazas.Find(id);
        }

        public void remove(Amenaza obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Amenaza obj)
        {
            if (obj != null)
            {
                 obj.Validate();

                Contexto.Amenazas.Update(obj);
                Contexto.SaveChanges();

            }
            else
            {
                throw new AmenazaException("LA AMENAZA NO PUDO SER ASIGNADA");
            }
        }

        public IEnumerable<int> IdsDeLasAmenazasDeUnaEspecie(int idEspecie)
        {
            if (idEspecie == 0) throw new AmenazaException("NO SE OBTUVO LA AMENAZA");

            var IdsDeLasAmenazas = Contexto.Amenazas
                                .Where(amenaza => amenaza.Especies.Any(especie => especie.Id == idEspecie))
                                .Select(amenaza => amenaza.Id).ToList();
          
            return IdsDeLasAmenazas;
        }

        public IEnumerable<int> IdsDeLasAmenazasDeUnEcosistema(int idEcosistema)
        {
            var IdsDeLasAmenazas = Contexto.Amenazas
                                .Where(amenaza => amenaza.Ecosistemas.Any(ecosistemas => ecosistemas.Id == idEcosistema))
                                .Select(amenaza => amenaza.Id).ToList();


            return IdsDeLasAmenazas;



        }

     
    }


}
