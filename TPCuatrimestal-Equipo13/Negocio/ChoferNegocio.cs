using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class ChoferNegocio
    {
        private List<Chofer> listaChoferes = new List<Chofer>();

        //----------------METODOS--------------------------
        public List<Chofer> ObtenerDatos(int idChofer = -1)
        {
            AccesoDatos datosChofer = new AccesoDatos();
            List<Chofer> listaChoferes = new List<Chofer>();

            try
            {
                if (idChofer == -1)
                {
                    datosChofer.SetearConsulta("SELECT C.IDCHOFER, C.IDPERSONA, Z.NOMBREZONA, Z.IDZONA, C.IDVEHICULO, C.ESTADO FROM CHOFER AS C INNER JOIN ZONAS AS Z ON C.IDZONA = Z.IDZONA");
                }
                else
                {
                    datosChofer.SetearConsulta("SELECT C.IDCHOFER, C.IDPERSONA, Z.NOMBREZONA, Z.IDZONA, C.IDVEHICULO, C.ESTADO FROM CHOFER AS C INNER JOIN ZONAS AS Z ON C.IDZONA = Z.IDZONA WHERE C.IDCHOFER = @IDCHOFER");

                    datosChofer.SetearParametro("@IDCHOFER", idChofer);
                }

                datosChofer.EjecutarConsulta();

                while (datosChofer.Lector.Read())
                {
                    Chofer choferAux = new Chofer();
                    Persona personaAux = new Persona();
                    ChoferNegocio cnAux = new ChoferNegocio();
                    PersonaNegocio perAux = new PersonaNegocio();


                    if ((int)datosChofer.Lector["IDPERSONA"] == -1) //si no encuentra al id persona devuelve -1
                    {
                        return listaChoferes; //retorna la lista al no encontrar una persona
                    }

                    personaAux = perAux.ObtenerPersona(datosChofer.Lector["IDPERSONA"] is DBNull ? -1 : (int)datosChofer.Lector["IDPERSONA"]); //asigna la persona a personaAux

                    //Asigna al choferAux los datos de la persona
                    choferAux.Nombres = personaAux.Nombres;
                    choferAux.Apellidos = personaAux.Apellidos;
                    choferAux.DNI = personaAux.DNI;
                    choferAux.FechaNacimiento = personaAux.FechaNacimiento;
                    choferAux.Direccion = personaAux.Direccion;
                    choferAux.Nacionalidad = personaAux.Nacionalidad;
                    choferAux.Email = personaAux.Email;
                    choferAux.Telefono = personaAux.Telefono;
                    choferAux.IDPersona = personaAux.IDPersona;


                    //asigna el id Chofer
                    choferAux.IDChofer = datosChofer.Lector["IDCHOFER"] is DBNull ? -1 : (int)datosChofer.Lector["IDCHOFER"];

                    choferAux.Estado = (bool)datosChofer.Lector["ESTADO"];

                    //lee la zona y la asigna
                    choferAux.ZonaAsignada = ZonaNegocio.ObtenerZonas(datosChofer.Lector["IDZONA"] is DBNull ? 0 : (int)datosChofer.Lector["IDZONA"])[0];

                    //lee el id vehiculo asignado
                    if (datosChofer.Lector["IDVEHICULO"] != DBNull.Value)
                    {
                        if ((int)datosChofer.Lector["IDVEHICULO"] > 0)
                        {
                            int IDVehiculo = (int)datosChofer.Lector["IDVEHICULO"];//guarda el id del vehiculo
                            Vehiculo vehiculoAux = new Vehiculo();
                            VehiculoNegocio vnAux = new VehiculoNegocio();
                            List<Vehiculo> listaVehiculos = new List<Vehiculo>();

                            listaVehiculos = vnAux.ObtenerDatos(); //carga la lista de todos los vehiculo de la BBDD

                            vehiculoAux = listaVehiculos.Find(x => x.IDVehiculo == IDVehiculo); //busca por el ID y asigna el vehiculo a vehiculoAux 

                            if (vehiculoAux != null)//si el vehiculo está activado setea el auto del chofer
                            {
                                choferAux.AutoAsignado = vehiculoAux;
                            }
                            else //si está desactivado le saca la asignacion
                            {
                                choferAux.AutoAsignado = null;
                                AsignarDesasignarAuto(choferAux.IDChofer, -1);
                            }
                        }
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
            PersonaNegocio perAux = new PersonaNegocio();
            DomicilioNegocio domiAux = new DomicilioNegocio();
            Chofer choAux = new Chofer();

            choAux = ObtenerDatos(idChofer)[0];

            try
            {
                datos.SetearConsulta("UPDATE VIAJES SET IDCHOFER = NULL WHERE IDCHOFER = @IDCHOFER");

                datos.SetearParametro("@IDCHOFER", idChofer);

                datos.EjecutarAccion();

                datos.CerrarConexion();

                datos.SetearConsulta("DELETE FROM CHOFER WHERE IDCHOFER = @CHOFER");

                datos.SetearParametro("@CHOFER", idChofer);

                datos.EjecutarAccion();

                datos.CerrarConexion();

                perAux.BajaPersona(choAux.IDPersona);

                domiAux.BajaDomicilio(choAux.Direccion.IDDomicilio);
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
                DomicilioNegocio domiAux = new DomicilioNegocio();
                PersonaNegocio perAux = new PersonaNegocio();
                Persona aux = new Persona();

                if (!esAlta)
                {
                    domiAux.AltaModificacionDomicilio(choferAux.Direccion, false);

                    aux.IDPersona = choferAux.IDPersona;
                    aux.Nombres = choferAux.Nombres;
                    aux.Apellidos = choferAux.Apellidos;
                    aux.DNI = choferAux.DNI;
                    aux.FechaNacimiento = choferAux.FechaNacimiento;
                    aux.Direccion = choferAux.Direccion;
                    aux.Nacionalidad = choferAux.Nacionalidad;
                    aux.Email = choferAux.Email;
                    aux.Telefono = choferAux.Telefono;

                    perAux.AltaModificacionPersona(aux, false);

                    datos.SetearConsulta("UPDATE CHOFER SET IDZONA = @IDZONA, IDVEHICULO = @IDVEHICULO WHERE IDCHOFER = @IDCHOFER");

                    datos.SetearParametro("@IDZONA", choferAux.ZonaAsignada.IDZona);

                    if (choferAux.AutoAsignado == null)
                    {
                        datos.SetearParametro("@IDVEHICULO", DBNull.Value);
                    }
                    else
                    {
                        datos.SetearParametro("@IDVEHICULO", choferAux.AutoAsignado.IDVehiculo);
                    }

                    datos.SetearParametro("@IDCHOFER", choferAux.IDChofer);
                }
                else
                {
                    domiAux.AltaModificacionDomicilio(choferAux.Direccion, true);

                    long idDomicilio = domiAux.ultimoIdDomicilio();//obtiene el ultimo id de domicilio

                    choferAux.Direccion.IDDomicilio = idDomicilio;

                    aux.Nombres = choferAux.Nombres;
                    aux.Apellidos = choferAux.Apellidos;
                    aux.DNI = choferAux.DNI;
                    aux.FechaNacimiento = choferAux.FechaNacimiento;
                    aux.Direccion = choferAux.Direccion;
                    aux.Nacionalidad = choferAux.Nacionalidad;
                    aux.Email = choferAux.Email;
                    aux.Telefono = choferAux.Telefono;

                    perAux.AltaModificacionPersona(aux, true);

                    int idPersona = perAux.ultimoIdPersona();//obtiene el ultimo id de persona

                    datos.SetearConsulta("INSERT INTO CHOFER (IDPERSONA, IDZONA, IDVEHICULO) VALUES (@IDPERSONA, @IDZONA, @IDVEHICULO)");
                    
                    datos.SetearParametro("@IDPERSONA", idPersona);//setea el  idPersona recien insertado
                    datos.SetearParametro("@IDZONA", choferAux.ZonaAsignada.IDZona);
                    
                    if (choferAux.AutoAsignado == null)
                    {
                        datos.SetearParametro("@IDVEHICULO", DBNull.Value);
                    }
                    else
                    {
                        datos.SetearParametro("@IDVEHICULO", choferAux.AutoAsignado.IDVehiculo);
                    }
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

        void AsignarDesasignarAuto(int idChofer, int idVehiculo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE CHOFER SET IDVEHICULO = @IDVEHICULO WHERE IDCHOFER = @IDCHOFER");
                
                datos.SetearParametro("@IDCHOFER", idChofer);
                
                if (idVehiculo <= 0)
                {
                    datos.SetearParametro("@IDVEHICULO", DBNull.Value);
                }
                else
                {
                    datos.SetearParametro("@IDVEHICULO", idVehiculo);
                }

                datos.EjecutarAccion();
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
    }
}
