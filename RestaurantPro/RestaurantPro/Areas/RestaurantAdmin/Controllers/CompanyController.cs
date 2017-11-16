using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace RestaurantPro.Areas.RestaurantAdmin.Controllers
{
    public class CompanyController : Controller
    {

        public ActionResult LoadingAddPosition()
        {
            return View("AddPosition");
        }

        // GET: RestaurantAdmin/Company
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPosition(Recruitment recruitment)
        {
            recruitment.PublishTime = DateTime.Now;

            int result = new RecruitmentManager().AddPosition(recruitment);

            if(result > 0)
            {

                return Content("<script>alert('Add Position succesfully');location.href='"+Url.Action("PositionList")+"'</script>");
            }
            else
            {
                return Content("<script>alert('Can you add position again?');location.href='"+Url.Action("AddPosition") +"'</script>");

            }



           
        }



        public ActionResult PositionList()
        {

            List<Recruitment> positionList = new RecruitmentManager().GetAllPostion();

            ViewBag.list = positionList;

            return View("PositionList");

        }

        public ActionResult LoadModifyPosition(int postId)
        {
            Recruitment recruitment = new RecruitmentManager().GetPositionById(postId);
            return View("ModifyPosition",recruitment);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ModifyPosition(Recruitment recruitment)
        {

            recruitment.PublishTime = DateTime.Now;

            int result = new RecruitmentManager().ModifyPosition(recruitment);

            if (result > 0)
            {
                return Content("<script>alert('Modify position successfully');location.href='" + Url.Content("PositionList") + "'</script>");
            }
            else
            {

                return Content("<script>alert('Can you try again?');location.href='" + Url.Content("PositionList") + "'</script>");
            }
        }


        public ActionResult DeletePosition(int postId)
        {
            int result = new RecruitmentManager().DeletePosition(postId);

            if (result > 0)
            {

                return Content("<script>alert('Delete position succssfully');location.href='"+Url.Action("PositionList") +"'</script>");
            }
            else
            {

                return Content("<script>alert('Can you try again?');location.href='"+Url.Action("PositionList") +"'</script>");
            }
        }
    }
}