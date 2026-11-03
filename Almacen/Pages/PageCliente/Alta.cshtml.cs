using Almacen.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Almacen.Pages.PageCliente
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPostAgregar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID del Cliente");
                }
                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID del Cliente debe ser un numero");
                }
                if (Request.Form["nombre"] == "")
                {
                    throw new Exception("Debe ingresar el Nombre del Cliente");
                }
                if (Request.Form["apellido"] == "")
                {
                    throw new Exception("Debe ingresar el Apellido del Cliente");
                }
                if (Request.Form["direccion"] == "")
                {
                    throw new Exception("Debe ingresar la Dirección del Cliente");
                }
                if (Request.Form["telefono"] == "")
                {
                    throw new Exception("Debe ingresar el Teléfono del Cliente");
                }
                

                int Id = int.Parse(Request.Form["id"]);
                string Nombre = Request.Form["nombre"];
                string Apellido = Request.Form["apellido"];
                string Direccion = Request.Form["direccion"];
                string Telefono = Request.Form["telefono"];

                Cliente unCliente = new Cliente(Id, Nombre, Apellido, Direccion, Telefono);

                Controladora unaControladora = new Controladora();

                unaControladora.AltaCliente(unCliente);
                return Redirect("/PageCliente/Listar");

            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}
