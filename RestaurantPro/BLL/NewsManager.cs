using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class NewsManager
    {
        private NewsService newsService = new NewsService();

        public int AddNews(News news)
        {

            return newsService.AddNews(news);
        }

        // get news

        public List<News> GetNews(int count)
        {
            return newsService.GetNews(count);
        }

        // get the category of news
        public string GetCategoryName(int categoryId)
        {
            return newsService.GetCategoryName(categoryId);
        }

        // modify news
        public int Modify(News news)
        {
            return newsService.ModifyNews(news);
        }

        // get all news category
        public List<NewsCategory> GetAllCategory()
        {

            return newsService.GetAllCategory();
        }

        // delete News

        public int DeleteNews(int newsId)
        {
            return newsService.DeleteNews(newsId);
        }

    }
}
