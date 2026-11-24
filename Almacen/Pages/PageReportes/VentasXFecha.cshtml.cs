using Almacen.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Almacen.Pages.PageReportes
{
    public class VentasXFechaModel : PageModel
    {
        public List<Venta> Ventas { get; set; }
        [BindProperty] public DateTime fechaDesde { get; set; }
        [BindProperty] public DateTime fechaHasta { get; set; }
        public void OnGet()
        {
            fechaDesde = DateTime.Now.AddDays(-7); // Establecer fechaDesde como 7 días antes de la fecha actual
            fechaHasta = DateTime.Now; // Establecer fechaHasta como la fecha actual
        }
        public IActionResult OnPostListar()
        {
            Controladora unaControladora = new Controladora();
            Ventas = unaControladora.ListarVentasXFecha(fechaDesde, fechaHasta);
            return Page();
        }
    }
}
