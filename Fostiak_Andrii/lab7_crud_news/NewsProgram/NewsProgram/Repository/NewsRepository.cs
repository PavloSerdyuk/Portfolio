using NewsProgram.Interfaces;
using NewsProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsProgram.Repository
{
    public class NewsRepository : INewsData
    {
        private NewsContext _newsContext;

        public NewsRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }
        public News AddNews(News AddNews)
        {
            AddNews.id = Guid.NewGuid();
            _newsContext.News.Add(AddNews);
            _newsContext.SaveChanges();

            return AddNews;
        }

        public void DeleteNews(News news)
        {
            _newsContext.News.Remove(news);
            _newsContext.SaveChanges();
        }

        public List<News> GetNews()
        {
            return _newsContext.News.ToList();
        }

        public News GetSpecificNews(Guid id)
        {
            var newsvariable = _newsContext.News.Find(id);
            return newsvariable;
            //return _newsContext.News.SingleOrDefault(x => x.id == id);
        }

        public News UpdateNews(News updatednews)
        {
            var existingnews = _newsContext.News.Find(updatednews.id);
            if (existingnews != null)
            {
                existingnews.ArticleTitle = updatednews.ArticleTitle;
                existingnews.ArticleInfo = updatednews.ArticleInfo;
                existingnews.Author_Name = updatednews.Author_Name;
                existingnews.Author_Surname = updatednews.Author_Surname;
                
                _newsContext.News.Update(existingnews);
                _newsContext.SaveChanges();
            }
            return updatednews;
        }
    }
}
