using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication_ASP_2.Models;

namespace WebApplication_ASP_2.Controllers
{
    [ApiController]
    public class PlatformController : Controller
    {
        private readonly ProjectContext _db;

        public PlatformController()
        {
            _db = new ProjectContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ProjectContext>());
        }

        [Route("platform/getprojectbyid/{id}")]
        [HttpGet]
        public IActionResult GetProjectById(int id)
        {
            var project = _db.projects.Find(id);

            if (project is null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [Route("platform/getvisibilitybyid/{id}")]
        [HttpGet]
        public IActionResult GetVisibilityById(int id)
        {
            var visibility = _db.visibility.Find(id);

            if (visibility is null)
            {
                return NotFound();
            }

            return Ok(visibility);
        }

        [Route("platform/createproject")]
        [HttpPost]
        public IActionResult CreateProject()
        {

            var model = new Project();

            try
            {
                _db.projects.Add(model);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(400);
            }

            return Ok(model);
        }
    }
}