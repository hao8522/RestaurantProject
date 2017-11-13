using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Models;

namespace TestProject
{
    class Program
    {

        static NewsManager manager = new NewsManager();
        static void Main(string[] args)
        {
            //test database

            // add news
            //News news = new News() { NewsTitle = "Hao is testing ", NewsContents = "Hao is testing the restaurant management system", CategoryId = 2 };

            //Console.WriteLine(manager.AddNews(news));

            //modify news

            //News news = new News() { NewsId=1005, NewsTitle="Hao is test New project",NewsContents= "Hao is testing the restaurant management system with himself",PublishTime=DateTime.Now,CategoryId=2 };

            //Console.WriteLine(manager.Modify(news));


            // delete news 
            //Console.WriteLine(manager.DeleteNews(1006));

            // get 3 news
            //List<News> list = manager.GetNews(3);

            //foreach(var item in list)
            //{
            //    Console.WriteLine(item.NewsId+"\t"+item.NewsTitle+"\t"+item.NewsContents);

            //}

            Console.ReadKey();
            
        }
    }
}
