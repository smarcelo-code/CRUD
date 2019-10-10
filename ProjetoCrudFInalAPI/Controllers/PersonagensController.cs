using ProjetoCrudeFInalAPI.Contexts;
using ProjetoCrudeFInalAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjetoCrudeFInalAPI.Controllers
{
    public class PersonagensController : Controller
    {
        //private static IList<Personagens> personagenss = new List<Personagens>()
        //{
        //    new  Personagens(){PersonagensId = 1, Nome = "Personagem01"},
        //    new Personagens()
        //    {
        //        PersonagensId = 2,
        //        Nome = "Personagem02"
        //    },
        //    new Personagens()
        //    {
        //        PersonagensId = 3,
        //        Nome = "Personagem03"
        //    },
        //    new Personagens()
        //    {
        //        PersonagensId = 2,
        //        Nome = "Personagem04"
        //    }
        //};
        private EFContext contexts = new EFContext();

        public ActionResult Index()
        {
            return View(contexts.Personagens.OrderBy(c => c.Nome));
                
        }

        //// GET: Itens
        //public ActionResult Index()
        //{
        //    return View(personagenss);
        //}

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Personagens personagens)
        {
            contexts.Personagens.Add(personagens);
            contexts.SaveChanges();
            return RedirectToAction("Index");
            //Personagens.Add(personagens);
            //personagens.PersonagensId =
            //    Personagens.Select(m => m.PersonagensId).Max()+1;            
            //return RedirectToAction("Index");
        }

        public ActionResult Edit (long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagens personagens = contexts.Personagens.Find(id);
            if (personagens == null)
            {
                return HttpNotFound();
            }
            return View(personagens);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Personagens personagens)
        {
            if (ModelState.IsValid)
            {
                contexts.Entry(personagens).State =
                    EntityState.Modified;
                contexts.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personagens);
            //personagenss.Remove(personagenss.Where(
            //    c => c.PersonagensId == personagens.PersonagensId)
            //    .First());
            //personagenss.Add(personagens);
            //return RedirectToAction("Index");
        }

        public ActionResult Details (long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagens personagens = contexts.Personagens.Where(f =>f.PersonagensId==id).Include("Itens.Inventario").First();
            //Personagens personagens = contexts.Personagens.Find(id);

            if (personagens == null)
            {
                return HttpNotFound();
            }
            return View(personagens);
            //return View(personagenss.Where
            //    (m => m.PersonagensId == id).First());
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagens personagens = contexts.Personagens.Find(id);
            if (personagens == null)
            {
                return HttpNotFound();
            }
            return View(personagens);
            //return View(personagenss.Where
            //    (m => m.PersonagensId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (long id)
        {
            Personagens personagens = contexts.Personagens.Find(id);
            contexts.Personagens.Remove(personagens);
            contexts.SaveChanges();
            TempData["Message"] = "personagens" + personagens.Nome.ToUpper() + "foi removido";
            return RedirectToAction("Index");
        //    personagenss.Remove(personagenss.Where
        //        (c => c.PersonagensId == personagens.PersonagensId).First());
        //    return RedirectToAction("Index");
        }
    }

}   