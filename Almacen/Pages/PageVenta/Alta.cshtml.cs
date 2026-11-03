using Almacen.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Almacen.Pages.PageVenta
{
    public class AltaModel : PageModel
    {
        public List<Cliente> Clientes { get; set; }
        public string Mensaje { get; set; } = "";
        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Clientes = unaControladora.ListarClientes();
        }
    }
}
