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
    }
}