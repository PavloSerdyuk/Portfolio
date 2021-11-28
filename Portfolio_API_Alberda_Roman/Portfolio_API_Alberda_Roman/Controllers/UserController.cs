using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Data.Entities;
using Portfolio.Data.Infrastructure;
using Portfolio.Data.Models;
using Portfolio.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_API_Alberda_Roman.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("/login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            string jwt = userService.Login(loginModel.Username, loginModel.Password);
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new { message = "success", token = jwt });
        }
    }
}
