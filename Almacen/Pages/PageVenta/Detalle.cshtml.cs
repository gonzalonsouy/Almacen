using Almacen.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Almacen.Pages.PageVenta
{
    public class DetalleModel : PageModel
    {
        public Venta venta { get; set; }
        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            venta = unaControladora.BuscarVenta(id);
        }
    }
}
