# Work Plan
## Introduction
It is planned to provide bike rental services between people and rental organizations or simple users in the country. It was analysed and designed through 1 month.
Gant Chart, WBS and requirements list are ready. I am responsible for both backend and frontend sections of web app.
## Using Git
BASIC Git commands are:
```
git init - *creates a git repo from that directory*
git status - *checks the current state of the repository.*
git add . - *stages the changes in the project*
git commit -m "commit" - *commits changes*
git log - *lists the commits made in that repository in reverse chronological order *
git push - *transfers commits from your local repository to a remote repo*
git pull - *reverse to git push*
```
## Structure
### Identities
The system has to store user roles/identities. 

- Admin
- Owner
- Renter

Admin can create, delete user roles and renters.

### Renters
The system has to store renters. For each *Renter*, you have to store the following properties:

- Name - mandatory
- Location - mandatory (with map location is optional)
- Phone or email - mandatory

Because of data protection regulations, it must be possible to delete a renters by admin. If a renter is deleted, 
all data referencing this - in particular her bike rentals - have to be deleted, too.

### Bikes
The system has to store bikes. For each *Bike*, you have to store the following properties:

- In stock or not - mandatory
- Rental price for 3 days/1 week/1month/1 year - mandatory
- Category - mandatory
  - Standard bike 
  - Mountain bike
  - Trecking bike
  - Racing bike

Each category type has 1 or more bikes - it doesn't matter - there should be 1 post related to this category made by owner.Owner can create,
delete. update posts. If it is not in stock, it should not be seen by renters.

Renters can search bikes by location and category.

### Rentals
The system has to store *rentals* of bikes by renters. The Rentals entity contains the following properties:

- Mandatory reference to the renter who rented the bike
- Optional reference to the rented bike - but it is not important, in message section user can explain
- Rental begin - mandatory date and time
- Rental end - mandatory date and time
- Message - mandatory

Accept or Reject - it is optional requirement for owners.

## Technical Specification
- Microsoft SQL Server to store data
- C# as programming language **back-end**
- ASP.NET MVC as the framework for implementing the project 
- Entity Framework Core to access the database
- Javascript, Jquery as programming languages for **front-end**
- HTML, CSS, Bootstrap(Framework) - for web design
- Unit tests with .NET
- GitHub as source control system
