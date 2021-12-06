using AutoMapper;
using PortfolioYakubych.DTOS;
using PortfolioYakubych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioYakubych.Profiles
{
	public class CommentProfile : Profile
	{
		public CommentProfile()
		{
			CreateMap<CommentCreateDTO, Comment>();
			CreateMap<BlogPost, CommentCreateDTO>();
		}
	}

}
