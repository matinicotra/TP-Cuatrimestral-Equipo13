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

        public List<Cliente> ObtenerDatos()
        {
            AccesoDatos datosCliente = new AccesoDatos();
            List<Cliente> listaClientes = new List<Cliente>();

            try
            {
                datosCliente.SetearConsulta("SELECT IDCLIENTE, IDPERSONA FROM CLIENTE");
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

                    personaAux.IDPersona = (int)datosCliente.Lector["IDPERSONA"];

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

    }
}
