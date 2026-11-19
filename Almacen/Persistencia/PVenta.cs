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
                Venta unaVenta = new Venta(
                    int.Parse(fila[0].ToString()),
                    DateTime.Parse(fila[1].ToString()),
                    unaControladora.BuscarCliente(int.Parse(fila[2].ToString())),
                    ListaLineasVenta(int.Parse(fila[0].ToString())),
                    double.Parse(fila[3].ToString())
                    );
                lista.Add(unaVenta);
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

        public bool Alta(Venta unaVenta)
        {
            string sql = "INSERT INTO venta (id, fecha, idCliente, total) "
                + "VALUES (" + unaVenta.Id + ",'" + unaVenta.Fecha.ToShortDateString() + "'," + unaVenta.Cliente.Id + "," + unaVenta.Total + ")";

            if (Conexion.Ejecutar(sql))
            {
                return AltaLineasVenta(unaVenta.LineasVenta, unaVenta.Id);
            }
            return false;
        }
        public bool AltaLineasVenta(List<LineaVenta> lineasVenta, int pIdVenta)
        {
            string sql = "";
            foreach (LineaVenta unaLinea in lineasVenta)
            {
                sql += " INSERT INTO LineaVenta (id, idVenta, idProducto, cantidad, subtotal) "
                    + "VALUES (" + unaLinea.Id + "," + pIdVenta + "," + unaLinea.Producto.Id + "," + unaLinea.Cantidad + "," + unaLinea.SubTotal + "); ";
            }
            return Conexion.Ejecutar(sql);
        }
        public bool Baja(int pId)
        {
            string sql = "DELETE FROM venta WHERE id = " + pId.ToString();
            string sqlLineas = "DELETE FROM LineaVenta WHERE idVenta = " + pId.ToString();
            Conexion.Ejecutar(sqlLineas);
            return Conexion.Ejecutar(sql);
        }
        //public bool Modificar(Venta unaVenta)
        //{
        //    string sql = "UPDATE venta "
        //        + "SET nombre = '" + unaVenta.Nombre + "',"
        //        + "apellido = '" + unaVenta.Apellido + "',"
        //        + "direccion = '" + unaVenta.Direccion + "',"
        //        + "telefono = '" + unaVenta.Telefono + "' "
        //        + "WHERE id = " + unaVenta.Id.ToString();

        //    return Conexion.Ejecutar(sql);
        //}
        public int ProximoIdVenta()
        {
            string sql = "SELECT (ISNULL(MAX(id),0)+1) FROM venta";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
        public int ProximoIdLinea()
        {
            string sql = "SELECT (ISNULL(MAX(id),0)+1) FROM LineaVenta";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}
