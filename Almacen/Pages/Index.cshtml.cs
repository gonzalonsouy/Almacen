using Almacen.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Almacen.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            unaControladora.CargarDatosIniciales();
        }
    }
}
