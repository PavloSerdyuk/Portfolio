using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Training.BLL.Services.Abstractions;
using Training.BLL.Services.Implementations;
using Training.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Training.WebApi.Controllers
{
    [Route("api/trainer")]
    [ApiController]
    public class TrainerController : Controller
    {
        private ITrainerService _trainerService;
        private readonly ILogger<TrainerController> _logger;

        public TrainerController(ITrainerService trainerService,
            ILogger<TrainerController> logger)
        {
            this._trainerService = trainerService;
            this._logger = logger;
        }

        /// <summary>
        /// Creates new traiining.
        /// </summary>
        /// <param name="trainer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromForm] TrainerModel trainer)
        {
            try
            {
                return Ok(await _trainerService.CreateTrainer(trainer));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }

}