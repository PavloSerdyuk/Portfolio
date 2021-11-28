using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsProgram.Models;

namespace NewsProgram.Interfaces
{
  public interface INewsData
    {
        List<News> GetNews();

        News GetSpecificNews(Guid id);

        News AddNews(News news);

        void DeleteNews(News news);

        News UpdateNews(News news);

    }
}
