using AutoMapper;
using FeedbackService.Core.Models;
using FeedbackService.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FeedbackService.Infrastructure.Repositories
{
    public class FeedbackRepository : IFeedbackRepository


    {
        private readonly FeedbackDbContext _dbContext;
        private readonly IMapper _mapper;
        public FeedbackRepository(FeedbackDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<int> CreateFeedback(Feedback feedback)
        {
            var entity = _mapper.Map<
                Entities.
                Feedback>(feedback);    
            _dbContext.Feedback.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;


        }

        public async Task<bool> DeleteFeedback(int id)
        {
          var feedback = await _dbContext.Feedback.FindAsync(id);
        
          if(feedback != null)
            {
                _dbContext.Feedback.Remove(feedback);
                await _dbContext.SaveChangesAsync();
                return true;
            }
          return false;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            var dbFeedbacks = await _dbContext.Feedback.ToListAsync().ConfigureAwait(false);

            return _mapper.Map<IEnumerable<Feedback>>(dbFeedbacks); 
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
            if (id!=0)
            {
                var feedbackbyId = _dbContext.Feedback.FindAsync(id);
                return _mapper.Map<Feedback>(feedbackbyId);
            }
            return null;
        }

        public async Task<bool> UpdateFeedback(int id, Feedback feedback)
        {
            var dbfeedback = await _dbContext.Feedback.FindAsync(id);
            if(dbfeedback == null || dbfeedback.Id != id)
            {
                return false;
            }
            dbfeedback.Subject = feedback.Subject;
            dbfeedback.Message = feedback.Message;
            dbfeedback.Rating = feedback.Rating;
            dbfeedback.CreatedBy = feedback.CreatedBy;
            dbfeedback.CreatedDate = feedback.CreatedDate;
            if(feedback !=null)
            {
                _dbContext.Feedback.Update(dbfeedback);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }
    }
}
