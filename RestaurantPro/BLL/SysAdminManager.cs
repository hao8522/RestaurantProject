using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
   public  class SysAdminManager
    {

        public SysAdmin AdminLogin(SysAdmin sysAdmin)
        {

            return new SysAdminService().AdminLogin(sysAdmin);
        }
    }
}
