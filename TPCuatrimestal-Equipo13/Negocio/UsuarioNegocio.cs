using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {

        public List<Usuario> obtenerListaUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT * FROM USUARIOS");
                datos.EjecutarConsulta();
                while (datos.Lector.Read())
                {
                    Usuario usuarioAux = new Usuario();
                    usuarioAux.idPersona = datos.Lector["IDPERSONA"] is DBNull ? 0 : (int)datos.Lector["IDPERSONA"];
                    usuarioAux.Contrasenia = (string)datos.Lector["CONTRASENIA"];
                    usuarioAux.Email = (string)datos.Lector["EMAIL"];
                    usuarioAux.esAdmin = (bool)datos.Lector["ESADMIN"];

                    listaUsuarios.Add(usuarioAux);

                }
                return listaUsuarios;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        public bool login(string emailUsuario, string contraseniaUsuario)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            try
            {
                listaUsuarios = obtenerListaUsuarios();

                Usuario usuarioEncontrado = listaUsuarios.Find(x => x.Email == emailUsuario && x.Contrasenia == contraseniaUsuario);

                //si no encuentra retorna false, si encuentra retorna true
                if (usuarioEncontrado == null)
                    return false;
                else return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //ejecutar solo si el login es correcto
        public Usuario obtenerDatosUsuario(Usuario usuarioLogin)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuarioAux = new Usuario();

            try
            {
                datos.SetearConsulta("SELECT * FROM USUARIOS WHERE EMAIL = @EMAIL");
                datos.SetearParametro("@EMAIL", usuarioLogin.Email);
                datos.EjecutarConsulta();
                if (datos.Lector.Read())
                {
                    usuarioAux.idPersona = datos.Lector["IDPERSONA"] is DBNull ? 0 : (int)datos.Lector["IDPERSONA"];
                    usuarioAux.Contrasenia = (string)datos.Lector["CONTRASENIA"];
                    usuarioAux.Email = (string)datos.Lector["EMAIL"];
                    usuarioAux.esAdmin = (bool)datos.Lector["ESADMIN"];

                    return usuarioAux;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

            return usuarioAux;
        }
    }
}
