using Almacen.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace Almacen.Pages.PageVenta
{
    public class AltaModel : PageModel
    {
        public List<Cliente> Clientes { get; set; }
        public List<Dominio.Producto> Productos { get; set; }
        public List<LineaVenta> LineasVenta { get; set; }
        public string Mensaje { get; set; } = "";
        [BindProperty] public Venta Venta { get; set; }
        [BindProperty] public int idCliente { get; set; }
        [BindProperty] public int idProducto { get; set; }
        [BindProperty] public int idLinea { get; set; }
        [BindProperty] public double Precio { get; set; }
        [BindProperty] public int Cantidad { get; set; }
        [BindProperty] public double SubTotal { get; set; }
        [BindProperty] public double Total { get; set; }
        public Dominio.Producto producto { get; set; } = new Dominio.Producto();
        public IActionResult OnPostCargarPrecio()
        {
            Controladora unaControladora = new Controladora();
            Dominio.Producto unProd = unaControladora.BuscarProducto(idProducto);
            
            if(unProd != null)
            {
                Precio = unProd.Precio;
            }
            
            CargarDatos();

            return Page();
        }
        public IActionResult OnPostCalcularSubTotal()
        {
            if (Precio != 0)
            {
                SubTotal = Precio * Cantidad;
            }
            CargarDatos();
            return Page();
        }
        public void OnGet()
        {
            Venta = new Venta();
            idLinea = 1;
            CargarDatos();
        }
        private void CargarDatos()
        {
            Controladora unaControladora = new Controladora();
            Clientes = unaControladora.ListarClientes();
            Productos = unaControladora.ListarProductos();
            LineasVenta = unaControladora.ListarLineasVenta();
        }  
        public IActionResult OnPostAgregarLinea()
        {
            Controladora unaControladora = new Controladora();
            
            Dominio.Producto unProducto = unaControladora.BuscarProducto(idProducto);
            if (unProducto != null)
            {
                LineaVenta nuevaLinea = new LineaVenta(idLinea, unProducto, Cantidad, SubTotal);
                unaControladora.AltaLineaVenta(nuevaLinea);
                Total += SubTotal;
                idLinea+=1;
                idProducto = 0;
                Precio = 0;
                Cantidad = 0;
                SubTotal = 0;

                ModelState.Remove("idLinea");
                ModelState.Remove("idProducto");
                ModelState.Remove("Precio");
                ModelState.Remove("Cantidad");
                ModelState.Remove("SubTotal");
            }
            else
            {
                Mensaje = "El producto no existe.";
            }
            CargarDatos();
            return Page();
        }
        public IActionResult OnPostAgregarVenta()
        {
            Controladora unaControladora = new Controladora();
            Cliente unCliente = unaControladora.BuscarCliente(idCliente);
            Venta.Cliente = unCliente;
            Venta.LineasVenta = new List<LineaVenta>(unaControladora.ListarLineasVenta());
            Venta.Total = Total;

            if (unaControladora.AltaVenta(Venta))
            {
                Mensaje = "La venta se ha registrado correctamente.";
            }
            else
            {
                Mensaje = "Error al grabar la Venta";
            }
            return Redirect("/PageVenta/Listar");
        }

    }
}
