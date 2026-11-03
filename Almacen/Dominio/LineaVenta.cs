namespace Almacen.Dominio
{
    public class LineaVenta
    {
        private int aId;
        private Producto aProducto;
        private int aCantidad;
        private double aSubTotal;

        public int Id { get { return aId; } set { aId = value; } }
        public Producto Producto { get { return aProducto; } set { aProducto = value; } }
        public int Cantidad { get { return aCantidad; } set {aCantidad = value; } }
        public double SubTotal { get { return aSubTotal; } set { aSubTotal = value; } }

        public LineaVenta(int pId, Producto pProducto, int pCantidad, double pSubTotal)
        {
            aId = pId;
            aProducto = pProducto;
            aCantidad = pCantidad;
            aSubTotal = pSubTotal;
        }
    }
}
