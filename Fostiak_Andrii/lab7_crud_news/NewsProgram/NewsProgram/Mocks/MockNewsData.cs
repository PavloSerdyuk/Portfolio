using NewsProgram.Interfaces;
using NewsProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsProgram.Mocks
{
    public class MockNewsData : INewsData
    {
        private List<News> news = new List<News>()
        {
            new News()
            {
                id = Guid.NewGuid(),
                ArticleTitle = "Nature",
                ArticleInfo = "Some Information",
                Author_Name = "Andrii",
                Author_Surname = "Fostiak"
            },
             new News()
            {
                id = Guid.NewGuid(),
                ArticleTitle = "Politics",
                ArticleInfo = "Some Information",
                Author_Name = "Artem",
                Author_Surname = "Zali"
            }



        };

        public News AddNews(News news1)
        {
            news1.id = Guid.NewGuid();
            news.Add(news1);
            return news1;
        }

        public void DeleteNews(News news1)
        {
            news.Remove(news1);
        }

        public News UpdateNews(News update_news)
        {
            var existingnews = GetSpecificNews(update_news.id);
            existingnews.ArticleTitle = update_news.ArticleTitle;
            existingnews.ArticleInfo = update_news.ArticleInfo;
            existingnews.Author_Name = update_news.Author_Name;
            existingnews.Author_Surname = update_news.Author_Surname;

            return existingnews;
        }

        public List<News> GetNews()
        {
            return news;
        }

        public News GetSpecificNews(Guid id)
        {
            return news.SingleOrDefault(x => x.id == id);
        }
    }
}
