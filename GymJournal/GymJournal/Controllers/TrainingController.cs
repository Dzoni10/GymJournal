using GymJournal.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using GymJournal.DTOs;

namespace GymJournal.Controllers
{
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
        public ActionResult<TrainingDTO> GetPaged([FromQuery] int page, [FromQuery] int pageSize) 
        {
            var result = _trainingService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet]
        [Route("cardio")]
        public ActionResult<TrainingDTO> GetCardioTrainings([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _trainingService.GetCardio(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet]
        [Route("strength")]
        public ActionResult<TrainingDTO> GetStrengthTrainings([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _trainingService.GetStrength(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet]
        [Route("flexibility")]
        public ActionResult<TrainingDTO> GetFlexibilityTrainings([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _trainingService.GetFlexibility(page, pageSize);
            return CreateResponse(result);
        }


    }
}
