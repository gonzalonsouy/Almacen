using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Almacen.Dominio;

namespace Almacen.Pages.Producto
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
                    throw new Exception("Debe ingresar el ID del Producto");
                }
                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID del Producto debe ser un numero");
                }
                if (Request.Form["nombre"] == "")
                {
                    throw new Exception("Debe ingresar el Nombre del Producto");
                }
                if (Request.Form["tipo"] == "")
                {
                    throw new Exception("Debe ingresar el Tipo del Producto");
                }
                if (Request.Form["stock"] == "")
                {
                    throw new Exception("Debe ingresar el Stock del Producto");
                }
                if (!int.TryParse(Request.Form["stock"], out _))
                {
                    throw new Exception("El Stock del Producto debe ser un numero");
                }
                if (Request.Form["precio"] == "")
                {
                    throw new Exception("Debe ingresar el Precio del Producto");
                }
                if (!double.TryParse(Request.Form["precio"], out _))
                {
                    throw new Exception("El Precio del Producto debe ser un numero");
                }

                int Id = int.Parse(Request.Form["id"]);
                string Nombre = Request.Form["nombre"];
                string Tipo = Request.Form["tipo"];
                int Stock = int.Parse(Request.Form["stock"]);
                double Precio = double.Parse(Request.Form["precio"]);

                Dominio.Producto unProducto = new Dominio.Producto(Id, Nombre, Tipo, Stock, Precio);

                Controladora unaControladora = new Controladora();

                unaControladora.AltaProducto(unProducto);
                return Redirect("/Producto/Listar");

            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}
