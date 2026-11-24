using Almacen.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Almacen.Pages.PageReportes
{
    public class VentasXClienteModel : PageModel
    {
        public List<Venta> Ventas { get; set; }
        public List<Cliente> Clientes { get; set; }
        [BindProperty] public int idCliente { get; set; }
        public double TotalCliente { get; set; }
        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Clientes = unaControladora.ListarClientes();
        }
        public IActionResult OnPostListar()
        {
            Controladora unaControladora = new Controladora();
            if (idCliente != 0)
            {
                Ventas = unaControladora.ListarVentasXCliente(idCliente);
                foreach (Venta unaVenta in Ventas)
                {
                    TotalCliente += unaVenta.Total;
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Debe seleccionar un cliente.");
            }
            Clientes = unaControladora.ListarClientes();
            return Page();
        }
    }
}
