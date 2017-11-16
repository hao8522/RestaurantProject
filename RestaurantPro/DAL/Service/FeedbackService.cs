using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;


namespace DAL
{
    public class FeedbackService
    {
        /// <summary>
        /// add feedback
        /// </summary>
        /// <param name="suggestion"></param>
        /// <returns></returns>

        public int AddFeedback(Suggestion suggestion)
        {

            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {
                db.Suggestions.Add(suggestion);
                return db.SaveChanges();
            };
        }

        /// <summary>
        /// get feedback
        /// </summary>
        /// <returns></returns>
        public List<Suggestion> GetSuggestion()
        {
            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {
                return (from s in db.Suggestions where s.StatusId == 0 orderby s.SuggestionTime descending select s).ToList();

            }
        }
        /// <summary>
        /// accept feedback
        /// </summary>
        /// <param name="suggestionId"></param>
        /// <returns></returns>
        public int AcceptFeedback(int suggestionId)
        {
            using(RestaurantDBEntities db= new RestaurantDBEntities()){
                Suggestion suggestion = (from s in db.Suggestions where s.SuggestionId == suggestionId select s).FirstOrDefault();
                db.Entry<Suggestion>(suggestion).State = EntityState.Modified;
                suggestion.StatusId = 1;

                return db.SaveChanges();
            }
            
        }
    }
}
