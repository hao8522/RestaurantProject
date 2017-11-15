using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using System.Web.Security;

namespace RestaurantPro.Areas.RestaurantAdmin.Controllers
{
    public class SysAdminController : Controller
    {
        // GET: RestaurantAdmin/SysAdmin
        public ActionResult Index()
        {
            return View("AdminLogin");
        }


        public ActionResult AdminLogin(SysAdmin sysAdmin)
        {
            if (ModelState.IsValid)
            {
                sysAdmin = new SysAdminManager().AdminLogin(sysAdmin);

                if(sysAdmin != null)
                {
                    Session["currentAdmin"] = sysAdmin.LoginId;

                    FormsAuthentication.SetAuthCookie(sysAdmin.LoginName, true);
                    return View("AdminMain");
                }
                else
                {

                    return Content("<script>alert('User Id or password is incorrect');location.href='"+Url.Action("Index")+"'</script>");
                }
            }
            else
            {
                return View("AdminLogin");
            }

        }

        /// <summary>
        /// admin site main page
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminMain()
        {
            return View();
        }

        public ActionResult ExitSys()
        {
            Session["currentAdmin"] = null;

            Session.Abandon();
            FormsAuthentication.SignOut();

            return View("AdminLogin");
        }
    }
}