using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace RestaurantPro.Areas.RestaurantAdmin.Controllers
{
    public class DishesController : Controller
    {
        // GET: RestaurantAdmin/Dishes
        public ActionResult DishesList(int category=0)
        {
            List<Dish> dishesList = new DishesManager().GetAllDishes(category);

            List<DishesCategory> categoryList = new DishesManager().GetAllDishesCategory();

            SelectList sList = new SelectList(categoryList, "CategoryId", "CategoryName", categoryList[0].CategoryId);
            ViewBag.list = dishesList;

            return View("DishesList",sList);
        }
    }
}