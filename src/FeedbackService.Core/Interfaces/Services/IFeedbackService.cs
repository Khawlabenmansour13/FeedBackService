using FeedbackService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.Core.Services
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacks();
        Task<Feedback> GetFeedbackById(int id);

        Task<int> CreateFeedback(Feedback feedback);
        Task<bool> DeleteFeedback(int id);
        Task<bool> UpdateFeedback(int id, Feedback feedback);


    }
}
