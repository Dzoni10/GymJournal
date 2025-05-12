using GymJournal.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using GymJournal.DTOs;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace GymJournal.Controllers
{
    [Authorize]
    [Route("api/trainings")]
    public class TrainingController : BaseApiController
    {
        private readonly ITrainingService _trainingService;
         
        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpPost]
        public ActionResult<TrainingDTO> Create([FromBody]TrainingDTO trainingDTO) 
        {
            var result = _trainingService.Create(trainingDTO);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<TrainingDTO> GetById(int id)
        {
            var result = _trainingService.Get(id);
            return CreateResponse(result);
        }

        [HttpGet]
        [Route("progress")]
        public async Task<ActionResult<TrainingProgressDTO>> GetWeeklyProgress([FromQuery] int year,[FromQuery] int month)
        {
            var userIdClaim = User.FindFirst("id")?.Value;

            if (userIdClaim == null || !int.TryParse(userIdClaim, out var userId))
                return Unauthorized("Invalid or missing user ID in token.");

            var progress = await _trainingService.GetWeeklyProgressAsync(userId, year, month);
            return Ok(progress);
        }

        [HttpGet]
        [Route("userTrainings")]
        public ActionResult<TrainingDTO> GetUserTrainings([FromQuery] int page , [FromQuery] int pageSize )
        {
            var userIdClaim = User.FindFirst("id")?.Value;

            if (userIdClaim == null || !int.TryParse(userIdClaim, out var userId))
                return Unauthorized("Invalid or missing user ID in token.");

            page = page <= 0 ? 1 : page;
            pageSize = pageSize <= 0 ? 10 : pageSize;

            var result = _trainingService.GetUserTrainings(userId, page, pageSize);
            return CreateResponse(result);
        }

        //[HttpGet]
        //[Route("cardio")]
        //public ActionResult<TrainingDTO> GetCardioTrainings([FromQuery] int page, [FromQuery] int pageSize)
        //{
        //    var result = _trainingService.GetCardio(page, pageSize);
        //    return CreateResponse(result);
        //}

        //[HttpGet]
        //[Route("strength")]
        //public ActionResult<TrainingDTO> GetStrengthTrainings([FromQuery] int page, [FromQuery] int pageSize)
        //{
        //    var result = _trainingService.GetStrength(page, pageSize);
        //    return CreateResponse(result);
        //}

        //[HttpGet]
        //[Route("flexibility")]
        //public ActionResult<TrainingDTO> GetFlexibilityTrainings([FromQuery] int page, [FromQuery] int pageSize)
        //{
        //    var result = _trainingService.GetFlexibility(page, pageSize);
        //    return CreateResponse(result);
        //}


    }
}
