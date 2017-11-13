using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    /// <summary>
    /// EntityFramework general data access class
    /// </summary>
    public class EFDBHelper
    {

        private DbContext dbContext = null;

        public EFDBHelper(DbContext context)
        {

            this.dbContext = context;
        }

        // add
        public int Add<T>(T entity) where T : class
        {
            dbContext.Entry<T>(entity).State = EntityState.Added;
            return dbContext.SaveChanges();
        }

        // moidfy
        public int Modify<T>(T entity) where T : class
        {
            dbContext.Entry<T>(entity).State = EntityState.Modified;
            return dbContext.SaveChanges();
        }


        //delete
        public int Delete<T>(T entity) where T : class
        {
            dbContext.Entry<T>(entity).State = EntityState.Deleted;
            return dbContext.SaveChanges();
        }

    }
}
