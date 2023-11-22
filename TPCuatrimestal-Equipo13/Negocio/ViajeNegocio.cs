﻿using System;
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
                datosViaje.SetearConsulta("SELECT IDVIAJE, IDCHOFER, IDCLIENTE, TIPOVIAJE, IMPORTE, IDDOMORIGEN, IDDOMDESTINO1, IDDOMDESTINO2, IDDOMDESTINO3, ESTADO, FECHAHORAVIAJE, PAGADO, MEDIODEPAGO FROM VIAJES");
                
                datosViaje.EjecutarConsulta();

                while (datosViaje.Lector.Read())
                {
                    Viaje aux = new Viaje();
                    DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
                    Domicilio destino1 = new Domicilio();
                    Domicilio destino2 = new Domicilio();
                    Domicilio destino3 = new Domicilio();

                    aux.NumViaje = datosViaje.Lector["IDVIAJE"] is DBNull ? -1 : (long)datosViaje.Lector["IDVIAJE"];

                    aux.IDChofer = datosViaje.Lector["IDCHOFER"] is DBNull ? -1 : (int)datosViaje.Lector["IDCHOFER"];

                    aux.IDCliente = datosViaje.Lector["IDCLIENTE"] is DBNull ? -1 : (int)datosViaje.Lector["IDCLIENTE"];

                    aux.TipoViaje = datosViaje.Lector["TIPOVIAJE"] is DBNull ? "S/T" : (string)datosViaje.Lector["TIPOVIAJE"];

                    aux.Importe = datosViaje.Lector["IMPORTE"] is DBNull ? -1 : (decimal)datosViaje.Lector["IMPORTE"];

                    aux.Origen.IDDomicilio = datosViaje.Lector["IDDOMORIGEN"] is DBNull ? -1 : (long)datosViaje.Lector["IDDOMORIGEN"];

                    destino1.IDDomicilio = datosViaje.Lector["IDDOMDESTINO1"] is DBNull ? -1 : (long)datosViaje.Lector["IDDOMDESTINO1"];

                    destino2.IDDomicilio = datosViaje.Lector["IDDOMDESTINO2"] is DBNull ? -1 : (long)datosViaje.Lector["IDDOMDESTINO2"];

                    destino3.IDDomicilio = datosViaje.Lector["IDDOMDESTINO3"] is DBNull ? -1 : (long)datosViaje.Lector["IDDOMDESTINO3"];

                    aux.Estado = datosViaje.Lector["ESTADO"] is DBNull ? "S/E" : (string)datosViaje.Lector["ESTADO"];

                    aux.FechaHoraViaje = datosViaje.Lector["FECHAHORAVIAJE"] is DBNull ? DateTime.Parse("01-01-1900") : (DateTime)datosViaje.Lector["FECHAHORAVIAJE"];

                    aux.MedioDePago = datosViaje.Lector["MEDIODEPAGO"] is DBNull ? "S/MP" : (string)datosViaje.Lector["MEDIODEPAGO"];

                    aux.Pagado = datosViaje.Lector["PAGADO"] is DBNull ? false : (bool)datosViaje.Lector["PAGADO"];


                    if (destino1.IDDomicilio != -1)
                    {
                        destino1 = domicilioNegocio.ObtenerDomicilio(destino1.IDDomicilio);
                        aux.Destinos.Add(destino1);
                    }

                    if (destino2.IDDomicilio != -1)
                    {
                        destino2 = domicilioNegocio.ObtenerDomicilio(destino2.IDDomicilio);
                        aux.Destinos.Add(destino2);
                    }

                    if (destino3.IDDomicilio != -1)
                    {
                        destino3 = domicilioNegocio.ObtenerDomicilio(destino3.IDDomicilio);
                        aux.Destinos.Add(destino3);
                    }

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

                datos.SetearParametro("@IDVIAJE", IdViaje);

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

        public void ModificacionViaje(Viaje viaje)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE VIAJES SET IDCHOFER = @IDCHOFER, IDCLIENTE = @IDCLIENTE, TIPOVIAJE = @TIPOVIAJE, IMPORTE = @IMPORTE, IDDOMORIGEN = @IDDOMORIGEN, IDDOMDESTINO1 = @IDDOMDESTINO1, IDDOMDESTINO2 = @IDDOMDESTINO2, IDDOMDESTINO3 = @IDDOMDESTINO3, ESTADO = @ESTADO, FECHAHORAVIAJE = @FECHAHORAVIAJE, PAGADO = @PAGADO, MEDIODEPAGO = @MEDIODEPAGO WHERE IDVIAJE = @IDVIAJE)");

                datos.SetearParametro("@IDVIAJE", viaje.NumViaje);
                datos.SetearParametro("@IDCHOFER", viaje.IDChofer);
                datos.SetearParametro("@IDCLIENTE", viaje.IDCliente);
                datos.SetearParametro("@TIPOVIAJE", viaje.TipoViaje);
                datos.SetearParametro("@IDDOMORIGEN", viaje.Origen.IDDomicilio);
                datos.SetearParametro("@IDDOMDESTINO1", viaje.Destinos[0].IDDomicilio);
                datos.SetearParametro("@IDDOMDESTINO2", viaje.Destinos[1].IDDomicilio);
                datos.SetearParametro("@IDDOMDESTINO3", viaje.Destinos[2].IDDomicilio);
                datos.SetearParametro("@ESTADO", viaje.Estado);
                datos.SetearParametro("@FECHAHORAVIAJE", viaje.FechaHoraViaje);
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
