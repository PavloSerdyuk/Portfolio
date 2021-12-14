using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Training.BLL.Services.Abstractions;
using Training.BLL.Services.Implementations;
using Training.BLL.Models;

namespace Training.WebApi.Controllers
{
    [Route("api/training")]
    [ApiController]
    public class TrainingSessionController : Controller
    {
        private ITrainingSessionService _trainingSessionService;
        private readonly ILogger<TrainingSessionController> _logger;

        public TrainingSessionController(ITrainingSessionService trainingSessionService,
            ILogger<TrainingSessionController> logger)
        {
            this._trainingSessionService = trainingSessionService;
            this._logger = logger;
        }

        /// <summary>
        /// Gets training by profile id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>profile</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _trainingSessionService.GetTrainingSession(id));

        /// <summary>
        /// Creates new training.
        /// </summary>
        /// <param name="training"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTrainingSession([FromForm] TrainingSessionModel training) 
        {
            try
            {
                return Ok(await _trainingSessionService.CreateTrainingSession(training));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates training.
        /// </summary>
        /// <param name="training"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateTrainingSession([FromForm] TrainingSessionModel training)
        {
            try
            {
                return Ok(await _trainingSessionService.UpdateTrainingSession(training));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
