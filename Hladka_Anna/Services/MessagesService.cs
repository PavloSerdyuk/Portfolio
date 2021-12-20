using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AnnaHladkaPortfolio.Data;
using AnnaHladkaPortfolio.DTOS;
using AnnaHladkaPortfolio.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace AnnaHladkaPortfolio.Services
{
	public class MessagesService
	{
		public ApplicationDbContext Context { get; }
		public IHttpContextAccessor HttpContextAccessor { get; }
		public UserManager<ApplicationUser> UserManager { get; }
		public IMapper Mapper { get; }

		public MessagesService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IMapper mapper)
		{
			Context = context;
			HttpContextAccessor = httpContextAccessor;
			UserManager = userManager;
			Mapper = mapper;
		}

		public async Task<ICollection<Chat>> GetChats()
		{
			return await Context.Chats.ToListAsync();
		}

		public async Task<Chat> GetChat(int id)
		{
			return await Context.Chats.FirstOrDefaultAsync(l => l.Id == id);
		}

		public async Task<Chat> CreateChat(ChatCreateDTO chat)
		{
			var c = Mapper.Map<Chat>(chat);
			var result = await Context.Chats.AddAsync(c);
			await Context.SaveChangesAsync();
			await result.ReloadAsync();
			return result.Entity;
		}

		public async Task<bool> DeleteChat(int messageId)
		{
			var message = await Context.Chats.FirstOrDefaultAsync(l => l.Id == messageId);
			if (message == null) return false;
			Context.Chats.Remove(message);
			await Context.SaveChangesAsync();
			return true;
		}

		public async Task<Message> SendMessage(MessageCreateDTO msg)
		{
			var message = Mapper.Map<Message>(msg);
			var result = await Context.Messages.AddAsync(message);
			await Context.SaveChangesAsync();
			await result.ReloadAsync();
			return result.Entity;
		}

		public async Task<Message> UpdateMessage(int id, MessageCreateDTO message)
		{
			var msg = Mapper.Map<Message>(message);
			var result = Context.Messages.Update(msg);
			await Context.SaveChangesAsync();
			await result.ReloadAsync();
			return result.Entity;
		}

		public async Task<ICollection<Message>> GetAllMessages(int chatId)
		{
			return await Context.Messages.Where(l => l.ChatId == chatId).ToListAsync();
		}
		public async Task<Message> GetMessage(int id)
		{
			return await Context.Messages.FirstOrDefaultAsync(l => l.Id == id);
		}

		public async Task<bool> DeleteMessage(int id)
		{
			var message = await Context.Messages.FirstOrDefaultAsync(l => l.Id == id);
			if (message == null) return false;
			Context.Messages.Remove(message);
			await Context.SaveChangesAsync();
			return true;
		}

	}
}
