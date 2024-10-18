using AutoMapper;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using FitLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.Controllers
{
    [ApiController]
    [Route("api/trainingPlan")]
    public class TrainingPlanController : ControllerBase
    {
        private readonly ITrainingPlanService _service;
        private readonly IPhotoService _photoService;

        public TrainingPlanController(ITrainingPlanService service, IPhotoService photoService, IMapper mapper)
        {
            _service = service;
            _photoService = photoService;
        }

        [HttpGet]
        [Route("getAllTrainingPlans")]
        [ProducesResponseType(typeof(ICollection<TrainingPlanShortBLL>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllTrainingPlansAsync()
        {
            var trainingPlans = await _service.GetAllTrainingPlansAsync();

            if (trainingPlans == null)
            {
                ModelState.AddModelError("GET", "Error while getting list of training plans");
                return StatusCode(500, ModelState);
            }

            if (trainingPlans.Count == 0)
            {
                return StatusCode(204);
            }

            return Ok(trainingPlans);
        }

        [HttpGet]
        [Route("getTrainingPlanById")]
        [ProducesResponseType(typeof(TrainingPlanFullBLL), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetTrainingPlanByIdAsync([FromQuery] int id)
        {
            var idExists = await _service.TrainingPlanIdExistsAsync(id);
            if(!idExists)
            {
                ModelState.AddModelError("GET", "There is no plan with id=" + id);
                return BadRequest(ModelState);
            }

            var trainingPlan = await _service.GetTrainingPlanByIdAsync(id);
            if (trainingPlan == null)
            {
                ModelState.AddModelError("GET", "Error while getting the training plan");
                return StatusCode(500, ModelState);
            }

            return Ok(trainingPlan);
        }

        [HttpPost]
        [Route("createTrainingPlan")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateTrainingPlanAsync([FromForm] TrainingPlanPL plan)
        {
            string photoUrl = string.Empty;
            if (plan.Image.Length > 0)
            {
                var uploadResult = await _photoService.AddPhotoAsync(plan.Image);
                photoUrl = uploadResult.Url.ToString();
            }

            var planBLL = new TrainingPlanFullBLL
            {
                Id = plan.Id,
                Name = plan.Name,
                Description = plan.Description,
                Image = photoUrl,
                Sport = plan.Sport,
                Price = plan.Price,
                Rating = plan.Rating,
                CreatorId = plan.CreatorId,
                Exercises = plan.Exercises
            };

            var planId = await _service.CreateTrainingPlanAsync(planBLL);

            if (planId == 0)
            {
                ModelState.AddModelError("POST", "Error while creating the training plan");
                return StatusCode(500, ModelState);
            }

            return Ok(planId);
        }

        [HttpPut]
        [Route("updateTrainingPlan")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateTrainingPlanAsync([FromBody] TrainingPlanFullBLL plan)
        {
            var planId = await _service.UpdateTrainingPlanAsync(plan);

            if (planId == 0)
            {
                ModelState.AddModelError("PUT", "Error while updating the training plan");
                return StatusCode(500, ModelState);
            }

            return Ok(planId);
        }

        [HttpDelete]
        [Route("deleteTrainingPlan")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)] 
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteTrainingPlanAsync([FromQuery] int id)
        {
            var idExists = await _service.TrainingPlanIdExistsAsync(id);
            if (!idExists)
            {
                ModelState.AddModelError("GET", "There is no plan with id=" + id);
                return BadRequest(ModelState);
            }

            var planId = await _service.DeleteTrainingPlanByIdAsync(id);
            if (planId == 0)
            {
                ModelState.AddModelError("DELETE", "Error while deleting the training plan");
                return StatusCode(500, ModelState);
            }

            return Ok(id);
        }
    }
}
