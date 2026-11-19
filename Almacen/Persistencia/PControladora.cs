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
        public bool ModificarCliente(Cliente mCliente)
        {
            return new PCliente().Modificar(mCliente);
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
        public bool ModificarProducto(Producto mProducto)
        {
            return new PProducto().Modificar(mProducto);
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
