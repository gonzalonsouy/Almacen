using Almacen.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Almacen.Pages.PageReportes
{
    public class VentasXProductoModel : PageModel
    {
        public List<Venta> Ventas { get; set; }
        public List<Dominio.Producto> Productos { get; set; }
        [BindProperty] public int idProducto { get; set; }
        public int CantProductos { get; set; }
        public double TotalProducto { get; set; }
        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Productos = unaControladora.ListarProductos();
        }
        public IActionResult OnPostListar()
        {
            Controladora unaControladora = new Controladora();
            if (idProducto != 0)
            {
                Ventas = unaControladora.ListarVentasXProducto(idProducto);
                foreach (Venta unaVenta in Ventas)
                {
                    foreach (LineaVenta unaLinea in unaVenta.LineasVenta)
                    {
                        CantProductos += unaLinea.Cantidad;
                        TotalProducto += unaLinea.SubTotal * unaLinea.Cantidad;
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Debe seleccionar un producto.");
            }
            Productos = unaControladora.ListarProductos();
            return Page();
        }
    }
}
