using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnnaHladkaPortfolio.Data;
using AnnaHladkaPortfolio.DTOS;
using AnnaHladkaPortfolio.Models;
using AnnaHladkaPortfolio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnaHladkaPortfolio.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		public MessagesService Service { get; }

		public MessagesController(MessagesService service)
		{
			Service = service;
		}

		[HttpGet]
		[Route("all")]
		public async Task<IActionResult> All(int chatId)
		{
			return Ok(await Service.GetAllMessages(chatId));
		}
		
		[HttpGet]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await Service.GetMessage(id));
		}

		[HttpPost]
		public async Task<IActionResult> Create(MessageCreateDTO message)
		{
			return Ok(await Service.SendMessage(message));
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			if (!(await Service.DeleteMessage(id))) return NotFound();
			return Ok();
		}
		

		
		[HttpPut]
		public async Task<IActionResult> Update(int id, MessageCreateDTO message)
		{
			return Ok(await Service.UpdateMessage(id, message));
		}
	}
}
