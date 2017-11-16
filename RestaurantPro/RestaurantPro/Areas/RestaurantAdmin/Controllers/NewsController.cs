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
            news.PublishTime = DateTime.Now;
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

        public ActionResult NewsList()
        {
            List<News> newsList = new NewsManager().GetNews(10);
            ViewBag.newsList = newsList;

            return View();
        }

        // news details
        public ActionResult ShowNewsDetail(int newsId)
        {
            News news = new NewsManager().GetNewsById(newsId);

            List<NewsCategory> categoryList = new NewsManager().GetAllCategory();

            SelectList list = new SelectList(categoryList, "CategoryId", "CategoryName", news.CategoryId);

            ViewBag.dList = list;

            return View("ModifyNews", news);
        }


        /// <summary>
        /// modify news
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        ///
        [ValidateInput(false)]
        public ActionResult ModifyNews(News news)
        {
            news.PublishTime = DateTime.Now;
            int result = new NewsManager().ModifyNews(news);

            if (result > 0)
            {
                return Content("<script>alert('Modify News Successfully');location.href='"+Url.Action("NewsList")+"'</script>");
            }
            else
            {

                return Content("<script>alert('Can you Modify News Again?');location.href='"+Url.Action("NewsList")+"'</script>");
            }

        }

        public ActionResult DeleteNews(int newsId)
        {
            int result = new NewsManager().DeleteNews(newsId);

            if (result > 0)
            {
                return Content("<script>alert('The News is deleted');location.href='"+Url.Action("NewsList")+"'</script>");
            }
            else
            {

                return Content("<script>alert('Can you delete again?');location.href='" + Url.Action("NewsList") + "'</script>");
            }
        }
    }
}