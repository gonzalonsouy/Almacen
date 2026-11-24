using Almacen.Persistencia;

namespace Almacen.Dominio
{
    public class Controladora
    {
        private PControladora Persistencia;
        private static List<Producto> aListaProductos = new List<Producto>();
        private static List<Cliente> aListaClientes = new List<Cliente>();
        private static List<Venta> aListaVentas = new List<Venta>();
        private static List<LineaVenta> aListaLineasVenta = new List<LineaVenta>();

        public Controladora()
        {
            Persistencia = new PControladora();
        }

        #region Productos

        public int ProximoIdProducto()
        {
            return Persistencia.ProximoProductoId();
        }
        public List<Producto> ListarProductos()
        {
            aListaProductos = Persistencia.ListaProductos();
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
                if (Persistencia.AltaProducto(pProducto))
                {
                    aListaProductos.Add(pProducto);
                    return true;
                }
            }
            return false;
        }
        public bool BajaProducto(int pId)
        {
            Producto ProductoAEliminar = BuscarProducto(pId);
            if(ProductoAEliminar != null)
            {
                if (Persistencia.BajaProducto(pId))
                {
                    aListaProductos.Remove(ProductoAEliminar);
                    return true;
                }
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

        public int ProximoIdCliente()
        {
            return Persistencia.ProximoClienteId();
        }
        public List<Cliente> ListarClientes()
        {
            aListaClientes = Persistencia.ListaClientes();
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
                if (Persistencia.AltaCliente(pCliente))
                {
                    aListaClientes.Add(pCliente);
                    return true;
                }
            }
            return false;
        }
        public bool BajaCliente(int pId)
        {
            Cliente ClienteAEliminar = BuscarCliente(pId);
            if (ClienteAEliminar != null)
            {
                if (Persistencia.BajaCliente(pId))
                {
                    aListaClientes.Remove(ClienteAEliminar);
                    return true;
                }
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

        public int ProximoIdVenta()
        {
            return Persistencia.ProximoVentaId();
        }
        public int ProximoIdLinea()
        {
            return Persistencia.ProximoLineaId();
        }
        public List<Venta> ListarVentas()
        {
            aListaVentas = Persistencia.ListaVentas();
            return aListaVentas;
        }
        public List<LineaVenta> ListarLineasVenta()
        {
            return aListaLineasVenta;
        }
        public bool AltaLineaVenta(LineaVenta pLineaVenta)
        {
            aListaLineasVenta.Add(pLineaVenta);
            return true;
        }
        public void LimpiarLineasVenta()
        {
            aListaLineasVenta.Clear();
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
                if(Persistencia.AltaVenta(pVenta))
                {
                    aListaVentas.Add(pVenta);
                    LimpiarLineasVenta();
                    return true;
                }
            }
            LimpiarLineasVenta();
            return false;
        }
        public bool BajaVenta(int pId)
        {
            Venta VentaAEliminar = BuscarVenta(pId);
            if (VentaAEliminar != null)
            {
                if (Persistencia.BajaVenta(pId))
                {
                    aListaVentas.Remove(VentaAEliminar);
                    return true;
                }
            }
            return false;
        }

        public List<Venta> ListarVentasXCliente(int idCliente)
        {
            List<Venta> aListaVentasXCliente = new List<Venta>();
            
            foreach (Venta unaVenta in aListaVentas)
            {
                if (unaVenta.Cliente.Id == idCliente)
                {
                    aListaVentasXCliente.Add(unaVenta);
                }
            }
            return aListaVentasXCliente;
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
        public void CargarListas()
        {
            ListarClientes();
            ListarProductos();
            ListarVentas();
        }
    }
}
