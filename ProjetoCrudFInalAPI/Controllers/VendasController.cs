using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoCrudeFInalAPI.Controllers
{
    public class VendasController : Controller
    {
        // GET: Vendas
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CorreiosCalc(string cep)
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}