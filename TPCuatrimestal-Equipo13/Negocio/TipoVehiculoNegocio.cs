using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoVehiculoNegocio
    {
        private List<TipoVehiculo> tipoVehiculo = new List<TipoVehiculo>();

        //----------------METODOS--------------------------
        public List<TipoVehiculo> ObtenerDatos()
        {
            AccesoDatos datosTipoVehiculo = new AccesoDatos();

            try
            {
                datosTipoVehiculo.SetearConsulta("SELECT IDTIPO, TIPO, CANT_ASIENTOS from TIPOS_VEHICULOS");
                datosTipoVehiculo.EjecutarConsulta();

                while (datosTipoVehiculo.Lector.Read())
                {
                    TipoVehiculo auxTipoVehiculo = new TipoVehiculo();

                    auxTipoVehiculo.IDTipo = datosTipoVehiculo.Lector["IDTIPO"] is DBNull? -1 : (int)datosTipoVehiculo.Lector["IDTIPO"];
                    auxTipoVehiculo.NombreTipo = datosTipoVehiculo.Lector["TIPO"] is DBNull ? "S/T" : (string)datosTipoVehiculo.Lector["TIPO"];
                    auxTipoVehiculo.CantAsientos = datosTipoVehiculo.Lector["CANT_ASIENTOS"] is DBNull ? 0 : (int)datosTipoVehiculo.Lector["CANT_ASIENTOS"];                    

                    tipoVehiculo.Add(auxTipoVehiculo);
                }

                return tipoVehiculo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosTipoVehiculo.CerrarConexion();
            }
        }
    }
}
