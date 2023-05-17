using LaMiaPizzeria.Database;
using Microsoft.AspNetCore.Mvc;
using LaMiaPizzeria.Models;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController1 : Controller
    {
        public IActionResult NewIndex()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<PizzaModel> pizze = db.Pizzas.ToList();
           
                return View(pizze);
            }
                
        }
    }
}
