using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class ChoferNegocio
    {
        private List<Chofer> listaChoferes = new List<Chofer>();

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

        //OBTIENE TODAS LAS ZONAS
        public List<Zona> ObtenerZonas()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Zona> listAux = new List<Zona>();

            try
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

        public List<Chofer> ObtenerDatos(int idChofer = -1)
        {
            AccesoDatos datosChofer = new AccesoDatos();
            List<Chofer> listaChoferes = new List<Chofer>();

            try
            {
                if (idChofer == -1)
                {
                    datosChofer.SetearConsulta("SELECT C.IDCHOFER, C.IDPERSONA, Z.NOMBREZONA, Z.IDZONA, C.IDVEHICULO FROM CHOFER AS C INNER JOIN ZONAS AS Z ON C.IDZONA = Z.IDZONA");
                }
                else
                {
                    datosChofer.SetearConsulta("SELECT C.IDCHOFER, C.IDPERSONA, Z.NOMBREZONA, Z.IDZONA, C.IDVEHICULO FROM CHOFER AS C INNER JOIN ZONAS AS Z ON C.IDZONA = Z.IDZONA WHERE C.IDCHOFER = @IDCHOFER");
                    datosChofer.SetearParametro("@IDCHOFER", idChofer);
                }
                datosChofer.EjecutarConsulta();

                while (datosChofer.Lector.Read())
                {
                    Chofer choferAux = new Chofer();
                    Persona personaAux = new Persona();
                    ChoferNegocio cnAux = new ChoferNegocio();

                    if ((int)datosChofer.Lector["IDPERSONA"] == -1) //si no encuentra al id persona devuelve -1
                    {
                        return listaChoferes; //retorna la lista al no encontrar una persona
                    }

                    personaAux = cnAux.ObtenerPersona((int)datosChofer.Lector["IDPERSONA"]); //asigna la persona a personaAux

                    //Asigna al choferAux los datos de la persona
                    choferAux.Nombres = personaAux.Nombres;
                    choferAux.Apellidos = personaAux.Apellidos;
                    choferAux.DNI = personaAux.DNI;
                    choferAux.FechaNacimiento = personaAux.FechaNacimiento;
                    choferAux.Direccion = personaAux.Direccion;
                    choferAux.Nacionalidad = personaAux.Nacionalidad;
                    choferAux.IDPersona = personaAux.IDPersona;

                    //asigna el resto de datos al chofer
                    choferAux.IDChofer = (int)datosChofer.Lector["IDCHOFER"];
                    choferAux.ZonaAsignada.IDZona = datosChofer.Lector["IDZONA"] is DBNull ? 0 : (int)datosChofer.Lector["IDZONA"];

                   

                    //lee el id vehiculo asignado
                    if (datosChofer.Lector["IDVEHICULO"] != null)
                    {
                        int IDVehiculo = (int)datosChofer.Lector["IDVEHICULO"];//guarda el id del vehiculo
                        Vehiculo vehiculoAux = new Vehiculo();
                        VehiculoNegocio vnAux = new VehiculoNegocio();
                        List<Vehiculo> listaVehiculos = new List<Vehiculo>();

                        listaVehiculos = vnAux.ObtenerDatos(); //carga la lista de todos los vehiculo de la BBDD

                        vehiculoAux = listaVehiculos.Find(x => x.IDVehiculo == IDVehiculo); //busca por el ID y asigna el vehiculo a vehiculoAux 
                        choferAux.AutoAsignado = vehiculoAux; //setea el auto del chofer
                    }

                    listaChoferes.Add(choferAux);
                }

                return listaChoferes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosChofer.CerrarConexion();
            }
        }

        public void BajaChofer(int idChofer)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("DELETE FROM CHOFER WHERE IDCHOFER = @IDCHOFER");
                datos.SetearParametro("@IDCHOFER", idChofer);
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

        public void AltaModificacionChofer(Chofer choferAux, bool esAlta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (!esAlta)
                {
                    datos.SetearConsulta("UPDATE DOMICILIO SET DIRECCION = @DIRECCION, LOCALIDAD = @LOCALIDAD, PROVINCIA = @PROVINCIA, DESCRIPCION = @DESCRIPCION WHERE IDDOMICILIO = @IDDOMICILIO");
                    datos.SetearParametro("@DIRECCION", choferAux.Direccion.Direccion);
                    datos.SetearParametro("@LOCALIDAD", choferAux.Direccion.Localidad);
                    datos.SetearParametro("@PROVINCIA", choferAux.Direccion.Provincia);
                    datos.SetearParametro("@DESCRIPCION", choferAux.Direccion.Descripcion);
                    datos.SetearParametro("@IDDOMICILIO", choferAux.Direccion.IDDomicilio);
                    datos.EjecutarAccion();
                    datos.CerrarConexion();
                    datos.SetearConsulta("UPDATE PERSONA SET NOMBRES = @NOMBRES, APELLIDOS = @APELLIDOS, DNI = @DNI, FECHANACIMIENTO = @FECHANACIMIENTO, DOMICILIO = @DOMICILIO, NACIONALIDAD = @NACIONALIDAD WHERE IDPERSONA = @IDPERSONA");
                    datos.SetearParametro("@NOMBRES", choferAux.Nombres);
                    datos.SetearParametro("@APELLIDOS", choferAux.Apellidos);
                    datos.SetearParametro("@DNI", choferAux.DNI);
                    datos.SetearParametro("@FECHANACIMIENTO", choferAux.FechaNacimiento);
                    datos.SetearParametro("@DOMICILIO", choferAux.Direccion.IDDomicilio);
                    datos.SetearParametro("@NACIONALIDAD", choferAux.Nacionalidad);
                    datos.SetearParametro("@IDPERSONA", choferAux.IDPersona);
                    datos.EjecutarAccion();
                    datos.CerrarConexion();
                    datos.SetearConsulta("UPDATE CHOFER SET IDZONA = @IDZONA, IDVEHICULO = @IDVEHICULO WHERE IDCHOFER = @IDCHOFER");
                    datos.SetearParametro("@IDZONA", choferAux.ZonaAsignada.IDZona);
                    datos.SetearParametro("@IDVEHICULO", choferAux.AutoAsignado.IDVehiculo);
                    datos.SetearParametro("@IDCHOFER", choferAux.IDChofer);

                }
                else
                {
                    datos.SetearConsulta("INSERT INTO DOMICILIO (DIRECCION, LOCALIDAD, PROVINCIA, DESCRIPCION) VALUES (@DIRECCION, @LOCALIDAD, @PROVINCIA, @DESCRIPCION)");
                    datos.SetearParametro("@DIRECCION", choferAux.Direccion.Direccion);
                    datos.SetearParametro("@LOCALIDAD", choferAux.Direccion.Localidad);
                    datos.SetearParametro("@PROVINCIA", choferAux.Direccion.Provincia);
                    datos.SetearParametro("@DESCRIPCION", choferAux.Direccion.Descripcion);
                    datos.EjecutarAccion();
                    datos.CerrarConexion();
                    long idDomicilio = ultimoIdDomicilio();//obtiene el ultimo id de domicilio
                    datos.SetearConsulta("INSERT INTO PERSONA (NOMBRES, APELLIDOS, DNI, FECHANACIMIENTO, DOMICILIO, NACIONALIDAD) VALUES (@NOMBRES, @APELLIDOS, @DNI, @FECHANACIMIENTO, @IDDOMICILIO, @NACIONALIDAD)");
                    datos.SetearParametro("@NOMBRES", choferAux.Nombres);
                    datos.SetearParametro("@APELLIDOS", choferAux.Apellidos);
                    datos.SetearParametro("@DNI", choferAux.DNI);
                    datos.SetearParametro("@FECHANACIMIENTO", choferAux.FechaNacimiento);
             
                    datos.SetearParametro("@IDDOMICILIO", idDomicilio);//setea el idDomicilio recien insertado

                    datos.SetearParametro("@NACIONALIDAD", choferAux.Nacionalidad);
                    datos.EjecutarAccion();
                    datos.CerrarConexion();

                    int idPersona = ultimoIdPersona();//obtiene el ultimo id de persona
                    datos.SetearConsulta("INSERT INTO CHOFER (IDPERSONA, IDZONA, IDVEHICULO) VALUES (@IDPERSONA, @IDZONA, @IDVEHICULO)");
                    datos.SetearParametro("@IDPERSONA", idPersona);//setea el  idPersona recien insertado
                    datos.SetearParametro("@IDZONA", choferAux.ZonaAsignada.IDZona);
                    datos.SetearParametro("@IDVEHICULO", choferAux.AutoAsignado.IDVehiculo);
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
    }
    
}
