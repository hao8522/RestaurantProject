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

        static RecruitmentManager rManager = new RecruitmentManager();
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


            // add recruitment
            //Recruitment r = new Recruitment() {

            //    PostName="Store Manager",
            //   // PostType= "Full Time",
            //    PostPlace = "Beijing",
            //    PostDesc = " for the beingjing branch store manager",
            //    PostRequire = "work from 10am-10pm",
            //    Experience = "3 years",
            //    EduBackground = "bachelor",
            //    RequireCount = 3,
            //    PublishTime = DateTime.Now,
            //    Manager = "AAA",
            //    PhoneNumber = "0212526928",
            //    Email = "aaa@gmail.com"


            //};

            //Console.WriteLine(rManager.AddPosition(r));

            //modify recruitment
            Recruitment r = new Recruitment()
            {
                PostId=101013,
                PostName = "Store ManagerB",
                 PostType= "Part",
                PostPlace = "Tianjin",
                PostDesc = " for the beingjing branch store manager",
                PostRequire = "work from 10am-10pm",
                Experience = "3 years",
                EduBackground = "bachelor",
                RequireCount = 3,
                PublishTime = DateTime.Now,
                Manager = "BBB",
                PhoneNumber = "0212526928",
                Email = "bbb@gmail.com"

            };

            Console.WriteLine(rManager.ModifyPosition(r));

            Console.ReadKey();
            
        }
    }
}
