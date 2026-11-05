namespace Almacen.Dominio
{
    public class Producto
    {
        private int aId;
        private string aNombre;
        private string aTipo;
        private int aStock;
        private double aPrecio;

        public int Id { get { return aId; } set { aId = value; } }
        public string Nombre { get { return aNombre; } set { aNombre = value; } }
        public string Tipo { get { return aTipo; } set { aTipo = value; } }
        public int Stock { get { return aStock; } set { aStock = value; } }
        public double Precio { get { return aPrecio; } set {aPrecio = value; } }

        public Producto(int pId, string pNombre, string pTipo, int pStock, double pPrecio)
        {
            aId = pId;
            aNombre = pNombre;
            aTipo = pTipo;
            aStock = pStock;
            aPrecio = pPrecio;
        }
        public Producto()
        {
         
        }
    }
}
