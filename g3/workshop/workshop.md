# Exercise - World Cup 🛠

## Purpose
You need to create World Cup application where users can preview list of upcoming matches as well as matches that are already finished. Also users need to be able to preview to teams and players inside the teams. 

## Requirements

- Create the architecture of the application including all references between the all projects
- Plan and create the models with the data types that suites most for the the business logic
- Install Entity Framework and create the application DBContext
- Make the relations between all the entities
- Make settings for seeding mock data on creation of the database
- Create migration and generate SQL table from the domain models
- Make default repositories for the models that later will be ready to use in the business layer
- Use dependency injection for registering the repositories (Web app and Data Access should not have direct reference)
- Take the connection string from the **appsettings.json** configuration file

## Models 
1. **Match**
	- Id
	- Date
	- Time
	- Team A
	- Team B
	- Team A Score
	- Team B Score

2. **Team**  
	- Id
	- Name
	- Coach
	- Continent
	- Players

3. **Player**
	- Id
	- Name
	- Age
	- Position
	- Team

## Repository CRUD methods

-	Get All
-	Get By Id
-	Create
-	Update
-	Delete

## *** We won't use any system for Authentication and Authorization for now, that means that anyone can access the application.




