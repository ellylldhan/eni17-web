using PizzaClassLibrary.Entities;
using PizzaClassLibrarys.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp4_pizzas_v1.Models;

namespace tp4_pizzas_v1.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDb.Instance.Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            return View(FakeDb.Instance.Pizzas.FirstOrDefault(x => x.Id == id));
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaViewModel vm = new PizzaViewModel();
            vm.Ingredients = FakeDb.Instance.Ingredients;
            vm.Pates = FakeDb.Instance.Pates;

            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel vm)
        {
            try
            {
                // Recupère pate avec meme id que pate de pizza
                vm.Pizza.Pate = FakeDb.Instance.Pates.SingleOrDefault(x => x.Id == vm.Pizza.Pate.Id);

                // Récupère tous les ingredients dont l'id a ete stocke dans la 
                // liste des id des ingredients que je souhaite récupérer
                vm.Pizza.Ingredients = FakeDb.Instance.Ingredients.Where(x => vm.IngredientIds.Contains(x.Id)).ToList();

                // Definir un nouvel id (bancal parce que asynchronisme)
                vm.Pizza.Id = (FakeDb.Instance.Pizzas.Count > 0) ? FakeDb.Instance.Pizzas.Max(x => x.Id) + 1 : 1;

                // On stocke la pizza dans la FakeDb
                FakeDb.Instance.Pizzas.Add(vm.Pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                vm.Pates = FakeDb.Instance.Pates;
                vm.Ingredients = FakeDb.Instance.Ingredients.Select(x => new SelectListItem() { Text = x.Nom, Value = x.Id.ToString() }).ToList();

                return View(vm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaViewModel vm = new PizzaViewModel();
            vm.Pizza = FakeDb.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
            vm.Pates = FakeDb.Instance.Pates;
            vm.Ingredients = FakeDb.Instance.Ingredients.Select(x => new SelectListItem() { Text = x.Nom, Value = x.Id.ToString() }).ToList();

            if (vm.Pizza.Ingredients != null && vm.Pizza.Ingredients.Count > 0)
            {
                vm.IngredientIds = vm.Pizza.Ingredients.Select(x => x.Id).ToList();
            }

            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza pizza = FakeDb.Instance.Pizzas.SingleOrDefault(x => x.Id == id);
            return View(pizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = FakeDb.Instance.Pizzas.SingleOrDefault(x => x.Id == id);
                FakeDb.Instance.Pizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                Pizza pizza = FakeDb.Instance.Pizzas.SingleOrDefault(x => x.Id == id);
                return View(pizza);
            }
        }

        private bool OtherValidations(ModelStateDictionary modelState, PizzaViewModel vm)
        {
            if (FakeDb.Instance.Pizzas.Any(x => x.Nom.Equals(vm.Pizza.Nom) && vm.Pizza.Id != x.Id))
            {
                modelState.AddModelError("Pizza.Nom", "Il existe déjà une pizza avec ce nom");
            }

            if (FakeDb.Instance.Pizzas.Distinct().Any(x => x.Ingredients.Select(y => y.Id).Distinct().OrderBy(z => z).SequenceEqual(vm.IngredientIds.Distinct().OrderBy(z => z)) && vm.Pizza.Id != x.Id))
            {
                modelState.AddModelError("IngredientIds", "Il existe déjà une pizza avec ces ingrédients");
            }

            return modelState.IsValid;
        }
    }
}
