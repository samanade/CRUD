# PT Management App

## Contents
* [Brief](#brief)
   * [Additional Requirements](#additional-requirements)
   * [My Approach](#my-approach)
* [Architecture](#architecture)
   * [Database Structure](#database-structure)
   * [CI Pipeline](#ci-pipeline)
* [Project Tracking](#project-tracking)
* [Risk Assessment](#risk-assessment)
* [Testing](#testing)
* [Front-End Design](#front-end-design)
* [Known Issues](#known-issues)
* [Future Improvements](#future-improvements)
* [Authors](#authors)

## Brief
The brief provided to us for this project sets the following out as its overall objective:
"To create a CRUD application with utilisation of supporting tools, methodologies and technologies that encapsulate all core modules covered during training."

I have decided to create a PT management app that allows users to create, read, update andd delete clients and workouts to demonstrate knowledge learnt. 

### Additional Requirements
In addition to what has been set out in the brief, I am also required to include the following:
* A Trello board
* A relational database, consisting of at least two tables that model a relationship
* Clear documentation of the design phase, app architecture and risk assessment
* A c#-based functional application that follows best practices and design principles
* Test suites for the application, which will include automated tests for validation of the application
* A front-end website, created using ASP.NET
* Code integrated into a Version Control System which will be built through a CI server and deployed to a cloud-based virtual machine

### My Approach
To achieve this, I have decided to produce a simple managment app that must allow the user to do the following:
* Create a client (satisfies 'Create') that stores:
   * *First and Last Name*
   * *Phone Number*
   * *Email*
 
* Create a workout (satisfies 'Create') and assign them to a client:
   * *Title* 
   * *Date* 
   * *Thumbnail* 
   * *Client* the workout will be assigned too
  
* View and update client and workout details (satisfies 'Read' and 'Update')
* Delete client or workout (satisfies 'Delete')

## Architecture
### Database Structure
Pictured below is an entity relationship diagram (ERD) showing the structure of the database.
![ERD][erd1]
Everything in green has been implemented into the app, while everything in red has not. The ERD models a many-to-many relationship between Client entities and Workout entities using an association table. This allows the user to create clients and asign multiple workouts in the database with one client. Similarly, many workouts can therefore be associated with a client.

## Project Tracking
Trello was used to track the progress of the project (pictured below). You can find the link to this board here: https://trello.com/b/aJCcDQ1b/

![trello][trello]

## Risk Assessment
![RiskAssessment][riskassessment]

## Front-End Design
When the user navigates to the URL, they are directed to the home page:
![homeloggedout][homeloggedout]


[erd1]: https://i.imgur.com/ZRdRKwo.png
[trello]: https://i.imgur.com/X68OFUm.png
[riskassessment]: https://i.imgur.com/rXQhjK7.png
[homeloggedout]: https://i.imgur.com/6p934TM.png


