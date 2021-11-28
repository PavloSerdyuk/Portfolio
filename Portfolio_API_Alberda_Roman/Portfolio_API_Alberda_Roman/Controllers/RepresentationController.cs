using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Portfolio.Data.Entities;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Portfolio_API_Alberda_Roman.Controllers
{
    [Route("api/representations")]
    [ApiController]
    [Authorize(Roles = "User,Admin")]
    public class RepresentationController : Controller
    {
        private IRepresentationService representationService;
        private IUserService userService;
        public RepresentationController(IRepresentationService representationService)
        {
            this.representationService = representationService;
        }

        #region Get
   
        /// <summary>
        /// Gets representation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Representation</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByUserId(int id)
        {
            return Ok(await representationService.GetRepresentation(id));

        }

        /// <summary>
        /// Gets representation by id
        /// </summary>
        /// <returns>Representation</returns>
        [HttpGet("/api/representation/available")]
        public async Task<IActionResult> GetAvailableRepresentation()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await representationService.GetAvailableRepresentation(currentUserName));
        }

        /// <summary>
        /// Gets representation by id
        /// </summary>
        /// <returns>Representation</returns>
        [HttpGet("/api/representation/assigned")]
        public async Task<IActionResult> GetAssignedRepresentation()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await representationService.GetAssignedRepresentation(currentUserName));
        }

        #endregion

        #region Update, Delete, Create

        /// <summary>
        /// Create new representation.
        /// </summary>
        /// <param name="representation"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateRepresentation([FromForm] RepresentationModel representation) =>
                Ok(await representationService.CreateRepresentation(representation));


        /// <summary>
        /// Delete representaion by id.
        /// </summary>
        /// <param name="representationId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteRepresentation(int representationId) =>
                Ok(await representationService.DeleteRepresentation(representationId));

        /// <summary>
        /// Update representation.
        /// </summary>
        /// <param name="representation"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateRepresentation([FromForm] RepresentationModel representation) =>
                Ok(await representationService.UpdateRepresentation(representation));

        #endregion



        /// <summary>
        /// Update representation.
        /// </summary>
        /// <param name="representation"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("assign/{representaionId}")]
        public async Task<IActionResult> AssignRepresentation([FromRoute] int representaionId)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await representationService.AssigneUserToRepresentation(representaionId, currentUserName));
        }

        /// <summary>
        /// Update representation.
        /// </summary>
        /// <param name="representation"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/assiggned/{representaionId}")]
        public async Task<IActionResult> DeleteAssignedRepresentation([FromRoute] int representaionId)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await representationService.DeleteAssignedRepresentationFromUser(representaionId, currentUserName));
        }

    }
}
