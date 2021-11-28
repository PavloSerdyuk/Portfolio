using CVService_Koval.DTOS;
using CVService_Koval.Models;
using CVService_Koval.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVService_Koval.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDTO>> GetAllUsers()
        {
            try
            {
                var users = userService.GetAllUsers();

                if (users == null)
                    return NoContent();
                else
                    return Ok(users);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public ActionResult<UserWithCVDTO> GetUserById(Guid id)
        {
            try
            {
                var user = userService.GetUserById(id);

                if (user == null)
                {
                    return NoContent();
                }
                
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult CreateUser(UserCreateDTO newUser)
        {
            try
            {
                userService.CreateUser(newUser);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public ActionResult DeleteUser(Guid id)
        {
            try
            {
                userService.DeleteUser(id);

                return NoContent();
            }
            catch (ArgumentException ArgExp)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult UpdateUser(Guid id, UserUpdateDTO user)
        {
            try
            {
                userService.UpdateUser(id, user);

                return Ok();
            }
            catch (ArgumentNullException ArgExp)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
