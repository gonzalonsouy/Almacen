
using Microsoft.Data.SqlClient;
using System.Data;

namespace Almacen.Persistencia
{
    public class Conexion
    {
        private static string source = "localhost";
        private static string baseDatos = "Almacen";
        private static string cadenaConexion = "Data Source="+source+
            ";Initial Catalog="+baseDatos+";Integrated Security=SSPI; Encrypt=False";

        public bool Ejecutar(string sql)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                SqlCommand comando = new SqlCommand(sql, conexion);
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
        public DataSet Consulta(string sql)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                SqlDataAdapter adaptador = new SqlDataAdapter(sql, conexion);
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
