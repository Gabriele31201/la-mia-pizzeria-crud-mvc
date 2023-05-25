using LaMiaPizzeria.Database;
using Microsoft.AspNetCore.Mvc;
using LaMiaPizzeria.Models;
using LaMiaPizzeria.Models.ModelForView;
using Microsoft.AspNetCore.Authorization;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<PizzaModel> ourTecPizzas = db.Pizzas.ToList();
                return View("Index", ourTecPizzas);
            }
        }



        public IActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaDetails = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaDetails != null)
                {
                    return View("Details", pizzaDetails);
                }
                else
                {
                    return NotFound($"L'articolo con id {id} non è stato trovato!");
                }
            }

        }

        // ACTIONS PER LA CREAZIONE DI UN ARTICOLO
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaModel newPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newPizza);
            }

            using (PizzaContext db = new PizzaContext())
            {
                db.Pizzas.Add(newPizza);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        // ACTIONS PER LA MODIFICA DI UN ARTICOLO
        [HttpGet]
        public IActionResult Update(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaToModify = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToModify != null)
                {
                    return View("Update", pizzaToModify);
                }
                else
                {

                    return NotFound("Pizza da modifcare inesistente!");
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaModel modifiedPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", modifiedPizza);
            }

            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaToModify = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToModify != null)
                {

                    pizzaToModify.Name = pizzaToModify.Name;
                    pizzaToModify.Description = pizzaToModify.Description;
                    pizzaToModify.Immagine = pizzaToModify.Immagine;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound("La pizza da modificare non esiste!");
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaToDelete = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToDelete != null)
                {
                    db.Remove(pizzaToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound("Non ho torvato la pizza da eliminare");

                }
            }
        }


        public IActionResult FindPizza(string titleKeyword, int viewCount)
        {
            UserProfile connectedProfile = new UserProfile("Gabriele", "Simone", 21);

            using (PizzaContext db = new PizzaContext())
            {
                List<PizzaModel> matchNamepizza = db.Pizzas.Where(pizza => pizza.Name.Contains(titleKeyword)).ToList();

                ProfileListPizzas resultModel = new ProfileListPizzas(connectedProfile, titleKeyword, matchNamepizza);


                return View("SearchPizzas", resultModel);
            }
        }
    }
}