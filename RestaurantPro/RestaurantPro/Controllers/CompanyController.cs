using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace RestaurantPro.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {

            List<News> newsList = new NewsManager().GetNews(5);

            ViewBag.list = newsList;
            return View();
        }


        public ActionResult Overview()
        {
            return View();
        }


        public ActionResult PositionList()
        {

            List<Recruitment> positionList = new RecruitmentManager().GetAllPostion();

            ViewBag.list = positionList;

            return View("PositionList");
        }

        public ActionResult PostionDetails(int positionId)
        {

            Recruitment r = new RecruitmentManager().GetPositionById(positionId);
            return View("PositionDetails",r);
        }
    }
}