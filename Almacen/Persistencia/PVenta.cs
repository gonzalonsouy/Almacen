using System.Data;
using Almacen.Dominio;

namespace Almacen.Persistencia
{
    public class PVenta
    {
        private Conexion Conexion = new Conexion();
        
        public List<Venta> ListaVentas()
        {
            string sql = "SELECT * FROM Venta";

            DataSet datos = Conexion.Consultar(sql);

            List<Venta> lista = new List<Venta>();
            
            Controladora unaControladora = new Controladora();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Venta unVenta = new Venta(
                    int.Parse(fila[0].ToString()),
                    DateTime.Parse(fila[1].ToString()),
                    unaControladora.BuscarCliente(int.Parse(fila[2].ToString())),
                    ListaLineasVenta(int.Parse(fila[0].ToString())),
                    double.Parse(fila[3].ToString())
                    );
                lista.Add(unVenta);
            }
            return lista;
        }

        public List<LineaVenta> ListaLineasVenta(int pIdVenta)
        {
            string sql = "SELECT * FROM LineaVenta WHERE idVenta = " + pIdVenta.ToString();

            DataSet datos = Conexion.Consultar(sql);
            List<LineaVenta> lista = new List<LineaVenta>();
            Controladora unaControladora = new Controladora();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                LineaVenta unaLineaVenta = new LineaVenta(
                    int.Parse(fila[0].ToString()),
                    unaControladora.BuscarProducto(int.Parse(fila[2].ToString())),
                    int.Parse(fila[3].ToString()),
                    double.Parse(fila[4].ToString())
                    );
                lista.Add(unaLineaVenta);
            }
            return lista;
        }

        public bool Alta(Venta unVenta)
        {
            string sql = "INSERT INTO venta (id, fecha, idCliente, total) "
                + "VALUES (" + unVenta.Id + ",'" + unVenta.Fecha + "'," + unVenta.Cliente.Id + "," + unVenta.Total + ")";

            return Conexion.Ejecutar(sql);
        }
        public bool Baja(int pId)
        {
            string sql = "DELETE FROM venta WHERE id = " + pId.ToString();

            return Conexion.Ejecutar(sql);
        }
        public bool Modificar(Venta unVenta)
        {
            string sql = "UPDATE venta "
                + "SET nombre = '" + unVenta.Nombre + "',"
                + "apellido = '" + unVenta.Apellido + "',"
                + "direccion = '" + unVenta.Direccion + "',"
                + "telefono = '" + unVenta.Telefono + "' "
                + "WHERE id = " + unVenta.Id.ToString();

            return Conexion.Ejecutar(sql);
        }
        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(id),0)+1) FROM venta";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}
