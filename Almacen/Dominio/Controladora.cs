namespace Almacen.Dominio
{
    public class Controladora
    {
        private static List<Producto> aListaProductos = new List<Producto>();
        private static List<Cliente> aListaClientes = new List<Cliente>();
        private static List<Venta> aListaVentas = new List<Venta>();

        #region Productos

        public List<Producto> ListarProductos()
        {
            return aListaProductos;
        }
        public Producto BuscarProducto(int pId)
        {
            foreach (Producto unProducto in aListaProductos)
            {
                if(unProducto.Id == pId)
                {
                    return unProducto;
                }
            }
            return null;
        }
        public bool AltaProducto(Producto pProducto)
        {
            Producto ComparoProducto = BuscarProducto(pProducto.Id);
            if(ComparoProducto == null)
            {
                aListaProductos.Add(pProducto);
                return true;
            }
            return false;
        }
        public bool BajaProducto(int pId)
        {
            Producto ProductoAEliminar = BuscarProducto(pId);
            if(ProductoAEliminar != null)
            {
                aListaProductos.Remove(ProductoAEliminar);
                return true;
            }
            return false;
        }
        public bool ModificarProducto(int pId, string pNombre, string pTipo, int pStock, double pPrecio)
        {
            Producto ProductoAModificar = BuscarProducto(pId);
            if(ProductoAModificar != null)
            {
                ProductoAModificar.Nombre = pNombre;
                ProductoAModificar.Tipo = pTipo;
                ProductoAModificar.Stock = pStock;
                ProductoAModificar.Precio = pPrecio;
                return true;
            }
            return false;
        }
        #endregion

        #region Clientes

        public List<Cliente> ListarClientes()
        {
            return aListaClientes;
        }
        public Cliente BuscarCliente(int pId)
        {
            foreach (Cliente unCliente in aListaClientes)
            {
                if (unCliente.Id == pId)
                {
                    return unCliente;
                }
            }
            return null;
        }
        public bool AltaCliente(Cliente pCliente)
        {
            Cliente ComparoCliente = BuscarCliente(pCliente.Id);
            if (ComparoCliente == null)
            {
                aListaClientes.Add(pCliente);
                return true;
            }
            return false;
        }
        public bool BajaCliente(int pId)
        {
            Cliente ClienteAEliminar = BuscarCliente(pId);
            if (ClienteAEliminar != null)
            {
                aListaClientes.Remove(ClienteAEliminar);
                return true;
            }
            return false;
        }
        public bool ModificarCliente(int pId, string pNombre, string pApellido, string pDireccion, string pTelefono)
        {
            Cliente ClienteAModificar = BuscarCliente(pId);
            if (ClienteAModificar != null)
            {
                ClienteAModificar.Nombre = pNombre;
                ClienteAModificar.Apellido = pApellido;
                ClienteAModificar.Direccion = pDireccion;
                ClienteAModificar.Telefono = pTelefono;
                return true;
            }
            return false;
        }
        #endregion

        #region Ventas

        public List<Venta> ListarVentas()
        {
            return aListaVentas;
        }
        public Venta BuscarVenta(int pId)
        {
            foreach (Venta unVenta in aListaVentas)
            {
                if (unVenta.Id == pId)
                {
                    return unVenta;
                }
            }
            return null;
        }
        public bool AltaVenta(Venta pVenta)
        {
            Venta ComparoVenta = BuscarVenta(pVenta.Id);
            if (ComparoVenta == null)
            {
                aListaVentas.Add(pVenta);
                return true;
            }
            return false;
        }
        public bool BajaVenta(int pId)
        {
            Venta VentaAEliminar = BuscarVenta(pId);
            if (VentaAEliminar != null)
            {
                aListaVentas.Remove(VentaAEliminar);
                return true;
            }
            return false;
        }
        //public bool ModificarVenta(int pId, string pNombre, string pApellido, string pDireccion, string pTelefono)
        //{
        //    Venta VentaAModificar = BuscarVenta(pId);
        //    if (VentaAModificar != null)
        //    {
        //        VentaAModificar.Nombre = pNombre;
        //        VentaAModificar.Apellido = pApellido;
        //        VentaAModificar.Direccion = pDireccion;
        //        VentaAModificar.Telefono = pTelefono;
        //        return true;
        //    }
        //    return false;
        //}
        #endregion
    }
}
