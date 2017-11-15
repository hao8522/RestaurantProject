using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace RestaurantPro.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
      
         public ActionResult NewsDetail(int newsId)
        {
            News news = new NewsManager().GetNewsById(newsId);

            return View("NewsDetails", news);
        }
    }
}