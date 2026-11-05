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
        public string idCliente { get; set; } = "";
        public string idProducto { get; set; } = "";
        public double total { get; set; } = 0;
        public Dominio.Producto producto { get; set; } = new Dominio.Producto();
        public void OnGet()
        {
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
            int pIdProducto = int.Parse(Request.Form["idProducto"]);
            int pCantidad = int.Parse(Request.Form["cantidad"]);
            int idLinea = int.Parse(Request.Form["idLinea"]);

            Dominio.Producto unProducto = unaControladora.BuscarProducto(pIdProducto);
            if (unProducto != null)
            {
                double subTotal = unProducto.Precio * pCantidad;
                LineaVenta nuevaLinea = new LineaVenta(idLinea, unProducto, pCantidad, subTotal);
                unaControladora.AltaLineaVenta(nuevaLinea);
                total += subTotal;
            }
            else
            {
                Mensaje = "El producto no existe.";
            }
            CargarDatos();
            return Page();
        }
        public void CargarPrecio()
        {
            Controladora unaControladora = new Controladora();
            int pIdProducto = int.Parse(Request.Form["idProducto"]);
            
            if(pIdProducto > 0)
            {
                Dominio.Producto producto = unaControladora.BuscarProducto(pIdProducto);
            }
        }
    }
}
