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

        public List<Viaje> ObtenerDatos(long idViaje = -1)
        {
            AccesoDatos datosViaje = new AccesoDatos();

            try
            {
                if (idViaje == -1)
                {
                    datosViaje.SetearConsulta("SELECT IDVIAJE, IDCHOFER, IDCLIENTE, TIPOVIAJE, IMPORTE, IDDOMORIGEN, IDDOMDESTINO1, IDDOMDESTINO2, IDDOMDESTINO3, ESTADO, FECHAHORAVIAJE, PAGADO, MEDIODEPAGO FROM VIAJES");
                    datosViaje.EjecutarConsulta();
                }
                else
                {
                    datosViaje.SetearConsulta("SELECT IDVIAJE, IDCHOFER, IDCLIENTE, TIPOVIAJE, IMPORTE, IDDOMORIGEN, IDDOMDESTINO1, IDDOMDESTINO2, IDDOMDESTINO3, ESTADO, FECHAHORAVIAJE, PAGADO, MEDIODEPAGO FROM VIAJES WHERE IDVIAJE = @IDVIAJE");
                    datosViaje.SetearParametro("@IDVIAJE", idViaje);
                    datosViaje.EjecutarConsulta();
                }

                while (datosViaje.Lector.Read())
                {
                    Viaje aux = new Viaje();
                    DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
                    Domicilio destino1 = new Domicilio();
                    Domicilio destino2 = new Domicilio();
                    Domicilio destino3 = new Domicilio();
                    ChoferNegocio ChoferNegocioAux = new ChoferNegocio();
                    ClienteNegocio ClienteNegocioAux = new ClienteNegocio();

                    aux.NumViaje = datosViaje.Lector["IDVIAJE"] is DBNull ? -1 : (long)datosViaje.Lector["IDVIAJE"];

                    aux.IDChofer = datosViaje.Lector["IDCHOFER"] is DBNull ? -1 : (int)datosViaje.Lector["IDCHOFER"];

                    if (aux.IDChofer != -1)
                        aux.ChoferViaje = ChoferNegocioAux.ObtenerDatos(aux.IDChofer)[0];

                    aux.IDCliente = datosViaje.Lector["IDCLIENTE"] is DBNull ? -1 : (int)datosViaje.Lector["IDCLIENTE"];

                    if (aux.IDCliente != -1)
                        aux.ClienteViaje = ClienteNegocioAux.ObtenerDatos(aux.IDCliente)[0];

                    aux.TipoViaje = datosViaje.Lector["TIPOVIAJE"] is DBNull ? "S/T" : (string)datosViaje.Lector["TIPOVIAJE"];

                    aux.Importe = datosViaje.Lector["IMPORTE"] is DBNull ? -1 : (decimal)datosViaje.Lector["IMPORTE"];

                    aux.Origen.IDDomicilio = datosViaje.Lector["IDDOMORIGEN"] is DBNull ? -1 : (long)datosViaje.Lector["IDDOMORIGEN"];
                    if (aux.Origen.IDDomicilio != -1)
                        aux.Origen = domicilioNegocio.ObtenerDomicilio(aux.Origen.IDDomicilio);


                    destino1.IDDomicilio = datosViaje.Lector["IDDOMDESTINO1"] is DBNull ? -1 : (long)datosViaje.Lector["IDDOMDESTINO1"];

                    destino2.IDDomicilio = datosViaje.Lector["IDDOMDESTINO2"] is DBNull ? -1 : (long)datosViaje.Lector["IDDOMDESTINO2"];

                    destino3.IDDomicilio = datosViaje.Lector["IDDOMDESTINO3"] is DBNull ? -1 : (long)datosViaje.Lector["IDDOMDESTINO3"];

                    aux.Estado = datosViaje.Lector["ESTADO"] is DBNull ? "S/E" : (string)datosViaje.Lector["ESTADO"];

                    aux.FechaHoraViaje = datosViaje.Lector["FECHAHORAVIAJE"] is DBNull ? DateTime.Parse("01-01-1900") : (DateTime)datosViaje.Lector["FECHAHORAVIAJE"];

                    aux.MedioDePago = datosViaje.Lector["MEDIODEPAGO"] is DBNull ? "No Especifica" : (string)datosViaje.Lector["MEDIODEPAGO"];

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

        public List<Viaje> ViajesClientesChoferes(long ID, bool EsChofer)
        {
            AccesoDatos datosViaje = new AccesoDatos();

            try
            {
                if (EsChofer)
                {
                    datosViaje.SetearConsulta("SELECT IDVIAJE, IDCLIENTE, TIPOVIAJE, IMPORTE, IDDOMORIGEN, IDDOMDESTINO1, IDDOMDESTINO2, IDDOMDESTINO3, ESTADO, FECHAHORAVIAJE, PAGADO, MEDIODEPAGO FROM VIAJES WHERE IDCHOFER = @IDCHOFER ORDER BY FECHAHORAVIAJE ASC");
                    datosViaje.SetearParametro("@IDCHOFER", ID);
                    datosViaje.EjecutarConsulta();
                }
                else
                {
                    datosViaje.SetearConsulta("SELECT IDVIAJE, IDCLIENTE, TIPOVIAJE, IMPORTE, IDDOMORIGEN, IDDOMDESTINO1, IDDOMDESTINO2, IDDOMDESTINO3, ESTADO, FECHAHORAVIAJE, PAGADO, MEDIODEPAGO FROM VIAJES WHERE IDCLIENTE = @IDCLIENTE ORDER BY FECHAHORAVIAJE ASC");
                    datosViaje.SetearParametro("@IDCLIENTE", ID);
                    datosViaje.EjecutarConsulta();
                }


                while (datosViaje.Lector.Read())
                {
                    Viaje aux = new Viaje();
                    DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
                    Domicilio destino1 = new Domicilio();
                    Domicilio destino2 = new Domicilio();
                    Domicilio destino3 = new Domicilio();
                    ChoferNegocio ChoferNegocioAux = new ChoferNegocio();
                    ClienteNegocio ClienteNegocioAux = new ClienteNegocio();

                    aux.NumViaje = datosViaje.Lector["IDVIAJE"] is DBNull ? -1 : (long)datosViaje.Lector["IDVIAJE"];

                    aux.IDCliente = datosViaje.Lector["IDCLIENTE"] is DBNull ? -1 : (int)datosViaje.Lector["IDCLIENTE"];

                    if (aux.IDCliente != -1)
                        aux.ClienteViaje = ClienteNegocioAux.ObtenerDatos(aux.IDCliente)[0];

                    aux.TipoViaje = datosViaje.Lector["TIPOVIAJE"] is DBNull ? "S/T" : (string)datosViaje.Lector["TIPOVIAJE"];

                    aux.Importe = datosViaje.Lector["IMPORTE"] is DBNull ? -1 : (decimal)datosViaje.Lector["IMPORTE"];

                    aux.Origen.IDDomicilio = datosViaje.Lector["IDDOMORIGEN"] is DBNull ? -1 : (long)datosViaje.Lector["IDDOMORIGEN"];
                    if (aux.Origen.IDDomicilio != -1)
                        aux.Origen = domicilioNegocio.ObtenerDomicilio(aux.Origen.IDDomicilio);


                    destino1.IDDomicilio = datosViaje.Lector["IDDOMDESTINO1"] is DBNull ? -1 : (long)datosViaje.Lector["IDDOMDESTINO1"];

                    destino2.IDDomicilio = datosViaje.Lector["IDDOMDESTINO2"] is DBNull ? -1 : (long)datosViaje.Lector["IDDOMDESTINO2"];

                    destino3.IDDomicilio = datosViaje.Lector["IDDOMDESTINO3"] is DBNull ? -1 : (long)datosViaje.Lector["IDDOMDESTINO3"];

                    aux.Estado = datosViaje.Lector["ESTADO"] is DBNull ? "S/E" : (string)datosViaje.Lector["ESTADO"];

                    aux.FechaHoraViaje = datosViaje.Lector["FECHAHORAVIAJE"] is DBNull ? DateTime.Parse("01-01-1900") : (DateTime)datosViaje.Lector["FECHAHORAVIAJE"];

                    aux.MedioDePago = datosViaje.Lector["MEDIODEPAGO"] is DBNull ? "No Especifica" : (string)datosViaje.Lector["MEDIODEPAGO"];

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

        public void BajaLogicaViaje(long IdViaje)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE VIAJES SET ESTADO = 'Cancelado' WHERE IDVIAJE = @IDVIAJE");

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

        public void CambiarEstado(long IdViaje, string Estado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE VIAJES SET ESTADO = @ESTADO WHERE IDVIAJE = @IDVIAJE");

                datos.SetearParametro("@IDVIAJE", IdViaje);

                datos.SetearParametro("@ESTADO", IdViaje);

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

        public void AltaModificacionViaje(Viaje viaje, bool esAlta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
                if (esAlta)
                {
                    datos.SetearConsulta("INSERT INTO VIAJES (IDCHOFER, IDCLIENTE, TIPOVIAJE, IMPORTE, IDDOMORIGEN, IDDOMDESTINO1, IDDOMDESTINO2, IDDOMDESTINO3, ESTADO, FECHAHORAVIAJE, PAGADO, MEDIODEPAGO) VALUES (@IDCHOFER, @IDCLIENTE, @TIPOVIAJE, @IMPORTE, @IDDOMORIGEN, @IDDOMDESTINO1, @IDDOMDESTINO2, @IDDOMDESTINO3,  @ESTADO, @FECHAHORAVIAJE, @PAGADO, @MEDIODEPAGO)");
                }
                else
                {
                    datos.SetearConsulta("UPDATE VIAJES SET IDCHOFER = @IDCHOFER, IDCLIENTE = @IDCLIENTE, TIPOVIAJE = @TIPOVIAJE, IMPORTE = @IMPORTE, IDDOMORIGEN = @IDDOMORIGEN, IDDOMDESTINO1 = @IDDOMDESTINO1, IDDOMDESTINO2 = @IDDOMDESTINO2, IDDOMDESTINO3 = @IDDOMDESTINO3, ESTADO = @ESTADO, FECHAHORAVIAJE = @FECHAHORAVIAJE, PAGADO = @PAGADO, MEDIODEPAGO = @MEDIODEPAGO WHERE IDVIAJE = @IDVIAJE");
                    datos.SetearParametro("@IDVIAJE", viaje.NumViaje);
                }
                DateTime dateTimeViaje = Convert.ToDateTime(viaje.FechaHoraViaje);
                datos.SetearParametro("@FECHAHORAVIAJE", dateTimeViaje);
                datos.SetearParametro("@IDCHOFER", viaje.IDChofer != 0 ? (object)viaje.IDChofer : DBNull.Value);

                //LOGICA PARA CLIENTE: SI EL CLIENTE YA EXISTE SOLO SETEA SU ID Y PREGUNTA SI EL DOMICILIO ES NUEVO O ES UNO EXISTENTE
                //             (SI VIENE IDCLIENTE = 0 ES CLIENTE NUEVO)

                if (viaje.IDCliente > 0)
                {
                    datos.SetearParametro("@IDCLIENTE", viaje.IDCliente);
                    //DESTINO ORIGEN
                    //si no existe domicilio (devuelve -1) hace un insert con uno nuevo
                    if (domicilioNegocio.existeDomicilio(viaje.Origen) == -1)
                    {
                        domicilioNegocio.AltaModificacionDomicilio(viaje.Origen, true);
                        datos.SetearParametro("@IDDOMORIGEN", domicilioNegocio.ultimoIdDomicilio());
                    }
                    //si existe el domicilio solo setea el id de domicilio
                    else
                    {
                        datos.SetearParametro("@IDDOMORIGEN", domicilioNegocio.existeDomicilio(viaje.Origen));
                    }
                }
                //SI EL CLIENTE ES NUEVO SETEA EL NUEVO CLIENTE Y EL UN NUEVO DOMICILIO
                else
                {
                    if (viaje.IDCliente == 0)
                    {
                        ClienteNegocio clienteNegocio = new ClienteNegocio();
                        viaje.ClienteViaje.Direccion = viaje.Origen;
                        clienteNegocio.AltaModificacionCliente(viaje.ClienteViaje, true);
                        datos.SetearParametro("@IDCLIENTE", clienteNegocio.ultimoIdCliente());
                    }
                    else
                    {
                        datos.SetearParametro("@IDCLIENTE", DBNull.Value);
                    }

                    datos.SetearParametro("@IDDOMORIGEN", domicilioNegocio.ultimoIdDomicilio());
                }



                datos.SetearParametro("@TIPOVIAJE", viaje.TipoViaje);



                //DESTINO 1
                //comprueba si existe el domicilio en el destino 1
                if (domicilioNegocio.existeDomicilio(viaje.Destinos[0]) == -1)
                {
                    domicilioNegocio.AltaModificacionDomicilio(viaje.Destinos[0], true);
                    datos.SetearParametro("@IDDOMDESTINO1", domicilioNegocio.ultimoIdDomicilio());
                }
                //si existe el domicilio solo setea el id de domicilio en destino 1
                else
                {
                    datos.SetearParametro("@IDDOMDESTINO1", domicilioNegocio.existeDomicilio(viaje.Destinos[0]));
                }


                //DESTINO 2
                //comprueba  si tiene mas de 1 destino y hace lo mismo
                if (viaje.Destinos.Count > 1)
                {
                    if (domicilioNegocio.existeDomicilio(viaje.Destinos[1]) == -1)
                    {
                        domicilioNegocio.AltaModificacionDomicilio(viaje.Destinos[1], true);
                        datos.SetearParametro("@IDDOMDESTINO2", domicilioNegocio.ultimoIdDomicilio());
                    }

                    else
                    {
                        datos.SetearParametro("@IDDOMDESTINO2", domicilioNegocio.existeDomicilio(viaje.Destinos[1]));
                    }

                    //DESTINO 3
                    //si  tiene mas de 2 destinos
                    if (viaje.Destinos.Count > 2)
                    {
                        if (domicilioNegocio.existeDomicilio(viaje.Destinos[2]) == -1)
                        {
                            domicilioNegocio.AltaModificacionDomicilio(viaje.Destinos[2], true);
                            datos.SetearParametro("@IDDOMDESTINO3", domicilioNegocio.ultimoIdDomicilio());
                        }
                        else
                        {
                            datos.SetearParametro("@IDDOMDESTINO3", domicilioNegocio.existeDomicilio(viaje.Destinos[2]));
                        }
                    }
                }
                else
                {
                    datos.SetearParametro("@IDDOMDESTINO3", DBNull.Value);
                    datos.SetearParametro("@IDDOMDESTINO2", DBNull.Value);
                }
                datos.SetearParametro("@IMPORTE", viaje.Importe);
                if (viaje.Estado != null)
                    datos.SetearParametro("@ESTADO", viaje.Estado);
                else
                    datos.SetearParametro("@ESTADO", DBNull.Value);
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

        public void PagarDespagarViaje(long IdViaje, bool Pagado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE VIAJES SET PAGADO = @PAGADO WHERE IDVIAJE = @IDVIAJE");

                datos.SetearParametro("@IDVIAJE", IdViaje);

                datos.SetearParametro("@PAGADO", Pagado);

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

        public void FinalizarViaje(long IdViaje)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE VIAJES SET ESTADO = @ESTADO WHERE IDVIAJE = @IDVIAJE");
                datos.SetearParametro("@IDVIAJE", IdViaje);
                datos.SetearParametro("@ESTADO", "Finalizado");
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
