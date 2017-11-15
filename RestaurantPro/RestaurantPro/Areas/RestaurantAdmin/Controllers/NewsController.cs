using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace RestaurantPro.Areas.RestaurantAdmin.Controllers
{
    public class NewsController : Controller
    {
        // GET: RestaurantAdmin/News
        [Authorize]
        public ActionResult LoadNewsForm()
        {
            List<NewsCategory> categoryList = new NewsManager().GetAllCategory();
            SelectList list = new SelectList(categoryList,"CategoryId","CategoryName");
            ViewBag.dList = list;
            return View("AddNews");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNews(News news)
        {
            int result = new NewsManager().AddNews(news);

            if (result > 0)
            {

                return Content("<script>alert('Add News Successfully');location.href='"+Url.Action("LoadNewsForm")+"'</script>");

            }
            else
            {
                return Content("<script>alert('Add News Again');location.href='"+Url.Action("LoadNewsForm")+"'</script>");

            }
        }


    }
}