using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Almacen.Dominio;
namespace Almacen.Pages.PageVenta
{
    public class EliminarModel : PageModel
    {
        public Venta venta { get; set; }
        public IActionResult OnPostEliminar(int id)
        {
            Controladora unaControladora = new Controladora();
            unaControladora.BajaVenta(id);
            return Redirect("/PageVenta/Listar");
        }
        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            venta = unaControladora.BuscarVenta(id);
        }
    }
}
