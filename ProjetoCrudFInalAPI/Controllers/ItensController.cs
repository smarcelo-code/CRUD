using ProjetoCrudeFInalAPI.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ProjetoCrudeFInalAPI.Models;
using System.Net;

namespace ProjetoCrudeFInalAPI.Controllers
{
    public class ItensController : Controller
    {
        private EFContext contexts = new EFContext();
        // GET: Itens
        public ActionResult Index()
        {
            var itens = contexts.Itens.Include(c => c.Inventario).Include
                (f => f.Personagens).OrderBy(n => n.Nome);
            return View(itens);

            //return View(contexts.Itens.OrderBy(c=>c.Nome));
        }

        // GET: Itens/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.
                    BadRequest);
            }
            Itens itens = contexts.Itens.Where(p => p.ItensId ==
                id).Include(c => c.Inventario).Include(f => f.Personagens).First();
            if (itens == null)
            {
                return HttpNotFound();
            }
            return View(itens);            
        }


        //Selectlist = repsenta uma lista de itens que o usuário pode selecionar
        // GET: Itens/Create
        public ActionResult Create()
        {
            ViewBag.InventarioId = new 
                SelectList(contexts.Inventario.OrderBy(b => b.Nome),
                "InventarioId", "Nome");
            ViewBag.PersonagensId = new
                SelectList(contexts.Personagens.OrderBy(b => b.Nome),
                "PersonagensId", "Nome");
            return View();
        }

        // POST: Itens/Create
        [HttpPost]
        public ActionResult Create(Itens itens)
        {
            try
            {
                contexts.Itens.Add(itens);
                contexts.SaveChanges();
                return RedirectToAction("Index");
                               
            }
            catch
            {
                return View(itens);
            }
        }

        // GET: Itens/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.
                    BadRequest);
            }
            Itens itens = contexts.Itens.Find(id);
            if (itens == null)
            {
                return HttpNotFound();
            }
            ViewBag.InventarioId = new SelectList(contexts.Inventario.
                OrderBy(b => b.Nome), "InventarioId", "Nome", itens.
                InventarioId);
            ViewBag.PersonagensId = new SelectList(contexts.Personagens.
                OrderBy(b => b.Nome), "PersonagensId", "Nome", itens.PersonagensId);
            return View(itens);
        }

        // POST: Itens/Edit/5
        [HttpPost]
        public ActionResult Edit(Itens itens)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexts.Entry(itens).State = EntityState.Modified;
                    contexts.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(itens);
            }
            
            catch
            {
                return View(itens);
            }
        }

        // GET: Itens/Delete/5
        public ActionResult Delete(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.
                    BadRequest);
            }
            Itens itens = contexts.Itens.Where(p => p.ItensId ==
                id).Include(c => c.Inventario).Include(f => f.Personagens).
                First();
            if(itens == null)
            {
                return HttpNotFound();
            }
            return View(itens);
        }

        // POST: Itens/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Itens itens = contexts.Itens.Find(id);
                contexts.Itens.Remove(itens);
                contexts.SaveChanges();
                TempData["Message"] = "Itens" + itens.Nome.ToUpper() + "foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
