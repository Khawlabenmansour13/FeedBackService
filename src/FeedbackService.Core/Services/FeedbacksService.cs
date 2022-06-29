using FeedbackService.Core.Models;
using FeedbackService.Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.Core.Services
{
    public class FeedbacksService : IFeedbackService


    {

        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbacksService( IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository ?? throw new ArgumentNullException(nameof(feedbackRepository));   

        }

        public Task<int> CreateFeedback(Feedback feedback)
        {
           return _feedbackRepository.CreateFeedback(feedback);
        }

        public Task<bool> DeleteFeedback(int id)
        {
          return _feedbackRepository.DeleteFeedback(id);
        }

        public Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
           return _feedbackRepository.GetAllFeedbacks();
        }

        public Task<Feedback> GetFeedbackById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFeedback(int id, Feedback feedback)
        {
            return _feedbackRepository.UpdateFeedback(id, feedback);
        }
    }
}
