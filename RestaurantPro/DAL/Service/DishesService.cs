using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;

namespace DAL
{

   
    public class DishesService
    {
        /// <summary>
        /// add dishes
        /// </summary>
        /// <param name="dish"></param>
        /// <returns></returns>
        public int AddDishes(Dish dish)
        {
            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {
                db.Dishes.Add(dish);
                db.SaveChanges();
                return dish.DishesId;
                
            };
        }
        /// <summary>
        /// delete dishes
        /// </summary>
        /// <param name="dishId"></param>
        /// <returns></returns>

        public int DeleteDishes(int dishId)
        {
            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {
                Dish dish = new Dish()
                {

                    DishesId = dishId
                };

                db.Dishes.Attach(dish);
                db.Dishes.Remove(dish);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// get dishes by id
        /// </summary>
        /// <param name="dishesId"></param>
        /// <returns></returns>
        public Dish GetDishesById(int dishesId)
        {
            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {
                return (from d in db.Dishes where d.DishesId == dishesId select d ).FirstOrDefault();
            }
        }

        /// <summary>
        /// modify dishes
        /// </summary>
        /// <param name="dishes"></param>
        /// <returns></returns>
        public int ModifyDishes(Dish dishes)
        {
            using(RestaurantDBEntities db = new RestaurantDBEntities()){

                db.Entry<Dish>(dishes).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

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
