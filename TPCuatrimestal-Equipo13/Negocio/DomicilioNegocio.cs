using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DomicilioNegocio
    {
        public Domicilio ObtenerDomicilio(long IdDomicilio)
        {
            Domicilio domicilioAux = new Domicilio();
            AccesoDatos datosDomicilio = new AccesoDatos();
            try
            {
                datosDomicilio.SetearConsulta("SELECT IDDOMICILIO, DIRECCION, LOCALIDAD, PROVINCIA, DESCRIPCION FROM DOMICILIO WHERE IDDOMICILIO = @IDDOMICILIO");
                datosDomicilio.SetearParametro("@IDDOMICILIO", IdDomicilio);
                datosDomicilio.EjecutarConsulta();

                if (datosDomicilio.Lector.Read()) //si hay registro lo lee y setea
                {
                    domicilioAux.IDDomicilio = IdDomicilio;
                    domicilioAux.Direccion = (string)datosDomicilio.Lector["DIRECCION"];
                    domicilioAux.Localidad = (string)datosDomicilio.Lector["LOCALIDAD"];
                    domicilioAux.Provincia = (string)datosDomicilio.Lector["PROVINCIA"];
                    domicilioAux.Descripcion = datosDomicilio.Lector["DESCRIPCION"] is DBNull ? "S/D" : (string)datosDomicilio.Lector["DESCRIPCION"];

                    return domicilioAux;
                }
                else //si no hay registros que leer setea -1 al IdPersona
                {
                    domicilioAux.IDDomicilio = -1;

                    return domicilioAux;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datosDomicilio.CerrarConexion();
            }
        }
    }
}
