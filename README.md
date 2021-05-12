# SDET Project

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

- [ ] Complete User Story 1.5
- [ ] Complete User Story 1.6
- [ ] Complete User Story 2.2
- [ ] Complete User Story 2.6
- [ ] Complete User Story 3.3
- [ ] Update ReadMe
- [ ] Commit Changes to GitHub
- [ ] Add Sprint Review and Retrospective

#### Kanban Board at the end



#### Sprint Review



#### Sprint Retrospective

