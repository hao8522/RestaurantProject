using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class DishesService
    {
        /// <summary>
        /// Get all dishes
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>

        public List<Dish> GetAllDishes(int categoryId=0)
        {
            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {
                var dishesList = from d in db.Dishes
                                 select new
                                 {
                                     d.DishesId,
                                     d.DishesName,
                                     d.UnitPrice,
                                     d.CategoryId,
                                     d.DishesCategory.CategoryName
                                 };
                if (categoryId != 0)
                {
                    dishesList = from d in dishesList where d.CategoryId == categoryId select d;
                }

                List<Dish> list = new List<Dish>();
                foreach( var item in dishesList){

                    list.Add(new Dish()
                    {

                        DishesId = item.DishesId,
                        DishesName = item.DishesName,
                        UnitPrice = item.UnitPrice,
                        CategoryId = item.CategoryId,
                        DishesCategory = new DishesCategory { CategoryName= item.CategoryName}


                    });
                }

                return list;
            }
        }

        /// <summary>
        /// get all dishes category
        /// </summary>
        /// <returns></returns>
        public List<DishesCategory> GetAllDishesCategory()
        {
            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {

                return (from c in db.DishesCategories select c).ToList();
            };
        }
    }
}
