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

        #region Query Dishes
        public ActionResult QueryDishes(int categoryId)
        {

            List<Dish> dishesList = new DishesManager().GetAllDishes(categoryId);

            ViewBag.list = dishesList;

            List<DishesCategory> categoryList = new DishesManager().GetAllDishesCategory();
            SelectList sList = new SelectList(categoryList, "CategoryId", "CategoryName", categoryId);

            return View("DishesList", sList);

        }
        #endregion


        #region delete dishes

        public ActionResult DeleteDishes(int dishesId)
        {
            Dish dish = new DishesManager().GetDishesById(dishesId);
           

            string filePath = Server.MapPath("/Images/dishes/"+dish.DishesImg);

            int result = new DishesManager().DeleteDishes(dishesId);

            if (result > 0)
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Exists(filePath);
                }

                return Content("success");
            }
            else
            {

                return Content("error");
            }
        }

        #endregion

        #region modify dishes
        /// <summary>
        /// loading modify dishes
        /// </summary>
        /// <param name="dishesId"></param>
        /// <returns></returns>
        public ActionResult LoadModifyDishes(int dishesId)
        {
            Dish dishes = new DishesManager().GetDishesById(dishesId);

            
            // dishes category
            List<DishesCategory> categoryList = new DishesManager().GetAllDishesCategory();

            SelectList sList = new SelectList(categoryList, "CategoryId", "CategoryName", dishes.CategoryId);

            ViewBag.list = sList;


            return View("DishesModify", dishes);
        }


        public ActionResult ModifyDishes(Dish dish,HttpPostedFileBase dishesImg)
        {

            try
            {
                int result = new DishesManager().ModifyDishes(dish);

                if (result > 0)
                {
                    if (dishesImg != null && dishesImg.FileName != "")
                    {
                        double fileLength = dishesImg.ContentLength / (1024 * 1024);

                        if (fileLength > 2.0)
                        {
                            return Content("<script>alert('The max size is 2M');location.href='"+Url.Action("ModifyDishes")+"'</script>");
                        }

                        string filePath = Server.MapPath("~/Images/dishes/"+dish.DishesId+".png");

                        dishesImg.SaveAs(filePath);
                    }
                   
                }

                return Content("<script>alert('The dish is modified');location.href='" + Url.Action("DishesList") + "'</script>");

               
                
            }
            catch (Exception ex)
            {

                return Content("<script>alert('error:"+ex.Message+"');</script>");
            }

        }


        #endregion

    
    }
}