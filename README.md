# SuperFastBlog
A web API designed in asp.net, including an MVC consumption application

=======================First things first DATABASE============================
1. The SQL database is hosted on phpMyAdmin, I used a site called freesqldatabase.com
2. Databse edmx is as follows:
![image](https://user-images.githubusercontent.com/45224724/185356273-b52ee3e0-c308-4d17-8b9b-d9f68a26f0a1.png)

3. For the sake of this assesment, I have deliberately left the database login details on the web config file connection string

4. you can use the following details to login to the database

Host: sql6.freesqldatabase.com
Database name: sql6512841
Database user: sql6512841
Database password: UnD6KHSMnW
Port number: 3306

=====================The Solution=================================
1. The solution contains 2 projects as follows:

 1.1, SuperFastBlog; an asp.net MVC project that contains consumption of the api
 1.2, SuperFastBlogAPI that contains the backend database consumption using controllers and entity framework

2. Please make sure you start both projects at the same time. Right click on the solutions directory => go to Properties, check image below:
![image](https://user-images.githubusercontent.com/45224724/185358701-ec0311cc-ff6c-4c6b-b8a1-0438cf85cf18.png)

click apply and start the projects

====================Web API===============================
You can use Postman to test the api like the following:

![image](https://user-images.githubusercontent.com/45224724/185359426-27ee45d9-1de0-4558-8042-2a09ebb21ae3.png)

========================================API Tests Project======================================
I have also created the tests for each controller and api calls
