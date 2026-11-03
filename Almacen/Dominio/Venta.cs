namespace Almacen.Dominio
{
    public class Venta
    {
        private int aId;
        private DateTime aFecha;
        private Cliente aCliente;
        private List<LineaVenta> aLineasVenta;
        private double aTotal;

        public int Id { get { return aId; } set { aId = value; } }
        public DateTime Fecha { get { return aFecha; } set { aFecha = value; } }
        public Cliente Cliente { get { return aCliente; } set { aCliente = value; } }        
        public List<LineaVenta> LineasVenta { get  { return aLineasVenta; } set { aLineasVenta = value; } }
        public double Total { get { return aTotal; } set { aTotal = value; } }

        public Venta(int pId, DateTime pFecha, Cliente pCliente, List<LineaVenta> pLineasVenta, double pTotal)
        {
            aId = pId;
            aFecha = pFecha;
            aCliente = pCliente;
            aLineasVenta = pLineasVenta;
            aTotal = pTotal;
        }

    }
}
