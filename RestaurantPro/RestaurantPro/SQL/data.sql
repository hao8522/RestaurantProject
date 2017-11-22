--插入测试数据
use RestaurantDB
go
--管理员信息
insert into SysAdmins(LoginId,LoginPwd,LoginName)values(1001,'123456','Hao')
insert into SysAdmins(LoginId,LoginPwd,LoginName)values(1002,'123456','Wang')
--新闻分类
insert into NewsCategory(CategoryName)values('CompanyNews')
insert into NewsCategory(CategoryName)values('news')
--菜品分类
insert into DishesCategory(CategoryName)values('Sichuan Cuisine')
insert into DishesCategory(CategoryName)values('Hunan Cuisine')
insert into DishesCategory(CategoryName)values('Shandong Cuisine')
insert into DishesCategory(CategoryName)values('Cantonese Cuisine')
insert into DishesCategory(CategoryName)values('Other')
--news
insert into News(NewsTitle,NewsContents,CategoryId)values('Xmas promotion','  AAA offers traditional Cantonese cuisine presented in an enticing and elegant way',1)
insert into News(NewsTitle,NewsContents,CategoryId)values('A Fall Crab Feast','Every fall, heaping plates of steaming hairy crabs are served up to hungry customers throughout China',1)
insert into News(NewsTitle,NewsContents,CategoryId)values('Happy ‘Singles Day’: Chinese Spend Billions in Annual Shopping Spree ',' 

Chinese consumers are spending billions of dollars shopping online for anything from diapers to diamonds on “Singles Day,” a day of promotions that has grown into the world’s biggest e-commerce event.
',2)

--dishes
insert into Dishes(DishesName,UnitPrice,CategoryId)values('Fish Filets',50,1)
insert into Dishes(DishesName,UnitPrice,CategoryId)values('twice cooked pork slices',85,1)
insert into Dishes(DishesName,UnitPrice,CategoryId)values(' Steamed Fish Head',75,2)
insert into Dishes(DishesName,UnitPrice,CategoryId)values('Red pepper cured beef',40,2)
insert into Dishes(DishesName,UnitPrice,CategoryId)values('Fried carp with sweet and sour sauce',70,3)
insert into Dishes(DishesName,UnitPrice,CategoryId)values('Yu Kee braised chicken',60,3)
insert into Dishes(DishesName,UnitPrice,CategoryId)values('Double crispy soup',90,3)
insert into Dishes(DishesName,UnitPrice,CategoryId)values('Double crispy soup',80,4)
--Reservation
insert into DishesBook(HotelName,ConsumeTime,ConsumePersons,RoomType,CustomerName,CustomerPhone,CustomerEmail,Comments)
values('Tianjin Branch','2014-09-11 12:30',5,'Private Room','CCC','13589011222','lilivip@gmail.com','big room')
insert into DishesBook(HotelName,ConsumeTime,ConsumePersons,RoomType,CustomerName,CustomerPhone,CustomerEmail,Comments)
values('Tianjin Branch','2014-10-11 14:30',5,'Private Room','ddd','13889018888','wangxinxin@gmail.com','quite room')
insert into DishesBook(HotelName,ConsumeTime,ConsumePersons,RoomType,CustomerName,CustomerPhone,CustomerEmail,Comments)
values('Beijing Branch','2014-12-10 17:30',5,'Extra Room','EEE','13689011999','liuhuayu@gmail.com','big room')
--recruitment
insert into Recruitment(PostName,PostType,PostPlace,PostDesc,PostRequire,Experience,EduBackground,RequireCount,Manager,PhoneNumber,Email)
values('Manager','Full Time','Tijing','Store manager','3 years work experience','3 years','Bachelor',2,'MMM','15689011231','lichaoyang@hyl.com')
insert into Recruitment(PostName,PostType,PostPlace,PostDesc,PostRequire,Experience,EduBackground,RequireCount,Manager,PhoneNumber,Email)
values('Reception','Full Time','Beijing','AAAAAAAAA','2 years work experience','2 years','Bachelor',5,'DDD','15689011231','lichaoyang@hyl.com')

--feedback
insert into Suggestion(CustomerName,ConsumeDesc,SuggestionDesc,PhoneNumber,Email)
values('DDDD','Wedding','The service was not good','15687423456','duxiaojie@gmail.com')
insert into Suggestion(CustomerName,ConsumeDesc,SuggestionDesc,PhoneNumber,Email)
values('FFFF','Party','too much noise','15686623456','liugang@gmail.com')

