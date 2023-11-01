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
                datosViaje.SetearConsulta("SELECT xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                datosViaje.EjecutarConsulta();

                while (datosViaje.Lector.Read())
                {
                    Viaje aux = new Viaje();

                    aux.NumViaje = (int)datosViaje.Lector["NumViaje"];

                    aux.IDChofer = (int)datosViaje.Lector["IDChofer"];

                    aux.IDCliente = (int)datosViaje.Lector["IDCliente"];

                    aux.TipoViaje = (string)datosViaje.Lector["TipoViaje"];

                    aux.Importe = (decimal)datosViaje.Lector["Importe"];

                    //aux.Origen = (string)datosViaje.Lector["Origen"];                             objeto

                    //aux.Destinos = (string)datosViaje.Lector["Destinos"];                         lista

                    aux.Estado = (string)datosViaje.Lector["Estado"];

                    aux.FechaHoraViaje = (DateTime)datosViaje.Lector["FechaHoraViaje"];

                    aux.MedioDePago = (string)datosViaje.Lector["MedioDePago"];

                    aux.Pagado = (bool)datosViaje.Lector["Pagado"];

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
