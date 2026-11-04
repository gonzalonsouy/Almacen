using Almacen.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Almacen.Pages.PageVenta
{
    public class AltaModel : PageModel
    {
        public List<Cliente> Clientes { get; set; }
        public List<Dominio.Producto> Productos { get; set; }
        public List<LineaVenta> LineasVenta { get; set; }
        public string Mensaje { get; set; } = "";
        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Clientes = unaControladora.ListarClientes();
            Productos = unaControladora.ListarProductos();
            LineasVenta = new List<LineaVenta>();
        }
        public IActionResult OnPostAgregarLinea()
        {
            Controladora unaControladora = new Controladora();
            int pIdProducto = int.Parse(Request.Form["idProducto"]);
            int pCantidad = int.Parse(Request.Form["cantidad"]);

            Dominio.Producto unProducto = unaControladora.BuscarProducto(pIdProducto);
            if (unProducto != null)
            {
                double subTotal = unProducto.Precio * pCantidad;
                LineaVenta nuevaLinea = new LineaVenta(LineasVenta.Count + 1, unProducto, pCantidad, subTotal);
                LineasVenta.Add(nuevaLinea);
            }
            else
            {
                Mensaje = "El producto no existe.";
            }
            return Page();
        }
    }
}
