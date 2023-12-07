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
                datos.SetearConsulta("SELECT * FROM USUARIO");
                datos.EjecutarConsulta();
                while (datos.Lector.Read())
                {
                    Usuario usuarioAux = new Usuario();
                    usuarioAux.idChofer = datos.Lector["IDCHOFER"] is DBNull ? 0 : (int)datos.Lector["IDCHOFER"];
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
        public Usuario obtenerDatosUsuario(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuarioAux = new Usuario();

            try
            {
                datos.SetearConsulta("SELECT * FROM USUARIO WHERE EMAIL = @EMAIL");
                datos.SetearParametro("@EMAIL", email);
                datos.EjecutarConsulta();
                if (datos.Lector.Read())
                {
                    usuarioAux.idChofer = datos.Lector["IDCHOFER"] is DBNull ? 0 : (int)datos.Lector["IDCHOFER"];
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

        public void nuevoUsuario (Chofer chofer)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO USUARIO (EMAIL, CONTRASENIA, ESADMIN, IDCHOFER) VALUES (@EMAIL, @CONTRASENIA, 0, @IDCHOFER)");
                datos.SetearParametro("@EMAIL", chofer.Email);
                datos.SetearParametro("@CONTRASENIA", chofer.Apellidos + chofer.IDChofer);
                datos.SetearParametro("@IDCHOFER", chofer.IDChofer);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

    }
}
