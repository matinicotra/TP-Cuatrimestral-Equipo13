using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public static class ZonaNegocio
    {
        //----------------METODOS--------------------------
        public static List<Zona> ObtenerZonas(int idZona = -1)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Zona> listAux = new List<Zona>();

            try
            {
                if (idZona == -1)
                {
                    datos.SetearConsulta("SELECT IDZONA, NOMBREZONA FROM ZONAS");
                    datos.EjecutarConsulta();

                    while (datos.Lector.Read())
                    {
                        Zona aux = new Zona();

                        aux.IDZona = datos.Lector["IDZONA"] is DBNull ? -1 : (int)datos.Lector["IDZONA"];
                        aux.NombreZona = datos.Lector["NOMBREZONA"] is DBNull ? "S/Z" : (string)datos.Lector["NOMBREZONA"];

                        listAux.Add(aux);
                    }

                }
                else
                {
                    datos.SetearConsulta("SELECT IDZONA, NOMBREZONA FROM ZONAS WHERE IDZONA = @IDZONA");
                    
                    datos.SetearParametro("@IDZONA", idZona);
                    
                    datos.EjecutarConsulta();
                    
                    datos.Lector.Read();
                    
                    Zona aux = new Zona();
                    
                    aux.IDZona = datos.Lector["IDZONA"] is DBNull ? -1 : (int)datos.Lector["IDZONA"];
                    aux.NombreZona = datos.Lector["NOMBREZONA"] is DBNull ? "S/Z" : (string)datos.Lector["NOMBREZONA"];
                    
                    listAux.Add(aux);
                }

                return listAux;
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
