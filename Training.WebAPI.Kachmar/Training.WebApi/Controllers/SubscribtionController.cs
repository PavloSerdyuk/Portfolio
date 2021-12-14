using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.BLL.Services.Abstractions;
using Training.BLL.Services.Implementations;
using Training.BLL.Models;
using Microsoft.Extensions.Logging;

namespace Training.WebApi.Controllers
{
    [Route("api/subscribtion")]
    [ApiController]
    public class SubscribtionController : Controller
    {
        private ISubscribtionService _subscribtionService;
        private readonly ILogger<SubscribtionController> _logger;

        public SubscribtionController(ISubscribtionService subscribtionService,
            ILogger<SubscribtionController> logger)
        {
            this._subscribtionService = subscribtionService;
            this._logger = logger;
        }

        /// <summary>
        /// Gets subscribtion by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>profile</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GeById(int id) =>
            Ok(await _subscribtionService.GetSubscribtion(id));


        /// <summary>
        /// Creates new sub.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateSubscribtion([FromForm] SubscribtionModel subscribtion) 
        {
            try
            {
                return Ok(await _subscribtionService.CreateSubscribtion(subscribtion));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
