using AutoMapper;
using AnnaHladkaPortfolio.DTOS;
using AnnaHladkaPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnaHladkaPortfolio.Profiles
{
	public class MessageProfile: Profile
	{
		public MessageProfile()
		{
			CreateMap<MessageCreateDTO, Message>();
			CreateMap<Message, MessageCreateDTO>();
		}
	}
}
