Boats-4-U
Boats-4-U is an ASP.NET Web Application (.NET Framework) in the C# programming language. The purpose of this application is to create a platform in which Tasks to be completed can be added.  These tasks can then be assigned to any of the employees and completion of these tasks can be tracked.

Version
Version 1 was "released" on May 11, 2021.


This ReadMe file was created for the release of Version 1.

Description
This app enables the creation, management, and deletion of: Managers, Employees, Tasks and Assignments.

More specifically, Managers can create, update, and delete a profile that includes:

the manager's name
the manager's hired date
the manager's department

Employees can create, update, and delete a profile that includes:

the employee's name
the employee's manager
the employee's hired date
the employee's department

Tasks can be created, updated and deleted which includes:

the task name
the task summary
the assigner name
the task due date
the task importance
the task completed

Assignments can be created, updated and deleted which includes:

the employee's name
the task name
the assigner's name
the assignment's department

This app was optimized for running with Visual Studio Community 2019 Version 16.8.5

Instructions for downloading and installing it are here. Microsoft .NET Framework Version 4.8 was used

A web browser (Chrome, Edge, Firefox, etc) is required.

Requirements
The following Nuget packages may need to be loaded/updated for Visual Studio:

Microsoft.AspNet.Identity.EntityFramework by Microsoft, Version: 2.2.3
Microsoft.AspNet.Identity.Owin by Microsoft, Version: 2.2.3
Microsoft.AspNet.WebApi.Owin by Microsoft, Version 5.2.7
Usage
Initial Setup and Account Setup
Open the TakeAction solution in Visual Studio and run the program by pressing the ISS Express icon
Run the program

This should open your browser.
Copy the URL https://localhost:XXXXX

Under Account you should see a Register endpoint. Click on it.
Register Browser

You are now registered. Repeat these steps each time you are creating a new user account.


Adding a Manager
After the program is running, and you have created a user account, the following steps may be used to create a Manager

From the Home Page:
1.  Click on the Managers link in the NavBar
2.  Click on the Create New link
3.  Enter the Managers First Name, Last Name and Hired Date
4.  Select the Managers Department from the Drop Down list
5.  Hit the create button

Adding an Employee
After the program is running, and you have created a user account, the following steps may be used to create an Employee

From the Home Page:
1.  Click on the Employees link in the NavBar
2.  Click on the Create New link
3.  Enter the Employees First Name, Last Name and Hired Date
4.  Select the Employees Department and Managers Name from the Drop Down list
5.  Hit the create button

Adding a Task
After the program is running, and you have created a user account, the following steps may be used to create a Task

From the Home Page:
1.  Click on the Tasks link in the NavBar
2.  Click on the Create New link
3.  Enter the Task Name, TAsk Summary and Due Date
4.  Check the boxes if the task is Flagged/Important of Completed when applicable
5.  Hit the create button

Adding an Assignment
After the program is running, and you have created a user account, the following steps may be used to create an Assignment

From the Home Page:
1.  Click on the Assignments link in the NavBar
2.  Click on the Create New link 
3.  Enter the Assigner First Name and Assigner Last Name
4.  Select the Employees Name and Task Name from the Drop Down list
5.  Select the Assignment's Department from the Drop Down list
6.  Hit the create button

Viewing a Manager
After the program is running, and you have created a user account, the following steps may be used to edit a Manager

From the Home Page:
1.  Click on the Managers link in the NavBar
2.  Click on the Details link in the desired Manager's card
4.  Click on the Edit link to edit the Manager or click on the Back to list link to return to a list of Managers

Viewing a Employee
After the program is running, and you have created a user account, the following steps may be used to edit an Employee

From the Home Page:
1.  Click on the Managers link in the NavBar
2.  Click on the Details link in the desired Employee's card
4.  Click on the Edit link to edit the Employee or click on the Back to list link to return to a list of Employees

Viewing a Task
After the program is running, and you have created a user account, the following steps may be used to edit a Task

From the Home Page:
1.  Click on the Managers link in the NavBar
2.  Click on the Details link in the desired Task's card
4.  Click on the Edit link to edit the Task or click on the Back to list link to return to a list of Tasks

Viewing an Assignment
After the program is running, and you have created a user account, the following steps may be used to edit an Assignment

From the Home Page:
1.  Click on the Managers link in the NavBar
2.  Click on the Details link in the desired Assignment's card
4.  Click on the Edit link to edit the Assignment or click on the Back to list link to return to a list of Assignments

Editing a Manager
After the program is running, and you have created a user account, the following steps may be used to edit a Manager

From the Home Page:
1.  Click on the Managers link in the NavBar
2.  Click on the Edit link in the desired Manager's card
3.  Change the Manager's First Name, Last Name and Hired Date when applicable
4.  Change the Manager's Department from the Drop Down list when applicable
5.  Hit the Save button

Editing a Employee
After the program is running, and you have created a user account, the following steps may be used to edit an Employee

From the Home Page:
1.  Click on the Employees link in the NavBar
2.  Click on the Edit link in the desired Employee's card
3.  Change the Employee's First Name, Last Name and Hired Date when applicable
4.  Change the Employee's Department and Manager Name from the Drop Down list when applicable
5.  Hit the Save button

Editing a Task
After the program is running, and you have created a user account, the following steps may be used to edit a Task

From the Home Page:
1.  Click on the Tasks link in the NavBar
2.  Click on the Edit link in the desired Task's card
3.  Change the Task's Name, Summary and Due Date when applicable
4.  Change the completed Flagged and Completed check marks when applicable
5.  Hit the Save button

Editing an Assignment
After the program is running, and you have created a user account, the following steps may be used to edit an Assignment

From the Home Page:
1.  Click on the Assignments link in the NavBar
2.  Click on the Edit link in the desired Assignment's card
3.  Change the Assigner's First Name and Last Name when applicable
4.  Change the Employee Name and Task Name from the Drop Down list when applicable
6.  Hit the Save button

Deleting a Manager
After the program is running, and you have created a user account, the following steps may be used to delete an Manager

From the Home Page:
1.  Click on the Managers link in the NavBar
2.  Click on the Delete link in the desired Manager's card
3.  Click on the Delete button

Deleting an Employee
After the program is running, and you have created a user account, the following steps may be used to delete an Employee

From the Home Page:
1.  Click on the Employees link in the NavBar
2.  Click on the Delete link in the desired Employee's card
3.  Click on the Delete button

Deleting a Task
After the program is running, and you have created a user account, the following steps may be used to delete a Task

From the Home Page:
1.  Click on the Tasks link in the NavBar
2.  Click on the Delete link in the desired Task's card
3.  Click on the Delete button

Deleting an Assignment
After the program is running, and you have created a user account, the following steps may be used to delete an Assignment

From the Home Page:
1.  Click on the Assignments link in the NavBar
2.  Click on the Delete link in the desired Assignment's card
3.  Click on the Delete button

Resources
General resources for creation of this README file are:
Make a README
Basic Syntax | Markdown Guide
This project was modeled after the Eleven-Fifty Academy Blue Badge tutorial for Eleven Note
Eleven Note Tutorial
The information in Eleven Note was also used to help create this README.
Resources for implementing Day of the Week Availability for Drivers
Enum.HasFlag(Enum) Method
Enum, Flags, and Bitwise Operators
C# Json.NET Render Flags Enum as String Array
How do you pass multiple enum values in C#?
