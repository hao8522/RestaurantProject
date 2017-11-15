using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SysAdminService
    {

       public SysAdmin AdminLogin(SysAdmin sysAdmin)
        {
            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {

                return (from b in db.SysAdmins where  b.LoginId == sysAdmin.LoginId && b.LoginPwd == sysAdmin.LoginPwd select b).FirstOrDefault();
            }
        }

    }
}
