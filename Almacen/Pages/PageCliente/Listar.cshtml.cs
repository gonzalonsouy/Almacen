using Almacen.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Almacen.Pages.PageCliente
{
    public class ListarModel : PageModel
    {
        public List<Cliente> Clientes { get; set; }
        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Clientes = unaControladora.ListarClientes();
        }
    }
}
