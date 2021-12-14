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
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : Controller
    {
        private IProfileService _profileService;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(IProfileService profileService,
            ILogger<ProfileController> logger)
        {
            this._profileService = profileService;
            this._logger = logger;
        }

        /// <summary>
        /// Gets profile by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>profile</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id) =>
            Ok(await _profileService.GetProfile(id));


        /// <summary>
        /// Creates new profile.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromForm] ProfileModel profile)
        {
            try
            {
                return Ok(await _profileService.CreateProfile(profile));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        /// <summary>
        /// Adds new training to profile
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="trainingId">Training for adding</param>
        /// <returns>profile</returns>
        [HttpPut]
        [Route("{profileId}/{trainingId}")]
        public async Task<IActionResult> AddTrainingById(long profileId, long trainingId)
        {
            try
            {
                return Ok(await _profileService.AddTrainingToProfile(profileId, trainingId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes profile by id.
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteProfile(long profileId) 
        {
            try
            {
                return Ok(await _profileService.DeleteProfile(profileId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates profile.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromForm] ProfileModel profile) 
        {
            try
            {
                return Ok(await _profileService.UpdateProfile(profile));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
