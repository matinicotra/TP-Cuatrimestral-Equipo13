using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        private List<Cliente> listaClientes = new List<Cliente>();

        public Persona ObtenerPersona(int IdPersona) //no hay PersonaNegocio, esto obtiene la Persona
        {
            AccesoDatos datosPersona = new AccesoDatos();
            Persona personaAux = new Persona();

            try
            {
                datosPersona.SetearConsulta("SELECT IDPERSONA, NOMBRES, APELLIDOS, DNI, FECHANACIMIENTO, DOMICILIO, NACIONALIDAD FROM PERSONA WHERE IDPERSONA = @IDPERSONA");
                datosPersona.SetearParametro("@IDPERSONA", IdPersona);
                datosPersona.EjecutarConsulta();

                if (datosPersona.Lector.Read()) //si hay registro lo lee y setea
                {
                    personaAux.IDPersona = IdPersona;
                    personaAux.Nombres = (string)datosPersona.Lector["NOMBRES"];
                    personaAux.Apellidos = (string)datosPersona.Lector["APELLIDOS"];
                    personaAux.DNI = datosPersona.Lector["DNI"] is DBNull ? "S/D" : (string)datosPersona.Lector["DNI"];
                    personaAux.Nacionalidad = datosPersona.Lector["NACIONALIDAD"] is DBNull ? "S/N" : (string)datosPersona.Lector["NACIONALIDAD"];
                    personaAux.FechaNacimiento = (DateTime)datosPersona.Lector["FECHANACIMIENTO"];


                    //lectura domicilio
                    Domicilio domicilioAux = new Domicilio();
                    DomicilioNegocio dnAux = new DomicilioNegocio();

                    long idDomicilio = (long)datosPersona.Lector["DOMICILIO"];
                    domicilioAux = dnAux.ObtenerDomicilio(idDomicilio);

                    if (domicilioAux.IDDomicilio != -1) //si no devuelve -1 tiene domicilio
                    {
                        personaAux.Direccion = domicilioAux;
                    }
                    else //si devuelve -1 NO tiene domicilio
                    {
                        personaAux.Direccion = null; //ver como manejar el null
                    }

                    return personaAux;
                }
                else //si no hay registros que leer setea -1 al IdPersona
                {
                    personaAux.IDPersona = -1;

                    return personaAux;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datosPersona.CerrarConexion();
            }
        }

        public List<Cliente> ObtenerDatos(int idCliente = -1)
        {
            AccesoDatos datosCliente = new AccesoDatos();
            List<Cliente> listaClientes = new List<Cliente>();

            try
            {
                if(idCliente == -1)
                {
                    datosCliente.SetearConsulta("SELECT IDCLIENTE, IDPERSONA, IDZONA FROM CLIENTE");
                }
                else
                {
                    datosCliente.SetearConsulta("SELECT IDCLIENTE, IDPERSONA, IDZONA FROM CLIENTE WHERE IDCLIENTE = @IDCLIENTE");
                    datosCliente.SetearParametro("@IDCLIENTE", idCliente);
                }
                datosCliente.EjecutarConsulta();

                while (datosCliente.Lector.Read())
                {
                    Cliente clienteAux = new Cliente();
                    Persona personaAux = new Persona();
                    ClienteNegocio clienteNegocioAux = new ClienteNegocio();


                    personaAux = clienteNegocioAux.ObtenerPersona((int)datosCliente.Lector["IDPERSONA"]);

                    clienteAux.Nombres = personaAux.Nombres;
                    clienteAux.Apellidos = personaAux.Apellidos;
                    clienteAux.DNI = personaAux.DNI;
                    clienteAux.FechaNacimiento = personaAux.FechaNacimiento;
                    clienteAux.Direccion = personaAux.Direccion;
                    clienteAux.Nacionalidad = personaAux.Nacionalidad;
                    clienteAux.IDPersona = personaAux.IDPersona;
                    clienteAux.IDCliente = (int)datosCliente.Lector["IDCLIENTE"];

                    personaAux.IDPersona = (int)datosCliente.Lector["IDPERSONA"];

                        //obtiene la zona
                    ChoferNegocio cnAux = new ChoferNegocio();
                    Zona zonaAux = cnAux.ObtenerZonas((int)datosCliente.Lector["IDZONA"])[0];
                    clienteAux.zonaCliente = zonaAux;


                    listaClientes.Add(clienteAux);
                }

                return listaClientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosCliente.CerrarConexion();
            }
        }

        public void AltaModificacionChofer(Cliente clienteAux, bool esAlta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (!esAlta)
                {
                    datos.SetearConsulta("UPDATE DOMICILIO SET DIRECCION = @DIRECCION, LOCALIDAD = @LOCALIDAD, PROVINCIA = @PROVINCIA, DESCRIPCION = @DESCRIPCION WHERE IDDOMICILIO = @IDDOMICILIO");
                    datos.SetearParametro("@DIRECCION", clienteAux.Direccion.Direccion);
                    datos.SetearParametro("@LOCALIDAD", clienteAux.Direccion.Localidad);
                    datos.SetearParametro("@PROVINCIA", clienteAux.Direccion.Provincia);
                    datos.SetearParametro("@DESCRIPCION", clienteAux.Direccion.Descripcion);
                    datos.SetearParametro("@IDDOMICILIO", clienteAux.Direccion.IDDomicilio);
                    datos.EjecutarAccion();
                    datos.CerrarConexion();
                    datos.SetearConsulta("UPDATE PERSONA SET NOMBRES = @NOMBRES, APELLIDOS = @APELLIDOS, DNI = @DNI, FECHANACIMIENTO = @FECHANACIMIENTO, DOMICILIO = @DOMICILIO, NACIONALIDAD = @NACIONALIDAD WHERE IDPERSONA = @IDPERSONA");
                    datos.SetearParametro("@NOMBRES", clienteAux.Nombres);
                    datos.SetearParametro("@APELLIDOS", clienteAux.Apellidos);
                    datos.SetearParametro("@DNI", clienteAux.DNI);
                    datos.SetearParametro("@FECHANACIMIENTO", clienteAux.FechaNacimiento);
                    datos.SetearParametro("@DOMICILIO", clienteAux.Direccion.IDDomicilio);
                    datos.SetearParametro("@NACIONALIDAD", clienteAux.Nacionalidad);
                    datos.SetearParametro("@IDPERSONA", clienteAux.IDPersona);
                    datos.EjecutarAccion();
                    datos.CerrarConexion();
                    datos.SetearConsulta("UPDATE CLIENTE SET IDZONA = @IDZONA, IDPERSONA = @IDPERSONA1 WHERE IDCLIENTE = @IDCLIENTE");
                    datos.SetearParametro("@IDZONA", clienteAux.zonaCliente.IDZona);
                    datos.SetearParametro("@IDPERSONA1", clienteAux.IDPersona);
                    datos.SetearParametro("@IDCLIENTE", clienteAux.IDCliente);

                }
                else
                {
                    datos.SetearConsulta("INSERT INTO DOMICILIO (DIRECCION, LOCALIDAD, PROVINCIA, DESCRIPCION) VALUES (@DIRECCION, @LOCALIDAD, @PROVINCIA, @DESCRIPCION)");
                    datos.SetearParametro("@DIRECCION", clienteAux.Direccion.Direccion);
                    datos.SetearParametro("@LOCALIDAD", clienteAux.Direccion.Localidad);
                    datos.SetearParametro("@PROVINCIA", clienteAux.Direccion.Provincia);
                    datos.SetearParametro("@DESCRIPCION", clienteAux.Direccion.Descripcion);
                    datos.EjecutarAccion();
                    datos.CerrarConexion();
                    long idDomicilio = ultimoIdDomicilio();//obtiene el ultimo id de domicilio
                    datos.SetearConsulta("INSERT INTO PERSONA (NOMBRES, APELLIDOS, DNI, FECHANACIMIENTO, DOMICILIO, NACIONALIDAD) VALUES (@NOMBRES, @APELLIDOS, @DNI, @FECHANACIMIENTO, @IDDOMICILIO, @NACIONALIDAD)");
                    datos.SetearParametro("@NOMBRES", clienteAux.Nombres);
                    datos.SetearParametro("@APELLIDOS", clienteAux.Apellidos);
                    datos.SetearParametro("@DNI", clienteAux.DNI);
                    datos.SetearParametro("@FECHANACIMIENTO", clienteAux.FechaNacimiento);
                    datos.SetearParametro("@IDDOMICILIO", idDomicilio);//setea el idDomicilio recien insertado
                    datos.SetearParametro("@NACIONALIDAD", clienteAux.Nacionalidad);
                    datos.EjecutarAccion();
                    datos.CerrarConexion();

                    int idPersona = ultimoIdPersona();//obtiene el ultimo id de persona
                    datos.SetearConsulta("INSERT INTO CLIENTE (IDPERSONA, IDZONA) VALUES (@IDPERSONA, @IDZONA)");
                    datos.SetearParametro("@IDPERSONA", idPersona);//setea el  idPersona recien insertado
                    datos.SetearParametro("@IDZONA", clienteAux.zonaCliente.IDZona);
                }

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
        public long ultimoIdDomicilio()
        {
            long idDomicilio = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT TOP 1 * FROM DOMICILIO ORDER BY IDDOMICILIO DESC");
                datos.EjecutarConsulta();
                if (datos.Lector.Read())
                {
                    idDomicilio = (long)datos.Lector["IDDOMICILIO"];
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return idDomicilio;
        }
        public int ultimoIdPersona()
        {
            int idPersona = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT TOP 1 IDPERSONA FROM PERSONA ORDER BY IDPERSONA DESC");
                datos.EjecutarConsulta();
                if (datos.Lector.Read())
                {
                    idPersona = (int)datos.Lector["IDPERSONA"];
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return idPersona;
        }

        public List<Zona> ObtenerZonas(int idZona = -1)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Zona> listAux = new List<Zona>();

            try
            {
                if (idZona == -1)
                {
                    datos.SetearConsulta("SELECT IDZONA, NOMBREZONA FROM ZONAS");
                    datos.EjecutarConsulta();

                    while (datos.Lector.Read())
                    {
                        Zona aux = new Zona();

                        aux.IDZona = datos.Lector["IDZONA"] is DBNull ? -1 : (int)datos.Lector["IDZONA"];
                        aux.NombreZona = datos.Lector["NOMBREZONA"] is DBNull ? "S/Z" : (string)datos.Lector["NOMBREZONA"];

                        listAux.Add(aux);
                    }

                }
                else
                {
                    datos.SetearConsulta("SELECT IDZONA, NOMBREZONA FROM ZONAS WHERE IDZONA = @IDZONA");
                    datos.SetearParametro("@IDZONA", idZona);
                    datos.EjecutarConsulta();
                    datos.Lector.Read();
                    Zona aux = new Zona();
                    aux.IDZona = datos.Lector["IDZONA"] is DBNull ? -1 : (int)datos.Lector["IDZONA"];
                    aux.NombreZona = datos.Lector["NOMBREZONA"] is DBNull ? "S/Z" : (string)datos.Lector["NOMBREZONA"];
                    listAux.Add(aux);
                }

                return listAux;
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
