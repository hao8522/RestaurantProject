using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
   public  class DishesManager
    {
       private DishesService dishesService = new DishesService();

       public List<Dish> GetAllDishes(int categoryId = 0)
       {
           return dishesService.GetAllDishes(categoryId);
       }


       public List<DishesCategory> GetAllDishesCategory()
       {
           return dishesService.GetAllDishesCategory();
       }
    }
}
