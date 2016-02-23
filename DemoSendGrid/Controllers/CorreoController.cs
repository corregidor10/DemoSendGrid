using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DemoSendGrid.Controllers
{
    public class CorreoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnviarCorreo()
        {
            return View();
        }
        // TODO 003. Creamos la accion en el controlador para enviar correos.
        [HttpPost]
        public ActionResult EnviarCorreo(String CorreoUsuario, String Destino, String Asunto, String Mensaje, String Dni, String Nombre)
        {
            try
            {
                Asunto = Nombre + " con " + Dni + " quiere saber.....";

                new EnviarCorreos().PostMails(Nombre, CorreoUsuario, Destino, Asunto, Mensaje);
                //CC} finally {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Asunto = "Copia de tu solicitud con fecha" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + " No respondas a este mensaje";
                Destino = CorreoUsuario;
                CorreoUsuario = "info@chinoexpress.com";
                Nombre = "ChinoExpress";


             new EnviarCorreos().PostMails(Nombre, CorreoUsuario, Destino, Asunto, Mensaje);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            return RedirectToAction("Index");
        }



    }
}