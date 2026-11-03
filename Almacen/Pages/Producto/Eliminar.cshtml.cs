using Almacen.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Almacen.Pages.Producto
{
    public class EliminarModel : PageModel
    {
        public Dominio.Producto producto { get; set;  }
        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            producto = unaControladora.BuscarProducto(id);
        }

        public IActionResult OnPostEliminar()
        {
            int Id = int.Parse(Request.Form["id"]);

            Controladora unaControladora = new Controladora();
            unaControladora.BajaProducto(Id);
            return Redirect("./Listar");
        }
    }
}
