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

        #region Reservaton
        public ActionResult LoadReservation()
        {
            return View("Reservation");
        }

        public ActionResult Reservation(DishesBook book)
        {
            book.BookTime = DateTime.Now;
            book.OrderStatus = 0;
            int result = new ReservationManager().AddReservation(book);
            if (result > 0)
            {
                return Content("success");
            }
            else
            {
                return Content("error");
            }
        }

        public ActionResult CheckValidate()
        {
            string txtValidateCode = Request["value"];
            if (String.Compare(Session["ValidateCode"].ToString(), txtValidateCode, true) != 0)
            {
                return Content("0");  //0 incorrect
            }
            else
            {
                return Content("1"); //1 correct
            }
        }

        #endregion

        #region Feedback

        public ActionResult ValidateCode()
        {
            CreateValidateCode createCode = new Models.CreateValidateCode();
            string code = createCode.CreateRandomCode(6);
            Session["ValidateCode"] = code.ToLower();
            return File(createCode.CreateValidateGraphic(code), "images/jpeg");
        }



        public ActionResult LoadFeedback()
        {
            return View("Feedback");
        }

        public ActionResult AddFeedback(Suggestion suggestion,string vCode)
        {

            if (ModelState.IsValid)
            {
                string code = Session["ValidateCode"].ToString();

                if(code != vCode.ToLower())
                {
                    ModelState.AddModelError("vCode", "The code is incorrect");

                    return View("LoadFeedback", suggestion);

                }
                else
                {
                    suggestion.StatusId = 0;
                    suggestion.SuggestionTime = DateTime.Now;
                    int result = new FeedbackManager().AddFeedback(suggestion);

                    if (result > 0)
                    {
                        return Content("<script>alert('Add Feedback Successfully');location.href='"+Url.Content("~/")+"'</script>");
                    }
                    else
                    {
                        return Content("<script>alert('Can you add again?');location.href='"+Url.Content("LoadFeedback") +"'</script>");
                    }
                }

                
            }
            else
            {

                return View("Feedback",suggestion);
            }

            
        }

        #endregion


        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Sourranding()
        {
            return View();
        }
    }
}