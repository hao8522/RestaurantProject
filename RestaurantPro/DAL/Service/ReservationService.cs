using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class ReservationService
    {
        /// <summary>
        /// add reservation
        /// </summary>
        /// <param name="dishesbook"></param>
        /// <returns></returns>
       public int AddReservation(DishesBook dishesbook)
        {
            using (RestaurantDBEntities db= new RestaurantDBEntities())
            {
                db.DishesBooks.Add(dishesbook);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// modify reservation
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int ModifyReservation(int bookId, int statId)
        {
            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {
                DishesBook dishBook= new DishesBook();

                dishBook.BookId = bookId;

                db.DishesBooks.Attach(dishBook);

                dishBook.OrderStatus = Convert.ToInt32(statId);
                return db.SaveChanges();
               
            }

        }

        /// <summary>
        /// get all reservation
        /// </summary>
        /// <returns></returns>
        public List<DishesBook> GetAllReservatoin()
        {
            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {
                return (from d in db.DishesBooks where d.OrderStatus==0 || d.OrderStatus==1 orderby d.BookTime descending select d).ToList();
            }
        }
    }
}
