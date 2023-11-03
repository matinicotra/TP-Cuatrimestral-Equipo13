using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class VehiculoNegocio
    {
        private List<Vehiculo> vehiculos = new List<Vehiculo>();

        public List<Vehiculo> ObtenerDatos()
        {
            AccesoDatos datosVehiculo = new AccesoDatos();

            try
            {
                datosVehiculo.SetearConsulta("SELECT V.IDVEHICULO, YEAR(V.MODELO) MODELO, V.PATENTE, V.ESTADO, TV.TIPO, TV.CANT_ASIENTOS FROM VEHICULOS V INNER JOIN TIPOS_VEHICULOS TV ON TV.IDTIPO = V.IDTIPO");
                datosVehiculo.EjecutarConsulta();

                while (datosVehiculo.Lector.Read())
                {
                    Vehiculo auxVehiculo = new Vehiculo();

                    auxVehiculo.IDVehiculo = (int)datosVehiculo.Lector["IDVEHICULO"];
                    auxVehiculo.Modelo = (int)datosVehiculo.Lector["MODELO"];
                    auxVehiculo.Patente = (string)datosVehiculo.Lector["PATENTE"];
                    auxVehiculo.Estado = (bool)datosVehiculo.Lector["ESTADO"];
                    auxVehiculo.Tipo.NombreTipo = (string)datosVehiculo.Lector["TIPO"];
                    auxVehiculo.Tipo.CantAsientos = (int)datosVehiculo.Lector["CANT_ASIENTOS"];

                    vehiculos.Add(auxVehiculo);
                }

                return vehiculos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosVehiculo.CerrarConexion();
            }

        }
    }
}
