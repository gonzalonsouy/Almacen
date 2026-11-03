using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Almacen.Dominio;

namespace Almacen.Pages.PageCliente
{
    public class EliminarModel : PageModel
    {
        public Cliente cliente {  get; set; }
        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            cliente = unaControladora.BuscarCliente(id);
        }
        public IActionResult OnPostEliminar()
        {
            int Id = int.Parse(Request.Form["id"]);

            Controladora unaControladora = new Controladora();
            unaControladora.BajaCliente(Id);
            return Redirect("./Listar");
        }
    }
}
