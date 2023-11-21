using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ViajeNegocio
    {
        private List<Viaje> viajes = new List<Viaje>();

        public List<Viaje> ObtenerDatos()
        {
            AccesoDatos datosViaje = new AccesoDatos();

            try
            {
                datosViaje.SetearConsulta("SELECT IDCHOFER, IDCLIENTE, TIPOVIAJE, IMPORTE, IDDOMORIGEN, IDDOMDESTINO1, IDDOMDESTINO2, IDDOMDESTINO3, ESTADO, FECHAHORAVIAJE, PAGADO, MEDIODEPAGO FROM VIAJES WHERE IDVIAJE = @IDVIAJE");
                datosViaje.EjecutarConsulta();

                while (datosViaje.Lector.Read())
                {
                    Viaje aux = new Viaje();

                    aux.NumViaje = (int)datosViaje.Lector["IDVIAJE"];

                    aux.IDChofer = (int)datosViaje.Lector["IDCHOFER"];

                    aux.IDCliente = (int)datosViaje.Lector["IDCLIENTE"];

                    aux.TipoViaje = (string)datosViaje.Lector["TIPOVIAJE"];

                    aux.Importe = (decimal)datosViaje.Lector["IMPORTE"];

                    aux.Origen.IDDomicilio = (long)datosViaje.Lector["IDDOMORIGEN"];

                    //aux.Destinos= (long)datosViaje.Lector["IDDOMDESTINO1"];

                    aux.Estado = (string)datosViaje.Lector["ESTADO"];

                    aux.FechaHoraViaje = (DateTime)datosViaje.Lector["FECHAHORAVIAJE"];

                    aux.MedioDePago = (string)datosViaje.Lector["MEDIODEPAGO"];

                    aux.Pagado = (bool)datosViaje.Lector["PAGADO"];

                    viajes.Add(aux);
                }

                return viajes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosViaje.CerrarConexion();
            }

        }
    }
}
