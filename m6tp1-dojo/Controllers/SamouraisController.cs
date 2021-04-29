using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using m6tp1_dojo.Data;
using m6tp1_dojo.Models;

namespace m6tp1_dojo.Controllers
{
    public class SamouraisController : Controller
    {
        private m6tp1_dojoContext db = new m6tp1_dojoContext();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraiViewModel vm = new SamouraiViewModel();
            vm.Armes = db.Armes.ToList();

            return View(vm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // Correction
                vm.Samourai.Arme = db.Armes.Find(vm.Samourai.Arme.Id);

                db.Samourais.Add(vm.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Récup de la liste des armes
            vm.Armes = db.Armes.ToList();

            return View(vm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }

            // Recup le view model pour le passer à la vue
            SamouraiViewModel sm = new SamouraiViewModel();
            sm.Armes = db.Armes.ToList();
            sm.Samourai = samourai;

            return View(sm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // Remplacer arme precedente par nouvelle (CORRECTION)
                // Note: on a besoin que l'objet (Samourai) soit chargé au préalable 
                // pour pouvoir changer les infos (Arme) qui lui sont liées. 
                // 1. charge samourai depuis contexte de données
                Samourai samourai = db.Samourais.Find(vm.Samourai.Id);
                samourai.Nom = vm.Samourai.Nom;
                samourai.Force = vm.Samourai.Force;
                samourai.Arme = db.Armes.Find(vm.Samourai.Arme.Id);

                //2. utilise ce samourai pour màj
                db.Entry(samourai).State = EntityState.Modified;
                db.SaveChanges();

                // Récup Arme par ID + affection à SAMOURAI
                //vm.Samourai.Arme = db.Armes.Find(vm.Samourai.Arme.Id);
                //db.Entry(vm.Samourai).State = EntityState.Modified;
                //db.SaveChanges();

                return RedirectToAction("Index");
            }

            vm.Armes = db.Armes.ToList();
            return View(vm);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
