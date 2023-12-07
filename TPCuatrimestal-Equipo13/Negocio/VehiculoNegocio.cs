using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VehiculoNegocio
    {
        private List<Vehiculo> vehiculos = new List<Vehiculo>();

        public List<Vehiculo> ObtenerDatos(bool cargarInactivos = false)
        {
            AccesoDatos datosVehiculo = new AccesoDatos();

            try
            {
                datosVehiculo.SetearConsulta("SELECT V.IDVEHICULO, V.MODELO, V.PATENTE, V.ESTADO, TV.TIPO, TV.CANT_ASIENTOS FROM VEHICULOS V INNER JOIN TIPOS_VEHICULOS TV ON TV.IDTIPO = V.IDTIPO");
                datosVehiculo.EjecutarConsulta();

                while (datosVehiculo.Lector.Read())
                {
                    Vehiculo auxVehiculo = new Vehiculo();

                    auxVehiculo.IDVehiculo = datosVehiculo.Lector["IDVEHICULO"] is DBNull ? -1 : (int)datosVehiculo.Lector["IDVEHICULO"];
                    auxVehiculo.Modelo = datosVehiculo.Lector["MODELO"] is DBNull ? 1900 : (int)datosVehiculo.Lector["MODELO"];
                    auxVehiculo.Patente = datosVehiculo.Lector["PATENTE"] is DBNull ? " " : (string)datosVehiculo.Lector["PATENTE"];
                    auxVehiculo.Estado = datosVehiculo.Lector["ESTADO"] is DBNull ? false : (bool)datosVehiculo.Lector["ESTADO"];
                    auxVehiculo.Tipo.NombreTipo = datosVehiculo.Lector["TIPO"] is DBNull ? " " : (string)datosVehiculo.Lector["TIPO"];
                    auxVehiculo.Tipo.CantAsientos = datosVehiculo.Lector["CANT_ASIENTOS"] is DBNull ? 0 : (int)datosVehiculo.Lector["CANT_ASIENTOS"];

                    if (!auxVehiculo.Estado && !cargarInactivos)
                    {
                    }
                    else
                    {
                        vehiculos.Add(auxVehiculo);
                    }
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

        public void AltaModificacionVehiculo(Vehiculo aux, bool esAlta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (!esAlta)
                {
                    datos.SetearConsulta("INSERT INTO VEHICULOS (IDTIPO,MODELO,PATENTE,ESTADO) values (@IdTipoVehiculo, @Modelo, @Patente, 1)");
                    datos.SetearParametro("@IdTipoVehiculo", aux.Tipo.IDTipo);
                    datos.SetearParametro("@Modelo", aux.Modelo);
                    datos.SetearParametro("@Patente", aux.Patente);
                }
                else
                {
                    datos.SetearConsulta("UPDATE VEHICULOS SET IDTIPO = @IdTipoVehiculo, MODELO = @Modelo, PATENTE = @Patente, ESTADO = 1 WHERE IDVEHICULO = @IdVehiculo");
                    datos.SetearParametro("@IdTipoVehiculo", aux.Tipo.IDTipo);
                    datos.SetearParametro("@Modelo", aux.Modelo);
                    datos.SetearParametro("@Patente", aux.Patente);
                    datos.SetearParametro("@IdVehiculo", aux.IDVehiculo);
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

        public void BajaFisicaVehiculo(int IDVehiculo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE CHOFER SET IDVEHICULO = NULL WHERE IDVEHICULO = @ID");
                datos.SetearParametro("@ID", IDVehiculo);
                datos.EjecutarAccion();
                datos.CerrarConexion();

                datos.SetearConsulta("DELETE FROM VEHICULOS WHERE IDVEHICULO = @IDVEHICULO");
                datos.SetearParametro("@IDVEHICULO", IDVehiculo);
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

        public void BajaoAltaLogicaVehiculo(int IDVehiculo, bool esAltaLogica)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (esAltaLogica)
                {
                    datos.SetearConsulta("UPDATE VEHICULOS SET ESTADO = 1 WHERE IDVEHICULO = @IDVEHICULO");
                }
                else
                {
                    datos.SetearConsulta("UPDATE VEHICULOS SET ESTADO = 0 WHERE IDVEHICULO = @IDVEHICULO");
                }

                datos.SetearParametro("@IDVEHICULO", IDVehiculo);

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
        public List<Vehiculo> Filtrar(string campo, string buscar)
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            AccesoDatos datos = new AccesoDatos();

            string consulta = "SELECT V.IDVEHICULO, V.MODELO, V.PATENTE, V.ESTADO, TV.TIPO, TV.CANT_ASIENTOS FROM VEHICULOS V INNER JOIN TIPOS_VEHICULOS TV ON V.IDTIPO = TV.IDTIPO ";

            try
            {
                if (campo == "MODELO")
                {
                    consulta += "WHERE V.MODELO LIKE '%" + buscar + "%'";
                }
                else if (campo == "TIPO")
                {
                    consulta += "WHERE UPPER(TV.TIPO) LIKE '%" + buscar.ToUpper() + "%'";
                }
                else if (campo == "PATENTE")
                {
                    consulta += "WHERE UPPER(V.PATENTE) LIKE '%" + buscar.ToUpper() + "%'";
                }

                datos.SetearConsulta(consulta);
                datos.EjecutarConsulta();

                while (datos.Lector.Read())
                {
                    Vehiculo aux = new Vehiculo();

                    aux.IDVehiculo = datos.Lector["IDVEHICULO"] is DBNull ? -1 : (int)datos.Lector["IDVEHICULO"];
                    aux.Modelo = datos.Lector["MODELO"] is DBNull ? 1900 : (int)datos.Lector["MODELO"];
                    aux.Patente = datos.Lector["PATENTE"] is DBNull ? " " : (string)datos.Lector["PATENTE"];
                    aux.Estado = datos.Lector["ESTADO"] is DBNull ? false : (bool)datos.Lector["ESTADO"];
                    aux.Tipo.NombreTipo = datos.Lector["TIPO"] is DBNull ? " " : (string)datos.Lector["TIPO"];
                    aux.Tipo.CantAsientos = datos.Lector["CANT_ASIENTOS"] is DBNull ? 0 : (int)datos.Lector["CANT_ASIENTOS"];

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

            return lista;
        }
    }
}
