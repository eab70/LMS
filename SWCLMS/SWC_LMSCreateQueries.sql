USE SWC_LMS
GO

--CREATE DATABASE SWC_LMS

CREATE TABLE GradeLevel(
GradeLevelID tinyint IDENTITY (1,1) Primary Key,
GradeLevelName varchar(10) not null
)

CREATE TABLE LMSUser(
UserID int IDENTITY(1,1) Primary Key,
ID varchar(128) null,
FirstName varchar(30) not null,
LastName varchar(30) not null,
Email varchar(50) not null,
SuggestedRole varchar(50) null,
GradeLevelID tinyint FOREIGN KEY REFERENCES GradeLevel(GradeLevelID) null)

CREATE TABLE [Subject](
SubjectID int Identity (1,1) Primary Key not null,
SubjectName varchar(50) not null)

CREATE TABLE Course(
CourseID int IDENTITY (1,1) Primary Key not null,
TeacherID int FOREIGN KEY REFERENCES LMSUser(UserID) not null,
SubjectID int FOREIGN KEY REFERENCES[Subject](SubjectID) not null,
CourseName varchar(50) not null,
CourseDescription varchar(255) null,
GradeLevel tinyint not null,
IsArchived bit not null,
StartDate date not null,
EndDate date not null)

CREATE TABLE StudentGuardian(
GuardianID int FOREIGN KEY REFERENCES LMSUser(UserID) not null,
StudentID int FOREIGN KEY REFERENCES LMSUSer(UserID) not null
PRIMARY KEY (GuardianID, StudentID))

CREATE TABLE Assignment(
AssignmentID int IDENTITY(1,1) Primary Key not null,
CourseID int FOREIGN KEY REFERENCES Course(CourseID) not null,
AssignmentName varchar(50) not null,
PossiblePoints int not null,
DueDate date not null,
AssignmentDescription varchar(255) not null)

CREATE TABLE Roster(
RosterID int IDENTITY(1,1) Primary Key not null,
CourseID int FOREIGN KEY REFERENCES Course(CourseID) not null,
UserID int FOREIGN KEY REFERENCES LMSUser(UserID) not null,
CurrentGrade varchar(3) null,
IsDeleted bit not null)

CREATE TABLE RosterAssignment(
RosterAssignmentID int IDENTITY(1,1) Primary Key not null,
RosterID int FOREIGN KEY REFERENCES Roster(RosterID) not null,
AssignmentID int FOREIGN KEY REFERENCES Assignment(AssignmentID) not null,
PointsEarned decimal null,
Percentage decimal(5,2) null,
Grade varchar(3) null)


