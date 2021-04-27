# asp.net-mvc-sol-arch
Asp.Net MVC Solution Architecture project presents a flexible layered architecture is inspired from some of the best solutions structure's available incorporating the best practices.
It uses the following:-
1. ASP.Net MVC 5.2.3.0
2. .Net Framework 4.5.2
3. Unity.MVC (Nuget package)
4. Entity Framework 6.0 (Nuget package)
5. Repository Pattern with Async Operations
6. SQL Server Express 
7. Entity Framework Power Tools Beta 4 (Visual Studios Extension)

The entire solution is divided into following project structure:-
1. -CG.StarSystem
2.  -A.Infrastructure
3.    --CG.StarSystem.Data
4.  -B.Domain
5.    --CG.StarSystem.ApplicationServices
6.    --CG.StarSystem.Entity
7.    ---Business
8.    ---Models
9.    --CG.StarSystem.Repository
10.  -C. Presentation
11.    --CG.StarSystem.Web
    
 The project 'CG.StarSystem.Web' is ASP.Net MVC which uses the Model present in 'CG.StarSystem.Entity'. The Controller uses the 'CG.StarSystem.ApplicationServices' for business operations using async operations. The async CRUD operations are being done using Entity Framework from 'CG.StarSystem.Repository'. 
 
 Highligts
 ----------
 The main points are the following:-
 1. The connection string is mentioned in the Web.Cofig file of 'CG.StarSystem.Web'
 2. The 'CG.StarSystem.Web' doesn't have any direct connection with the Repository or the database. It only depends on Application          Services and Entity.
 3. All operations are Async from Controller --> ApplicationServices --> Repository --> Entity Framework
 4. Dependency Injection in ASP.NET MVC using Unity IoC Container. The Repository layer has been deliberately left out for flexibity of     replacing.
 5. Entity Models are resued across layers.
 6. Unit of Work is automatically taken care by Entity Framework.
 
 
 Solution Structure
 ------------------
 1. UI(View) --> Controller --> ApplicationServices --> Repository --> Entity Framework --> Database(SQL Server)
 2. <---------------------------Model(Enity) -------------------->
 3. Model Reused Across Layer from UI to Repository. However one cane create other Business Models 
 
 Developers Work Notes
 ---------------------
 1. Project made in Visual Studios Community Edition 2015. 
 2. The 'Entity Framework Power Tools Beta 4 Extension's file named 'extension.vsixmanifest' had to be modified. It was used for 'Reverese Engineer Code First' for generating POCO classes.
 3. Almost ended up by using 'Grifin DAL Repo Generator' but deleted the codes as it uses ADO.Net transactions and not entity framework.
 4. Used only 1 Database Table in SQL Server Express called 'StarDesc'. Script file path is 'asp.net-mvc-sol-arch\CG.StarSystem\CG.StarSystem.Data\StarDesc.sql'
                     
5. Please check the video in point 2 below if the code looks over whelming. The entire project can be made in less than an hour by using visual studios extensions and tools. Also community edition has 'Resharper' in built.

Bibliography
------------
1. https://stackoverflow.com/questions/37724049/using-repository-patern-when-using-async-await-methods-asp-net-mvc5-ef
2. URF (Unit of Work & Repository Framework) in ASP.NET MVC 5 with Entity Framework 6 & Unity 3 - v2
   https://www.youtube.com/watch?v=QwwfTWMrM9k
3. http://www.itworld.com/article/2700950/development/a-generic-repository-for--net-entity-framework-6-with-async-operations.html
4. http://www.dotnetcurry.com/ShowArticle.aspx?ID=617
5. https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/async-and-stored-procedures-with-the-entity-framework-in-an-asp-net-mvc-application
6. http://thedatafarm.com/data-access/installing-ef-power-tools-into-vs2015/
7. http://hannesdorfmann.com/android/evolution-of-the-repository-pattern

 

 
