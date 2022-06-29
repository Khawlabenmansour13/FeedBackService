using FeedbackService.Core.Models;
using FeedbackService.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackService.Api.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService) 
        {
            _feedbackService =feedbackService ?? throw new ArgumentNullException(nameof(feedbackService));  

        }


        [HttpGet]
        [Route("getFeedbacks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
            var response = await _feedbackService.GetAllFeedbacks();

            if (response == null)
            {
                return NoContent();//empty array
            }
            return Ok(response); // response with data
        }





        [HttpPost]
        [Route("addFeedbacks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddFeedbacks(Feedback feedback)
        {
            var response = await _feedbackService.CreateFeedback(feedback);

            if (response == null)
            {
                return NoContent();//empty array
            }
            return Ok(response); // response with data
        }





        [HttpDelete("{id}", Name ="DeleteFeedback")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> deleteFeedbacks(int id)
        {
            if(!ModelState.IsValid) // ya3ni id mch fi base 
            {
                return BadRequest();
            }

            var response = await _feedbackService.DeleteFeedback(id).ConfigureAwait(false);


            return response;
        }



        [HttpPut("{id}", Name = "UpdateFeedback")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateFeedback(int id,Feedback feedback)
        {
            if (!ModelState.IsValid) // ya3ni id mch fi base 

            {
                return BadRequest();
            }

            var response = await _feedbackService.UpdateFeedback(id, feedback).ConfigureAwait(false);


            return response;
        }
    }
}
