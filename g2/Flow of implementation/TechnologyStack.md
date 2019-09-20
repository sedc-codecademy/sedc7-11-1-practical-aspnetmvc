# Lamazon Technologies Stack & Tools

## Tools 🔨
1. Visual Studio - any version that supports .NET CORE 2.1
2. Git - the tool we use for version control
3. GitHub - a service for hosting our projects as repositories (we use Git for commiting)
4. Draw.io - web app for drawing the diagrams we need to represent our app

## Technologies 🔩
1. ASP.NET Core 2.1 - the base technology we base our app on
2. Entity Framework 2.1.11 - communication and querying with a database, we use Code First approach with Linq queries
3. Identity Framework 2.1.6 - helps us alot with user managment, authorization and authentication
4. AutoMapper 7.0.1 - this mapper helps us map through different kind of models in our app. For ex. DTO Model to ViewModel

## Nuget packages versions 🔌
* Microsoft.EntityFrameworkCore 2.1.11 [**DataAccess**, **WebApp**]  
* Microsoft.EntityFrameworkCore.Relational 2.1.11 [**DataAccess**]  
* Microsoft.EntityFrameworkCore.SqlServer 2.1.11 [**DataAccess**]  

* Microsoft.AspNetCore.Identity 2.1.6 [**DataAccess**, **Domain**]  
* Microsoft.AspNetCore.Identity.EntityFrameworkCore 2.1.6 [**DataAccess**]  
* Microsoft.Extensions.Identity.Stores 2.1.6 [**Domain**]  

* AutoMapper 7.0.1 [**Services**]
* AutoMapper.Extensions.Microsoft.DependencyInjection 5.0.1 [**WebApp**]