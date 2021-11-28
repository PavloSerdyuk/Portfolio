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
    public class CVTechnologieController : ControllerBase
    {
        private readonly ICV_TechnologieService service;
        public CVTechnologieController(ICV_TechnologieService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CV>> GetAllCVs()
        {
            try
            {
                var cvs = service.GetAllCVs();

                if (cvs == null)
                    return NoContent();
                else
                    return Ok(cvs);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public ActionResult<CV> GetCVById(Guid id)
        {
            try
            {
                var cv = service.GetCVById(id);

                if (cv == null)
                {
                    return NoContent();
                }

                return Ok(cv);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult CreateCV(CVUpdateDTO newCV)
        {
            try
            {
                service.CreateCV(newCV);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public ActionResult DeleteCV(Guid id)
        {
            try
            {
                service.DeleteCV(id);

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
        public ActionResult UpdateCV(Guid id, CVUpdateDTO cv)
        {
            try
            {
                service.UpdateCV(id, cv);

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

        [HttpGet]
        public ActionResult<IEnumerable<Technologie>> GetAllTechnologies()
        {
            try
            {
                var techs = service.GetAllTechnologies();

                if (techs == null)
                    return NoContent();
                else
                    return Ok(techs);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public ActionResult<Technologie> GetTechnologieById(Guid id)
        {
            try
            {
                var tech = service.GetTechnologieById(id);

                if (tech == null)
                {
                    return NoContent();
                }

                return Ok(tech);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult CreateTechnologie(TechnologieUpdateCreateDTO newTecg)
        {
            try
            {
                service.CreateTechnologie(newTecg);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public ActionResult DeleteTechnologie(Guid id)
        {
            try
            {
                service.DeleteTechnologie(id);

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
        public ActionResult UpdateTechnologie(Guid id, TechnologieUpdateCreateDTO tech)
        {
            try
            {
                service.UpdateTechnologie(id, tech);

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
