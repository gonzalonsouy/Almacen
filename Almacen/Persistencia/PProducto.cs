using Almacen.Dominio;
using System.Collections;
using System.Data;

namespace Almacen.Persistencia
{
    public class PProducto
    {
        private Conexion Conexion = new Conexion();

        public List<Producto> ListaProductos()
        {
            string sql = "SELECT * FROM Producto";

            DataSet datos = Conexion.Consultar(sql);

            List<Producto> lista = new List<Producto>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Producto unProducto = new Producto(
                    int.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    int.Parse(fila[3].ToString()),
                    double.Parse(fila[4].ToString())
                    );
                lista.Add(unProducto);
            }
            return lista;
        }

        public bool Alta(Producto unProducto)
        {
            string sql = "INSERT INTO producto (id, nombre, tipo, stock, precio) "
                + "VALUES (" + unProducto.Id + ",'" + unProducto.Nombre + "','" + unProducto.Tipo + "',"
                + unProducto.Stock + "," + unProducto.Precio + ")";

            return Conexion.Ejecutar(sql);
        }
        public bool Baja(int pId)
        {
            string sql = "DELETE FROM producto WHERE id = " + pId.ToString();

            return Conexion.Ejecutar(sql);
        }
        public bool Modificar(int pId, string pNombre, string pTipo, int pStock, double pPrecio)
        {
            string sql = "UPDATE producto "
                + "SET nombre = '" + pNombre + "',"
                + "tipo = '" + pTipo + "',"
                + "stock = " + pStock + ","
                + "precio = " + pPrecio + " "
                + "WHERE id = " + pId.ToString();

            return Conexion.Ejecutar(sql);
        }
        public bool DescontarStock(int pId, int pCantidad)
        {
            string sql = "UPDATE producto "
                + "SET stock = stock - " + pCantidad + " "
                + "WHERE id = " + pId.ToString();

            return Conexion.Ejecutar(sql);
        }
        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(id),0)+1) FROM producto";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}
