using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.WebAPI.Controllers
{
    [ApiController]
    [Route("api/trainingPlan")]
    public class TrainingPlanController : ControllerBase
    {
        private readonly ITrainingPlanService _service;

        public TrainingPlanController(ITrainingPlanService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAllTrainingPlans")]
        [ProducesResponseType(typeof(ICollection<TrainingPlanShortBLL>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllTrainingPlansAsync()
        {
            var trainingPlans = await _service.GetAllTrainingPlansAsync();

            if (trainingPlans.Count == 0)
            {
                return StatusCode(204);
            }

            return Ok(trainingPlans);
        }

        [HttpGet]
        [Route("getTrainingPlanById")]
        [ProducesResponseType(typeof(TrainingPlanFullBLL), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetTrainingPlanByIdAsync([FromQuery] int id)
        {
            var idExists = await _service.TrainingPlanIdExistsAsync(id);
            if (!idExists)
            {
                return StatusCode(404, new { Message = "Тренировочный план не существует" });
            }

            var trainingPlan = await _service.GetTrainingPlanByIdAsync(id);
            if (trainingPlan == null)
            {
                return StatusCode(500, new { Message = "Не удалось найти тренировочный план. Попробуйте позже" });
            }

            return Ok(trainingPlan);
        }

        [HttpPost]
        [Route("createTrainingPlan")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateTrainingPlanAsync([FromBody] TrainingPlanFullBLL plan)
        {
            var planId = await _service.CreateTrainingPlanAsync(plan);

            if (planId == 0)
            {
                return StatusCode(500, new { Message = "Не удалось создать тренировочный план. Попробуйте позже" });
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
                return StatusCode(500, new { Message = "Не удалось обновить тренировочный план. Попробуйте позже" });
            }

            return Ok(planId);
        }

        [HttpDelete]
        [Route("deleteTrainingPlan")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)] 
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteTrainingPlanAsync([FromQuery] int id)
        {
            var idExists = await _service.TrainingPlanIdExistsAsync(id);
            if (!idExists)
            {
                return StatusCode(404, new { Message = "Тренировочный план не существует" });
            }

            var planId = await _service.DeleteTrainingPlanByIdAsync(id);
            if (planId == 0)
            {
                return StatusCode(500, new { Message = "Не удалось удалить тренировочный план. Попробуйте позже" });
            }

            return Ok(id);
        }
    }
}
