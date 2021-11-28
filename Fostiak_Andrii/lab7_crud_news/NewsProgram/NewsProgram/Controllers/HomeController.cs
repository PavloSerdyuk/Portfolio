using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsProgram.Interfaces;
using NewsProgram.Models;
using NewsProgram.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsProgram.Controllers
{
    public class HomeController: Controller
    {
        private INewsData _newsData;
        private NewsContext _context;
        private readonly IMapper _mapper;

        public HomeController(INewsData newsData, NewsContext context, IMapper mapper)
        {
            _newsData = newsData;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel { NewsVM = _mapper.Map<List<TestNewsView>>(_context.News.ToList()) };
            return View(model);
        }

    }
}
