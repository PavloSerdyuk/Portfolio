using AutoMapper;
using PortfolioYakubych.DTOS;
using PortfolioYakubych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioYakubych.Profiles
{
	public class BlogPostProfile: Profile
	{
		public BlogPostProfile()
		{
			CreateMap<BlogPostCreateDTO, BlogPost>();
			CreateMap<BlogPost, BlogPostCreateDTO>();
		}
	}
}
