
using Microsoft.Data.SqlClient;
using System.Data;

namespace Almacen.Persistencia
{
    public class Conexion
    {
        private static string source = "(localdb)\\MSSQLLocalDB";
        private static string baseDatos = "Almacen";
        private static string cadenaConexion = "Data Source="+source+
            ";Initial Catalog="+baseDatos+";Integrated Security=SSPI; Encrypt=False";

        private static string formateoFecha = "set dateformat dmy ";

        public bool Ejecutar(string sql)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                SqlCommand comando = new SqlCommand(formateoFecha + sql, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                comando.Dispose();
                conexion.Close();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception("Error en la conexion SQL : " + sql, e);
            }
        }
        public DataSet Consultar(string sql)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                SqlDataAdapter adaptador = new SqlDataAdapter(formateoFecha + sql, conexion);
                DataSet resultado = new DataSet();
                adaptador.Fill(resultado);
                adaptador.Dispose();
                conexion.Close();
                return resultado;
            }
            catch (Exception e)
            {
                throw new Exception("Error en la conexion SQL : " + sql, e);
            }
        }
    }
}
