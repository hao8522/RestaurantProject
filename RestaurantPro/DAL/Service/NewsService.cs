using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class NewsService
    {
        private EFDBHelper helper = new EFDBHelper(new RestaurantDBEntities());
        // add news
        public int AddNews(News news)
        {

            return helper.Add<News>(news);
        }


        // modify news
        public int ModifyNews(News news)
        {
            return helper.Modify<News>(news);
        }

        //delete news
        public int DeleteNews(int newsId)
        {
            News news = new News() { NewsId = newsId };

            return helper.Delete<News>(news);
        }

        // select news
        public List<News> GetNews(int count)
        {
            using (RestaurantDBEntities db= new RestaurantDBEntities())
            {
                //return (from n in db.News orderby n.PublishTime descending select n).Take(count).ToList();

                var newsList = (from n in db.News
                                orderby n.PublishTime descending
                                select new
                                {
                                    n.NewsId,
                                    n.NewsTitle,
                                    n.PublishTime,
                                    n.NewsContents,
                                    n.CategoryId,
                                    n.NewsCategory.CategoryName
                                }).Take(count);

                // covert to object
                List<News> list = new List<News>();
                foreach (var item in newsList)
                {
                    list.Add(new News()
                    {
                        NewsId= item.NewsId,
                        NewsTitle= item.NewsTitle,
                        NewsContents= item.NewsContents,
                        PublishTime= item.PublishTime,
                        CategoryId= item.CategoryId,
                        NewsCategory= new NewsCategory { CategoryName= item.CategoryName}

                    });
                }

                return list;

            }
        }

        //Get News By news id
        public News GetNewsById(int newsId)
        {
            using (RestaurantDBEntities db= new RestaurantDBEntities())
            {
                return (from n in db.News where n.NewsId == newsId select n).FirstOrDefault();
            }
        }


        // get Category of news by categoryId 
        public string GetCategoryName(int categoryId)
        {
            using (RestaurantDBEntities db= new RestaurantDBEntities())
            {
                return (from c in db.NewsCategories where c.CategoryId == categoryId select c.CategoryName).FirstOrDefault();

            }
        }

        // get All Category
        public List<NewsCategory> GetAllCategory()
        {
            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {
                return (from c in db.NewsCategories select c).ToList();
            }
        }
    }
}
