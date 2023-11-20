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

                    auxTipoVehiculo.IDTipo = (int)datosTipoVehiculo.Lector["IDTIPO"];
                    auxTipoVehiculo.NombreTipo = (string)datosTipoVehiculo.Lector["TIPO"];
                    auxTipoVehiculo.CantAsientos = (int)datosTipoVehiculo.Lector["CANT_ASIENTOS"];                    

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
