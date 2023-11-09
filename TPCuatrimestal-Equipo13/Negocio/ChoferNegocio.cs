using System;
using System.Collections.Generic;
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
                    personaAux.IdPersona = IdPersona;
                    personaAux.Nombres = (string)datosPersona.Lector["NOMBRES"];
                    personaAux.Apellidos = (string)datosPersona.Lector["APELLIDOS"];
                    personaAux.DNI = datosPersona.Lector["DNI"] is DBNull ? "S/D" : (string)datosPersona.Lector["DNI"];
                    personaAux.Nacionalidad =datosPersona.Lector["NACIONALIDAD"] is DBNull ? "S/N" : (string)datosPersona.Lector["NACIONALIDAD"];
                    personaAux.FechaNacimiento = (DateTime)datosPersona.Lector["FECHANACIMIENTO"];
                            //lectura domicilio
                    Domicilio domicilioAux = new Domicilio();
                    DomicilioNegocio dnAux = new DomicilioNegocio();
                    long idDomicilio = (long)datosPersona.Lector["DOMICILIO"];
                    domicilioAux = dnAux.ObtenerDomicilio(idDomicilio);
                    if(domicilioAux.IdDomicilio != -1) //si no devuelve -1 tiene domicilio
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
                    personaAux.IdPersona = -1;
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

        public List<Chofer> ObtenerDatos()
        {
            AccesoDatos datosChofer = new AccesoDatos();
            List<Chofer> listaChoferes = new List<Chofer>();

            try
            {
                datosChofer.SetearConsulta("SELECT IDCHOFER,IDPERSONA,ZONA,IDVEHICULO FROM CHOFER");
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
                    
                        //asigna el resto de datos al chofer
                    choferAux.IDChofer = (int)datosChofer.Lector["IDCHOFER"];
                    choferAux.Zona = (string)datosChofer.Lector["ZONA"];

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
    }
}
