using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnnaHladkaPortfolio.DTOS;
using AnnaHladkaPortfolio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnaHladkaPortfolio.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChatsController : ControllerBase
	{
		public MessagesService Service { get; }

		public ChatsController(MessagesService service)
		{
			Service = service;
		}

		[HttpGet]
		[Route("all")]
		public async Task<IActionResult> All()
		{
			return Ok(await Service.GetChats());
		}

		[HttpGet]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await Service.GetChat(id));
		}

		[HttpPost]
		public async Task<IActionResult> Create(ChatCreateDTO chat)
		{
			return Ok(await Service.CreateChat(chat));
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int chatId)
		{
			if (!(await Service.DeleteChat(chatId))) return NotFound();
			return Ok();
		}


		[HttpPut]
		public async Task<IActionResult> Update(int id, MessageCreateDTO blogPost)
		{
			return Ok(await Service.UpdateMessage(id, blogPost));
		}
	}
}
