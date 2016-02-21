using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EnviarCorreo(String Destino, String Asunto, String Mensaje)
        {
            
            new EnviarCorreos().PostMails(Destino, Asunto, Mensaje);

            return View("Index");
        }
        
       
    }
}