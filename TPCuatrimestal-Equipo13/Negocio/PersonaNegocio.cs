using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PersonaNegocio
    {
        //----------------METODOS--------------------------
        public Persona ObtenerPersona(int IdPersona)
        {
            AccesoDatos datosPersona = new AccesoDatos();
            Persona personaAux = new Persona();

            try
            {
                datosPersona.SetearConsulta("SELECT IDPERSONA, NOMBRES, APELLIDOS, DNI, FECHANACIMIENTO, DOMICILIO, NACIONALIDAD, EMAIL, TELEFONO FROM PERSONA WHERE IDPERSONA = @IDPERSONA");
                datosPersona.SetearParametro("@IDPERSONA", IdPersona);
                datosPersona.EjecutarConsulta();

                if (datosPersona.Lector.Read()) //si hay registro lo lee y setea
                {
                    personaAux.IDPersona = IdPersona;
                    personaAux.Nombres = datosPersona.Lector["NOMBRES"] is DBNull? "S/N" : (string)datosPersona.Lector["NOMBRES"];
                    personaAux.Apellidos = datosPersona.Lector["APELLIDOS"] is DBNull ? "S/A" : (string)datosPersona.Lector["APELLIDOS"];
                    personaAux.DNI = datosPersona.Lector["DNI"] is DBNull ? "S/D" : (string)datosPersona.Lector["DNI"];
                    personaAux.Nacionalidad = datosPersona.Lector["NACIONALIDAD"] is DBNull ? "S/N" : (string)datosPersona.Lector["NACIONALIDAD"];
                    personaAux.FechaNacimiento = datosPersona.Lector["FECHANACIMIENTO"] is DBNull ? DateTime.Parse("01-01-1900") : (DateTime)datosPersona.Lector["FECHANACIMIENTO"];
                    personaAux.Email = datosPersona.Lector["EMAIL"] is DBNull ? "S/E" : (string)datosPersona.Lector["EMAIL"];
                    personaAux.Telefono = datosPersona.Lector["TELEFONO"] is DBNull ? "S/T" : (string)datosPersona.Lector["TELEFONO"];


                    //lectura domicilio
                    Domicilio domicilioAux = new Domicilio();
                    DomicilioNegocio dnAux = new DomicilioNegocio();

                    long idDomicilio = datosPersona.Lector["DOMICILIO"] is DBNull ? 0 : (long)datosPersona.Lector["DOMICILIO"];
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

        public void BajaPersona(int IdPersona)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("DELETE FROM PERSONA WHERE IDPERSONA = @IDPERSONA");
                
                datos.SetearParametro("@IDPERSONA", IdPersona);
                
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

        public void AltaModificacionPersona(Persona perAux, bool esAlta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (!esAlta)
                {
                    datos.SetearConsulta("UPDATE PERSONA SET NOMBRES = @NOMBRES, APELLIDOS = @APELLIDOS, DNI = @DNI, FECHANACIMIENTO = @FECHANACIMIENTO, DOMICILIO = @DOMICILIO, NACIONALIDAD = @NACIONALIDAD, TELEFONO = @TELEFONO, EMAIL = @EMAIL WHERE IDPERSONA = @IDPERSONA");
                    
                    datos.SetearParametro("@NOMBRES", perAux.Nombres);
                    datos.SetearParametro("@APELLIDOS", perAux.Apellidos);
                    datos.SetearParametro("@DNI", perAux.DNI);
                    datos.SetearParametro("@FECHANACIMIENTO", perAux.FechaNacimiento);
                    datos.SetearParametro("@DOMICILIO", perAux.Direccion.IDDomicilio);
                    datos.SetearParametro("@NACIONALIDAD", perAux.Nacionalidad);
                    datos.SetearParametro("@EMAIL", perAux.Email);
                    datos.SetearParametro("@TELEFONO", perAux.Telefono);
                    datos.SetearParametro("@IDPERSONA", perAux.IDPersona);
                }
                else
                {
                    datos.SetearConsulta("INSERT INTO PERSONA (NOMBRES, APELLIDOS, DNI, FECHANACIMIENTO, DOMICILIO, NACIONALIDAD, EMAIL, TELEFONO) VALUES (@NOMBRES, @APELLIDOS, @DNI, @FECHANACIMIENTO, @IDDOMICILIO, @NACIONALIDAD, @EMAIL, @TELEFONO)");
                    
                    datos.SetearParametro("@NOMBRES", perAux.Nombres);
                    datos.SetearParametro("@APELLIDOS", perAux.Apellidos);
                    datos.SetearParametro("@DNI", perAux.DNI);
                    datos.SetearParametro("@FECHANACIMIENTO", perAux.FechaNacimiento);
                    datos.SetearParametro("@EMAIL", perAux.Email);
                    datos.SetearParametro("@TELEFONO", perAux.Telefono);
                    datos.SetearParametro("@IDDOMICILIO", perAux.Direccion.IDDomicilio);//setea el idDomicilio recien insertado
                    datos.SetearParametro("@NACIONALIDAD", perAux.Nacionalidad);
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
                    idPersona = datos.Lector["IDPERSONA"] is DBNull? -1 : (int)datos.Lector["IDPERSONA"];
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
