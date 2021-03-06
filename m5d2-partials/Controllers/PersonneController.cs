using m5d2_partials.Models;
using m5d2_partials.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace m5d2_partials.Controllers
{
    public class PersonneController : Controller
    {
        // GET: Personne
        public ActionResult Index()
        {
            return View(FakeDb.Instance.Personnes);
        }

        // GET: Personne/Details/5
        public ActionResult Details(int id)
        {
            return View(FakeDb.Instance.Personnes.FirstOrDefault(x => x.Id == id));
        }

        // GET: Personne/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personne/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personne/Edit/5
        public ActionResult Edit(int id)
        {
            PersonneViewModel vm = new PersonneViewModel();
            vm.Personne = FakeDb.Instance.Personnes.FirstOrDefault(x => x.Id == id);
            vm.Id = vm.Personne.Id;
            vm.Age = vm.Personne.Age;

            return View(vm);
        }

        // POST: Personne/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, PersonneViewModel vm)
        {
            try
            {
                Personne toUpdate = FakeDb.Instance.Personnes.FirstOrDefault(x => x.Id == id);
                toUpdate.Nom = vm.Personne.Nom;
                toUpdate.Prenom = vm.Personne.Prenom;
                toUpdate.Age = (vm.Age.HasValue) ? vm.Personne.Age : 0; 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personne/Delete/5
        public ActionResult Delete(int id)
        {
            return View(FakeDb.Instance.Personnes.FirstOrDefault(x => x.Id == id));
        }

        // POST: Personne/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                FakeDb.Instance.Personnes.Remove(FakeDb.Instance.Personnes.FirstOrDefault(x => x.Id == id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}