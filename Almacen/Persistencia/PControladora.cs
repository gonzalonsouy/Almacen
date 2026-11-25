using Almacen.Dominio;

namespace Almacen.Persistencia
{
    public class PControladora
    {
        #region " Clientes "
        public List<Cliente> ListaClientes()
        {
            return new PCliente().ListaClientes();
        }
        public bool AltaCliente(Cliente mCliente)
        {
            return new PCliente().Alta(mCliente);
        }
        public bool BajaCliente(int pId)
        {
            return new PCliente().Baja(pId);
        }
        public bool ModificarCliente(int pId, string pNombre, string pApellido, string pDireccion, string pTelefono)
        {
            return new PCliente().Modificar(pId, pNombre, pApellido, pDireccion, pTelefono);
        }
        public int ProximoClienteId()
        {
            return new PCliente().ProximoId();
        }
        #endregion

        #region " Productos "
        public List<Producto> ListaProductos()
        {
            return new PProducto().ListaProductos();
        }
        public bool AltaProducto(Producto mProducto)
        {
            return new PProducto().Alta(mProducto);
        }
        public bool BajaProducto(int pId)
        {
            return new PProducto().Baja(pId);
        }
        public bool ModificarProducto(int pId, string pNombre, string pTipo, int pStock, double pPrecio)
        {
            return new PProducto().Modificar(pId, pNombre, pTipo, pStock, pPrecio);
        }
        public bool DescontarStock(int pId, int pCantidad)
        {
            return new PProducto().DescontarStock(pId, pCantidad);
        }
        public int ProximoProductoId()
        {
            return new PProducto().ProximoId();
        }
        #endregion

        #region " Ventas "
        public List<Venta> ListaVentas()
        {
            return new PVenta().ListaVentas();
        }
        public bool AltaVenta(Venta mVenta)
        {
            return new PVenta().Alta(mVenta);
        }
        public bool BajaVenta(int pId)
        {
            return new PVenta().Baja(pId);
        }
        //public bool ModificarVenta(Venta mVenta)
        //{
        //    return new PVenta().Modificar(mVenta);
        //}
        public int ProximoVentaId()
        {
            return new PVenta().ProximoIdVenta();
        }
        public int ProximoLineaId()
        {
            return new PVenta().ProximoIdLinea();
        }
        #endregion
    }
}
