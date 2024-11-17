using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.WebAPI.Controllers
{
    [ApiController]
    [Route("api/trainingPlan")]
    [Authorize]
    public class TrainingPlanController : ControllerBase
    {
        private readonly ITrainingPlanService _service;

        public TrainingPlanController(ITrainingPlanService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAll")]
        [ProducesResponseType(typeof(ICollection<TrainingPlanShortBLL>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            var trainingPlans = await _service.GetAllAsync();

            if (trainingPlans.Count == 0)
            {
                return StatusCode(204);
            }

            return Ok(trainingPlans);
        }

        [HttpGet]
        [Route("getById")]
        [ProducesResponseType(typeof(TrainingPlanFullBLL), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {
            var trainingPlan = await _service.GetByIdAsync(id);
            if (trainingPlan == null)
            {
                return StatusCode(404, new { Message = "Не удалось найти тренировочный план. Попробуйте позже" });
            }

            return Ok(trainingPlan);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAsync([FromBody] TrainingPlanFullBLL plan)
        {
            var creatingResult = await _service.CreateAsync(plan);

            if (!creatingResult.Success)
            {
                return StatusCode(400, new { Message = creatingResult.Message });
            }

            return Ok(creatingResult);
        }

        [HttpPut]
        [Route("updateTrainingPlan")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateAsync([FromBody] TrainingPlanFullBLL plan)
        {
            var updatingResult = await _service.UpdateAsync(plan);

            if (!updatingResult.Success)
            {
                return StatusCode(400, new { Message = updatingResult.Message });
            }

            return Ok(updatingResult);
        }

        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)] 
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteAsync([FromBody] int id)
        {
            var deletionResult = await _service.DeleteByIdAsync(id);
            if (!deletionResult.Success)
            {
                return StatusCode(400, new { Message = deletionResult.Message });
            }

            return Ok(id);
        }
    }
}
