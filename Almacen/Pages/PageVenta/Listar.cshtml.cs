using Almacen.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Almacen.Pages.PageVenta
{
    public class ListarModel : PageModel
    {
        public List<Venta> Ventas { get; set; }
        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Ventas = unaControladora.ListarVentas();
        }
    }
}
