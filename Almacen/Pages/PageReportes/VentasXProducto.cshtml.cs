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
