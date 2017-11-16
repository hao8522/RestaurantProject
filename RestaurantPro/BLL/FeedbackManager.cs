using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class FeedbackManager
    {
        private FeedbackService feedbackService = new FeedbackService();
        public int AddFeedback(Suggestion suggestion)
        {
            return feedbackService.AddFeedback(suggestion);
        }


        public List<Suggestion> GetSuggestion(){

            return feedbackService.GetSuggestion();
        }


        public int AcceptFeedback(int suggestionId)
        {
            return feedbackService.AcceptFeedback(suggestionId);
        }
    }

      
}
