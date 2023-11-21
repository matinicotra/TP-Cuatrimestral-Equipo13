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
                    Domicilio destino1 = new Domicilio();
                    Domicilio destino2 = new Domicilio();
                    Domicilio destino3 = new Domicilio();

                    aux.NumViaje = (int)datosViaje.Lector["IDVIAJE"];

                    aux.IDChofer = (int)datosViaje.Lector["IDCHOFER"];

                    aux.IDCliente = (int)datosViaje.Lector["IDCLIENTE"];

                    aux.TipoViaje = (string)datosViaje.Lector["TIPOVIAJE"];

                    aux.Importe = (decimal)datosViaje.Lector["IMPORTE"];

                    aux.Origen.IDDomicilio = (long)datosViaje.Lector["IDDOMORIGEN"];

                    destino1.IDDomicilio = (long)datosViaje.Lector["IDDOMDESTINO1"];

                    destino2.IDDomicilio = (long)datosViaje.Lector["IDDOMDESTINO2"];

                    destino3.IDDomicilio = (long)datosViaje.Lector["IDDOMDESTINO3"];

                    aux.Estado = (string)datosViaje.Lector["ESTADO"];

                    aux.FechaHoraViaje = (DateTime)datosViaje.Lector["FECHAHORAVIAJE"];

                    aux.MedioDePago = (string)datosViaje.Lector["MEDIODEPAGO"];

                    aux.Pagado = (bool)datosViaje.Lector["PAGADO"];

                    aux.Destinos.Add(destino1);
                    aux.Destinos.Add(destino2);
                    aux.Destinos.Add(destino3);

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

        public void BajaViaje(int IdViaje)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("DELETE FROM VIAJES WHERE IDVIAJE = @IDVIAJE");
                datos.SetearParametro("@IDPERSONA", IdViaje);
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

        public void AltaViaje(Viaje viaje)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO VIAJES (IDCHOFER, IDCLIENTE, TIPOVIAJE, IMPORTE, IDDOMORIGEN, IDDOMDESTINO1, IDDOMDESTINO2, IDDOMDESTINO3, ESTADO, FECHAHORAVIAJE, PAGADO, MEDIODEPAGO)");
                datos.SetearParametro("@IDCHOFER", viaje.IDChofer);
                datos.SetearParametro("@IDCLIENTE", viaje.IDCliente);
                datos.SetearParametro("@TIPOVIAJE", viaje.TipoViaje);
                datos.SetearParametro("@IDDOMORIGEN", viaje.Origen.IDDomicilio);
                datos.SetearParametro("@IDDOMDESTINO1", viaje.Destinos[0].IDDomicilio);
                datos.SetearParametro("@IDDOMDESTINO2", viaje.Destinos[1].IDDomicilio);
                datos.SetearParametro("@IDDOMDESTINO3", viaje.Destinos[2].IDDomicilio);
                datos.SetearParametro("@ESTADO", viaje.Estado);
                datos.SetearParametro("@FECHAHORAVIAJE", "GETDATE()");       /// funciona????
                datos.SetearParametro("@PAGADO", viaje.Pagado);
                datos.SetearParametro("@MEDIODEPAGO", viaje.MedioDePago);

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
