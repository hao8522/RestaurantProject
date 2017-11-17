using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
   public  class ReservationManager
    {
       private ReservationService reservationService = new ReservationService();



       public int ModifyReservation(int bookId, int statId)
       {

           return reservationService.ModifyReservation(bookId, statId);
       }


        public List<DishesBook> GetAllReservatoin()
        {

            return reservationService.GetAllReservatoin();
        }
    }
}
