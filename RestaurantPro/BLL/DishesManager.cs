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


       public int AddDishes(Dish dish)
       {
           return dishesService.AddDishes(dish);
       }

       public int DeleteDishes(int dishId)
       {
           return dishesService.DeleteDishes(dishId);
       }

       public Dish GetDishesById(int dishesId)
       {

           return dishesService.GetDishesById(dishesId);
       }

       public int ModifyDishes(Dish dishes)
       {
           return dishesService.ModifyDishes(dishes);
       }

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
