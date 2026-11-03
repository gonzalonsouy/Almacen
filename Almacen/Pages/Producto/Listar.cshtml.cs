using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Almacen.Dominio;

namespace Almacen.Pages.Producto
{
    public class ListarModel : PageModel
    {
        public List<Dominio.Producto> Productos { get; set; }
        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Productos = unaControladora.ListarProductos();
        }
    }
}
