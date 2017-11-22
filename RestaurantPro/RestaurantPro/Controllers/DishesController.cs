using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace RestaurantPro.Controllers
{
    public class DishesController : Controller
    {
        // GET: Dishes
       
        public ActionResult DishesDetails()
        {
            List<Dish> dList = new DishesManager().GetAllDishes();

            ViewBag.list = dList;

            return View();
        }
        

    }
}