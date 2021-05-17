# SDET Project

**DISCLAMER NO PASSWORD ENCRYPTION IS IMPLEMENTED PLEASE DON'T USE GENUINE PASSWORDS**

## Project Description

I will be creating a Space Invader game that will allow the user to keep track of high scores and compare them against one another. The user will be able to login with a Username and Password allowing the high scores they set to be tracked under their name. 

## Project Goals

* The project has to be a 3 Tier Application
  
  * It should include a Model, Business and GUI Layer
  
    
  
* The project should also include Tests where there are multiple test cases to ensure the application works as intended

  

* The project should include an SQL database with at least two linked tables. These tables will be:
  * The "User" Table to keep track of Username and Password as well as any other data that is related to the user. This table will have a 1 to Many relationship with the Leaderboard table.
  
  * The "Leaderboard" Table to link the Users to their scores.
  
    
  
* The project should use Entity Framework to manage the relationship between the backend object model and the database

  

* The project should be easily tracked through git commits and have a thorough ReadMe File.

  

* The project should also fit the project Description



## Class Diagram

![](/Images/ClassDiagram.png)

## Sprints

### Sprint 1

#### Kanban Board at the start

![](/Images/KanbanBoardSprint1Start.png)

#### Sprint Goals

- [x] Complete User Story 1.2
- [x] Complete User Story 1.3
- [x] Complete User Story 1.4
- [x] Complete User Story 2.3
- [x] Complete User Story 2.4
- [x] Complete User Story 2.5
- [x] Update ReadMe 
- [x] Commit Changes to GitHub
- [x] Add Sprint Review and Retrospective

#### Kanban Board at the end

![KanbanBoardSprint1End](/Images/KanbanBoardSprint1End.png)

#### Sprint Review

In this sprint I managed to complete all User Stories I had in the Sprint Backlog. I created the Database that holds the Users Table as well as the High scores Table. I then created CRUD Methods for both of these tables and finally created tests for the CRUD Methods. 

#### Sprint Retrospective

This Sprints time management was okay. I managed to complete all the user stories I had set myself in the backlog. However, the reason I have labelled this as "okay" is due to one issue I had. While creating the Unit Tests for the CRUD Methods the Update Methods have problems when receiving data from the database and this lead to me wasting over an hour trying to fix it. After trying everything the problem is the tests are relying on the Database to update in time which isn't happening. 

I did however complete some manual testing to make sure the CRUD Methods work and the database updates correctly and it does. Unfortunately without mocking I don't believe these tests will pass. However, as stated I have done manual testing to assure the methods work as intended.

### Sprint 2

#### Kanban Board at the start

![](/Images/KanbanBoardSprint2Start.png)

#### Sprint Goals

- [x] Complete User Story 1.5
- [x] Complete User Story 1.6
- [x] Complete User Story 2.2
- [x] Complete User Story 2.6
- [x] Complete User Story 3.3
- [x] Update ReadMe
- [x] Commit Changes to GitHub
- [x] Add Sprint Review and Retrospective

#### Kanban Board at the end

![](/Images/KanbanBoardSprint2End.png)

#### Sprint Review

For this Sprint I had set myself the task of creating all the GUI elements for the program. I also managed to add some functionality to the buttons to allow general navigation around the program. These are solely here for Manual Testing purposes of the GUI and allow me to make sure all the Pages and Windows display correctly.

#### Sprint Retrospective

This Sprint again had good time management. I managed to complete all user Stories I had set myself in the backlog. At the start of the sprint I taught myself how to use Material Design and ended up spending a few hours figuring out how to do different things within it. This ended up eating into a lot of my time for the sprint however I still managed to finish everything. 

I have then gone on to work on a few extra parts from my Project Backlog. Getting the Login and Registration functionality working.

Taking the above into account I feel as though although it might look like I have a lot of User Stories within my Sprint Backlog at the start of the day I need to think about exactly how much work they require. As I easily managed to complete these even with wasting some of my time this morning learning how to use Material Design.

### Sprint 3

#### Kanban Board at the start

![](/Images/KanbanBoardSprint3Start.png)

#### Sprint Goals

- [x] Complete User Story 2.7
- [x] Complete User Story 2.8
- [x] Complete User Story 2.9
- [x] Complete User Story 2.9.1
- [x] Complete User Story 4.1
- [x] Complete User Story 4.2
- [x] Update ReadMe
- [x] Commit Changes to GitHub
- [x] Add Sprint Review and Retrospective

#### Kanban Board at the end

![](/Images/KanbanBoardSprint3End.png)

#### Sprint Review

For this Sprint I set myself the task of creating the "Game" functionality. Although at the start of the sprint I thought I would have no blockers as the game isn't overly complicated. I ended up having an issue a few hours into the Sprint where I was coding the functionality on the "Business" layer rather than the "GUI" layer. This lead to some issues and I had to switch where the classes were. After fixing this issue writing the code became a lot more simple and I was able to finish this within time. Finally I also set myself the task of implementing Logout functionality which was simple enough. Currently you can only logout from the "Main Menu" however I may add a way to logout while in the game in the future.

#### Sprint Retrospective

In this sprint again I had good time management. I managed to complete all the user stories I had set myself in the backlog. At the start of the sprint as explained in the review I had a slight blocker due to where I had put my classes but this was quickly fixed. I then went on to sort out the logout functionality which was a simple task.

Tomorrow I look to complete the Highscore functionality, I have assigned a day to this as I also need to implement a "Score" system into the game code as currently there is no way of scoring anything. This will then conclude the Project Goals and Definition of Done. However I will look to focus on my Stretch Goals within the project to make the game feel more complete.

### Sprint 4

#### Kanban Board at the start

![](/Images/KanbanBoardSprint4Start.png)

#### Sprint Goals

- [x] Complete User Story 3.1
- [x] Complete User Story 3.2
- [x] Refactor Code
- [x] Update ReadMe
- [x] Commit changes to Github
- [x] Add Sprint Review and Retrospective

#### Kanban Board at the end

![](/Images/KanbanBoardSprint4End.png)

#### Sprint Review

For this sprint I set myself the task of finishing up my main Project Goals the only thing I had left to do was the High Score page and I would be finished. I also added in a last minute "Refactor Code" just to be able to clean up my code a little and make it more DRY. During this sprint however I realised that I hadn't implemented a "score" function within the core game. So although I had added dummy data to test the Highscore list there was no way of actually putting real data onto this list yet. My goal for my next sprint will be to implement this functionality and then I will start to work on some of my stretch goals which include adding pause functionality and remembering user login details.

#### Sprint Retrospective

This sprints time management was again good. I set myself a shorter amount of User Stories however we also had a slightly shorter day. We had a lot of meetings throughout the day which took up some time as well as an earlier review. However this worked out perfectly due to me not having as many User Stories to complete.

Tomorrow I look to implement the scoring functionality to the game as well as the functionality of this score getting added to the database when the player loses. After that my Project will be complete and I will have finished my Definition of Done. I will then work on my Stretch Goals.

### Sprint 5

#### Kanban Board at the start

![](/Images/KanbanBoardSprint5Start.png)

#### Sprint Goals

- [x] Complete User Story 3.4
- [x] Complete User Story 1.6
- [x] Update ReadMe
- [x] Commit changes to Github
- [x] Add Sprint Review and Retrospective

#### Kanban Board at the end

![](/Images/KanbanBoardSprint5End.png)

#### Sprint Review

This Sprint was very short. I only had a few things to finish before officially finishing my Project Goal. Since this has now been completed I will now be focusing on Stretch goals for my next Sprints.  

#### Sprint Retrospective

This sprint was very short and quite easy to implement. I simply needed to add a scoring functionality and a menu to restart/go to main menu when losing. This didn't take much time at all as the Highscore creation was already written and I simply needed to design a Menu to change to visible in the Game page when the user lost. 

My next sprints will now be working on Stretch goals and any additional testing if needed.

### Sprint 6

#### Kanban Board at the start

![](/Images/KanbanBoardSprint6Start.png)

#### Sprint Goals

- [x] Project Clean Up
- [ ] Additional Unit Tests
- [ ] Stretch Goals
- [x] Create Class Diagram for ReadMe
- [ ] Add Instructions on how to setup the application in ReadMe

#### Kanban Board at the end

![](/Images/KanbanBoardSprint6End.png)

#### Sprint Review



#### Sprint Retrospective



## Setup Instructions

If you would like to download the published version of the application please go to here:

Otherwise please follow these setup instructions to be able to edit and work on this project yourself. If you haven't already please start by installing Visual Studio and downloading the Project from GitHub. 

#### Step 1:

Once you have opened the Project in Visual Studio if the packages haven't been automatically installed you must first do this:

1. Open the EarthDefenderModel and right click on Dependencies and click on manage Nuget packages.
2. From here click on browse and search for "EntityFrameworkCore.SQLServer" and "EntityFrameworkCore.Tools" install both of these packages.

![](/Images/Step1.gif)



#### Step 2:

Once you have completed step 1 you must now setup the database. 

1. At the top of Visual Studio search for "Package Manager Console" and open this window. 

2. Inside of here type "add-migration 'name of migration'". Name of migration can be anything you want to call it. Normally this would be "Initial Migration" or something similar. Don't include the quotes around.

3. Once the migration has been added. Next you must "send" this migration to the database. You can do this by simply typing "update-database" into the Package Manager Console. This will take a minute or so to complete but once done you will now have the database setup.   

![](/Images/Step2.gif)



#### Step 3:

Once you have completed step 2 you must now install the GUI packages as I have used Material Design to help with the GUI design you must install "MaterialDesignColors" and "MaterialDesignThemes". Similar to step 1:

1. Open EarthDefenderGUI and right click on Dependencies and click on manage Nuget packages.
2. From here click on browse and search for "MaterialDesignColors" and "MaterialDesignThemes" install both of these packages.

![](/Images/Step3.gif)



This should then complete the Solution setup. From here you can run the application by running EarthDefenderGUI and you can now freely edit and change anything you would like within the solution. 





