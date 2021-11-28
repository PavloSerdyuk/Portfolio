using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsProgram.Interfaces;
using NewsProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsProgram.Controllers
{
  
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsData _newsData;

        public NewsController(INewsData newsData)
        {
            _newsData = newsData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetNews()
        {
            return Ok(_newsData.GetNews());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetSpecificNews(Guid id)
        {
            var news = _newsData.GetSpecificNews(id);

            if(news != null)
            {
                return Ok(news);
            }

            return NotFound($"News with id: {id} was not found.");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddNews(News news)
        {
            _newsData.AddNews(news);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + news.id,
                news);

        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteNews(Guid id)
        {
            var news = _newsData.GetSpecificNews(id);

            if(news != null)
            {
                _newsData.DeleteNews(news);
                return Ok();
            }

            return NotFound($"News with id: {id} was not found.");

        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateNews(Guid id,News updatenews)
        {
            var news = _newsData.GetSpecificNews(id);

            if (news != null)
            {
                updatenews.id = news.id;
                _newsData.UpdateNews(updatenews);
               
            }

            return Ok(updatenews);

        }

    }
}
