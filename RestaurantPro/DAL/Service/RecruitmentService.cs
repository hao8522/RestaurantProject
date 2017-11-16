using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;

namespace DAL
{
   public class RecruitmentService
    {

        private EFDBHelper helper = new EFDBHelper(new RestaurantDBEntities());
        /// <summary>
        ///  add position
        /// </summary>
        /// <param name="recuritment"></param>
        /// <returns></returns>
        public int AddPosition(Recruitment recuritment)
        {

            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {
                db.Recruitments.Add(recuritment);

                return db.SaveChanges();
            }



            // method 2
            //return helper.Add<Recruitment>(recuritment);

        }

        /// <summary>
        /// modify Position
        /// </summary>
        /// <param name="recruitment"></param>
        /// <returns></returns>
        public int ModifyPosition(Recruitment recruitment)
        {

            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {
                db.Recruitments.Attach(recruitment);
                db.Entry<Recruitment>(recruitment).State = EntityState.Modified;
                return db.SaveChanges();
            };

            // method 2
            //return helper.Modify<Recruitment>(recruitment);
        }

        /// <summary>
        /// get all position
        /// </summary>
        /// <returns></returns>
        public List<Recruitment> GetAllPostion()
        {
            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {
                return (from m in db.Recruitments select m).ToList();
            }
        }


        /// <summary>
        /// delete position
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public int DeletePosition(int postId)
        {
            using(RestaurantDBEntities db= new RestaurantDBEntities())
            {
                Recruitment recruitment = new Recruitment() { PostId = postId };

                db.Recruitments.Attach(recruitment);
                db.Recruitments.Remove(recruitment);

                return db.SaveChanges();
            }
        }

        public Recruitment GetPositionById(int postId)
        {

            using(RestaurantDBEntities db = new RestaurantDBEntities())
            {
                return (from n in db.Recruitments where n.PostId == postId select n).FirstOrDefault();
            };
        }

    }
}
