using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_ASP_2.Models;

namespace WebApplication_ASP_2.Controllers
{
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly ProjectContext _db;

        public ProjectController()
        {
            _db = new ProjectContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ProjectContext>());
        }

        [Route("project/projectstable")]
        [HttpGet]
        public IActionResult ProjectsTable()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Identity/Account");
            }

            var projectsList = from a in _db.projects
                                    select new Project
                                    {
                                        id = a.id,
                                        name = a.name,
                                        description = a.description,
                                        repository = a.repository,
                                        price = a.price,
                                        visibility_id = a.visibility_id
                                    };

            return View(projectsList);
        }

        [Route("project/projectdetails/{id}")]
        [HttpGet]
        public IActionResult ProjectDetails(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Identity/Account");
            }

            var project = _db.projects.Find(id);
            return View(project);
        }

        [Route("project/projectedit/{id}")]
        [HttpGet]
        public IActionResult ProjectEdit(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Identity/Account");
            }

            var project = _db.projects.Find(id);

            var visibilityTypes = from a in _db.visibility
                                  select a.name;

            ViewData["visibilityTypes"] = new SelectList(visibilityTypes.ToList());

            return View(project);
        }

        [Route("project/projectedit/{id}")]
        [HttpPost, ActionName("ProjectEdit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProjectEditOperation(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Identity/Account");
            }

            var project = _db.projects.Find(id);

            if (await TryUpdateModelAsync<Project>(project,
                "",
                p => p.name, p => p.description, p => p.repository, p => p.price, p => p.user_id, p => p.visibility_id))
            {
                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(ProjectsTable));
            }

            return RedirectToAction(nameof(ProjectsTable));
        }

        [Route("project/projectdelete/{id}")]
        [HttpGet]
        public IActionResult ProjectDelete(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Identity/Account");
            }

            var project = _db.projects.Find(id);
            _db.projects.Remove(project);
            _db.SaveChanges();

            return RedirectToAction(nameof(ProjectsTable));
        }

        [Route("project/projectcreate")]
        [HttpGet]
        public IActionResult ProjectCreate()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Identity/Account");
            }

            var visibilityTypes = from a in _db.visibility
                                  select a.name;

            ViewData["visibilityTypes"] = new SelectList(visibilityTypes.ToList());

            return View();
        }

        [Route("project/projectcreate")]
        [HttpPost, ActionName("ProjectCreate")]
        [ValidateAntiForgeryToken]
        public IActionResult ProjectCreateOperation(Project model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Identity/Account");
            }

            _db.projects.Add(model);
            _db.SaveChanges();

            return RedirectToAction(nameof(ProjectsTable));
        }
    }
}



//_db.visibility.Add(new Visibility { name = "Visible" });
//_db.visibility.Add(new Visibility { name = "Rejected" });
//_db.visibility.Add(new Visibility { name = "In review" });
//_db.visibility.Add(new Visibility { name = "Deleted" });
//_db.projects.Add(new Project { name = "test", description = "test", repository = "/", price = 12, user_id = 1, visibility_id = 1 });
//_db.SaveChanges();