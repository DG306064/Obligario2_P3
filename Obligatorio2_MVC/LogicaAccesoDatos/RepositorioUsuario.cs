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
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public EmpresaContext Contexto { get; set; }

        public RepositorioUsuario(EmpresaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Usuario obj)
        {
            if (obj != null)
            {
                obj.Validate();

                if (VerSiExisteUsuario(obj.Alias)) throw new UsuarioException("YA EXISTE UN USUARIO CON ESE ALIAS");



                try
                {
                    Contexto.Usuarios.Add(obj);
                    Contexto.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw new UsuarioException("SE PUDO REALIZAR EL ALTA", ex);
                }

            }
            else{
                
                throw new UsuarioException("OCURRIÓ UN ERROR AL HACER EL ALTA DEL USUARIO");
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios.ToList();
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios.Find(id);
        }

        public void remove(Usuario obj)
        {
            if (obj != null)
            {
                try
                {
                    Contexto.Remove(obj);
                    Contexto.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new UsuarioException("OCURRIÓ UN ERROR AL INTENTAR ELIMINAR EL USUARIO");
                 
                }

            }
            else
            {
                throw new UsuarioException("NO SE PROPORCIONÓ UN USUARIO");
            }
        }

        public void Update(Usuario obj)
        {
            obj.Validate();

            if (obj != null)
            {
                Contexto.Usuarios.Update(obj);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("EL USUARIO PROPORCIONADO NO EXISTE");
            }
        }




        public IEnumerable<Usuario> ObtenerUsuarioParaLogear(string alias, string password)
        {
            if (string.IsNullOrEmpty(alias)) throw new ParametrosException("EL ALIAS DEL NO PUEDE ESTAR VACIO");
            if (string.IsNullOrEmpty(password)) throw new ParametrosException("LA CONTRASEÑA NO PUEDE ESTAR VACIA");

            var resultado = Contexto.Usuarios
                   .Where(usu => usu.Alias == alias)
                   .Where(usu => usu.Password == password)
                   .ToList();
 
            return resultado;
        }

        public bool VerSiExisteUsuario(string alias)
        {
            if (string.IsNullOrEmpty(alias)) throw new UsuarioException("No se recibió un alias");
           
            bool existe = Contexto.Usuarios.Any(usuario => usuario.Alias == alias);
            
            return existe;

        }





    }
}
