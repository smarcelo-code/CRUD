using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoCrudeFInalAPI.Contexts;
using ProjetoCrudeFInalAPI.Models;

namespace ProjetoCrudeFInalAPI.Controllers
{
    public class InventarioController : Controller
    {         
        private EFContext contexts = new EFContext();

        // GET: Inventario
        public ActionResult Index()
        {
            return View(contexts.Inventario.OrderBy(c => c.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Inventarios inventario)
        {
            contexts.Inventario.Add(inventario);
            contexts.SaveChanges();
            return RedirectToAction("Index"); 
        }

        //GET: Inventario
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventarios inventario = contexts.Inventario.Find(id);
            if(inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Inventarios inventario)
        {
            if (ModelState.IsValid)
            {
                contexts.Entry(inventario).State =
                    EntityState.Modified;
                contexts.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventario);
        }
      
        public ActionResult Details(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Inventarios inventarios = contexts.Inventario.Find(id);
            if (inventarios == null)
            {
                return HttpNotFound();
            }
            return View(inventarios);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventarios inventarios = contexts.Inventario.Find(id);
            if (inventarios == null)
            {
                return HttpNotFound();
            }
            return View(inventarios);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Inventarios inventarios = contexts.Inventario.Find(id);
            contexts.Inventario.Remove(inventarios);
            contexts.SaveChanges();
            TempData["Message"] = "Inventario" + inventarios.Nome.ToUpper() + "foi excluido";
            return RedirectToAction("Index");
        }
       
    }
}