USE [SWC_LMS]
GO

ALTER PROCEDURE [dbo].[AdministratorDashboard]

AS

SELECT LMSUser.UserID, LastName,FirstName,Email,SuggestedRole, GradeLevelID
FROM LMSUser
WHERE ID IS NULL



ALTER PROCEDURE [dbo].[AspNetUserAddRole](
@UserId nvarchar(128),
@Name nvarchar(256))

AS

INSERT INTO AspNetUserRoles (UserId, RoleId)
SELECT @UserId, Id AS RoleId
FROM AspNetRoles
WHERE Name = @Name;

ALTER PROCEDURE [dbo].[AspNetUserDeleteRoles](
@Id nvarchar(128))

AS

DELETE FROM AspNetUserRoles WHERE UserId = @Id;

ALTER PROCEDURE [dbo].[AssignmentAdd]  ( --6/9 **RUN ME**
@UserID int,
@CourseID int,
@AssignmentName varchar(50),
@PossiblePoints int,
@DueDate date,
@AssignmentDescription varchar(255) = NULL)

AS

INSERT INTO Assignment (AssignmentName,PossiblePoints,DueDate,AssignmentDescription)
VALUES (@AssignmentName, @PossiblePoints, @DueDate, @AssignmentDescription)

ALTER PROCEDURE [dbo].[CourseAssignmentGradesSlide12]  (  --6/10 Slide #12 **REVIEW**
@UserID int,                                       --2 views: all children view for parents; all student view for teacher
@CourseID int)

AS

SELECT AssignmentDescription,Percentage,Grade,DueDate  --more?
FROM Assignment
INNER JOIN RosterAssignment ON Assignment.AssignmentID = RosterAssignment.AssignmentID
WHERE CourseID = @CourseID

ALTER PROCEDURE [dbo].[CourseGetGradebook]  (  --6/10 Slide #8 **DONE**
@UserID int,                             
@CourseID int)

AS

SELECT LMSUser.UserID,FirstName,LastName,CurrentGrade,Percentage,AssignmentName
FROM LMSUser
INNER JOIN Roster ON LMSUser.UserID = Roster.UserID
INNER JOIN RosterAssignment ON Roster.RosterID = RosterAssignment.RosterID
INNER JOIN Assignment ON RosterAssignment.AssignmentID = Assignment.AssignmentID
WHERE Roster.CourseID = @CourseID

ALTER PROCEDURE [dbo].[CourseGradebookAddScore]  (  --6/10 Slide #8 **DONE**
@UserID int,
@RosterID int,                             
@CourseID int,
@AssignmentID int,
@PointsEarned decimal)

AS

UPDATE RosterAssignment SET
PointsEarned = @PointsEarned
FROM LMSUser
INNER JOIN Roster ON LMSUser.UserID = Roster.UserID
INNER JOIN RosterAssignment ON Roster.RosterID = RosterAssignment.RosterID
INNER JOIN Assignment ON RosterAssignment.AssignmentID = Assignment.AssignmentID
WHERE Roster.CourseID = @CourseID AND Roster.UserID = @UserID AND RosterAssignment.AssignmentID = @AssignmentID
AND RosterAssignment.RosterID = @RosterID

ALTER PROCEDURE [dbo].[GradeLevelGetAll]

AS

SELECT *
FROM GradeLevel

ALTER PROCEDURE [dbo].[LMSUserSelectRoleNames]
	@UserID int

AS

SELECT LMSUser.UserID, LMSUser.ID, FirstName, LastName, LMSUser.Email, SuggestedRole, GradeLevelID
FROM LMSUser
	INNER JOIN AspNetUsers ON LMSUser.ID = AspNetUsers.Id
	INNER JOIN AspNetUserRoles ON AspNetUsers.Id = AspNetUserRoles.UserId
	INNER JOIN AspNetRoles ON AspNetUserRoles.RoleId = AspNetRoles.Id
WHERE LMSUser.UserId = @UserID


ALTER PROCEDURE [dbo].[LMSUserSelectUnassigned]

AS

SELECT *
FROM LMSUser U
	INNER JOIN AspNetUsers ON U.ID = AspNetUsers.Id
	LEFT JOIN  AspNetUserRoles ON AspNetUsers.Id = AspNetUserRoles.UserId
WHERE AspNetUserRoles.UserId IS NULL


ALTER PROCEDURE [dbo].[RoleGetAll]  --6/17

AS

SELECT *
FROM AspNetRoles

ALTER PROCEDURE [dbo].[RosterGetStudentInCourse]  (   --6/10 Slide #7 **DONE**
@UserID int,                            --search for students in course
@CourseID int)

AS

SELECT FirstName,LastName,Email,IsDeleted,GradeLevelID, CourseID
FROM LMSUser
INNER JOIN Roster ON LMSUser.UserID = Roster.UserID
WHERE CourseID = @CourseID AND IsDeleted = 0

ALTER PROCEDURE [dbo].[RosterGetStudentNotInCourse]  (   --6/10 Slide #7 **DONE**
@UserID int,                               --display students not in course
@CourseID int,
@LastName varchar(30) = NULL,
@GradeLevelID tinyint = NULL)

AS

SELECT FirstName,LastName,GradeLevelID,CourseID,RosterID
FROM LMSUser
LEFT JOIN Roster ON LMSUser.UserID = Roster.UserID
WHERE Roster.RosterID IS NULL AND GradeLevelID IS NOT NULL OR CourseID != @CourseID


ALTER PROCEDURE [dbo].[RosterInsertStudent] (   --6/10 Slide #7 **DONE**
@CourseID int,                           --insert student into course
@UserID int,                             --Does roster id change on delete?
@CurrentGrade varchar(3) = NULL,
@IsDeleted BIT = NULL)

AS

INSERT INTO Roster (CourseID,UserID,CurrentGrade,IsDeleted)
VALUES (@CourseID,@UserID,@CurrentGrade,@IsDeleted)

ALTER PROCEDURE [dbo].[RosterRemoveStudent](
@RosterID int,
@UserID int)

AS

DELETE FROM Roster 
WHERE UserID = @UserID AND RosterID = @RosterID


ALTER PROCEDURE [dbo].[UserParentDashboard](
@UserID int)

AS

SELECT FirstName, LastName, UserID
FROM LMSUser
INNER JOIN StudentGuardian ON StudentID = UserID
WHERE GuardianID = @UserID

ALTER PROCEDURE UserSearch(

@LastNamePartial varchar(30) = Null, 
@FirstNamePartial varchar(30) = Null, 
@EmailPartial  varchar(50) = Null, 
@RoleId varchar(256) = Null)

AS 
 
SELECT DISTINCT LMSUser.UserID, LastName, FirstName, Email, GradeLevelID  
FROM LMSUser

LEFT JOIN AspNetUserRoles ON LMSUser.ID = AspNetUserRoles.UserId 
LEFT JOIN AspNetRoles ON AspNetUserRoles.RoleId = AspNetRoles.Id

WHERE  
(LMSUser.ID IS NULL OR LMSUser.ID LIKE '%') 
AND (@LastNamePartial IS NULL OR LastName LIKE @LastNamePartial + '%') 
AND (@FirstNamePartial IS NULL OR FirstName LIKE @FirstNamePartial + '%') 
AND (@EmailPartial IS NULL OR Email LIKE @EmailPartial + '%') 
AND (@RoleId IS NULL OR AspNetRoles.Id = @RoleId)

ALTER PROCEDURE [dbo].[UserStudentDashboard](
@UserID int)

AS 

SELECT CourseName, CurrentGrade
FROM Roster 
INNER JOIN Course ON Course.CourseID = Roster.CourseID
WHERE UserID = @UserID

ALTER PROCEDURE [dbo].[UserTeacherDashboard](
@UserID int)

AS

SELECT c.CourseID, CourseName, IsArchived, (SELECT Count(RosterID) FROM Roster r Where r.CourseID = c.courseID AND r.IsDeleted = 0) AS NumberOfStudents
FROM Course c
WHERE C.TeacherID = @UserID


ALTER PROCEDURE [dbo].[UserTeacherDashboardArchived] ( --6/9 **RUN ME**
@UserID int)

AS

SELECT CourseName, Count(UserID) AS StudentsPerCourse
FROM Roster
INNER JOIN Course ON Course.CourseID = Roster.CourseID
WHERE TeacherID = @UserID AND IsArchived = 1
GROUP BY CourseName


ALTER PROCEDURE [dbo].[UserUpdateDetails]
(
@UserID int,
@FirstName varchar(30),
@LastName varchar(30),
@GradeLevelID tinyint = null,
@ID varchar(128) = null
)
AS

UPDATE LMSUser SET
FirstName = @FirstName,
LastName = @LastName,
GradeLevelID = @GradeLevelID,
ID = @ID

WHERE UserID = @UserID

ALTER PROCEDURE [dbo].[UserViewDetails] (
@UserID INT)
 
AS
 
Select LMSUser.UserID, LMSUser.ID, LastName, FirstName, GradeLevelID, Email, SuggestedRole, AspNetRoles.Name, AspNetRoles.Id, AspNetUserRoles.UserId, AspNetUserRoles.RoleId
FROM LMSUser
	FULL OUTER JOIN AspNetUserRoles ON LMSUser.ID = AspNetUserRoles.UserId
	FULL OUTER JOIN AspNetRoles ON AspNetUserRoles.RoleId = AspNetRoles.Id 
WHERE LMSUser.UserID = @UserID


CREATE PROCEDURE ASPNetIDGet(
@AspNetID varchar(128))

AS

SELECT *
FROM LMSUser
INNER JOIN AspNetUsers ON LMSUser.Email = AspNetUsers.Email
WHERE @AspNetID = AspNetUsers.Id

ALTER PROCEDURE [dbo].[CourseInformationGet] 
@CourseID int)

AS

SELECT Course.CourseID, Course.CourseName,SubjectName,CurrentGrade,StartDate,EndDate,GradeLevel,CourseDescription,IsArchived,
Count(RosterID) AS TotalStudents,
Count(CurrentGrade) AS TotalByGrade
FROM Course
INNER JOIN [Subject] ON Course.SubjectID = Subject.SubjectID
INNER JOIN Roster ON Course.CourseID = Roster.CourseID
WHERE Course.CourseID = @CourseID
GROUP BY Course.CourseID, CourseName,CurrentGrade,SubjectName,StartDate,EndDate,GradeLevel,CourseDescription,IsArchived
ORDER BY CurrentGrade DESC

CREATE PROCEDURE CourseEditInformation(
@CourseID int,
@CourseName varchar(50),
@CourseDescription varchar(255) = Null,
@GradeLevel tinyint,
@IsArchived bit,
@StartDate date,
@EndDate date)

AS 

UPDATE Course SET
CourseName = @CourseName,
CourseDescription = @CourseDescription,
GradeLevel = @GradeLevel,
IsArchived = @IsArchived,
StartDate = @StartDate,
EndDate = @EndDate

WHERE CourseID = @CourseID

CREATE PROCEDURE [dbo].[CourseAddCourse](
@UserID int,
@SubjectID int,
@CourseName varchar(50),
@CourseDescription varchar(255) = NULL,
@GradeLevel tinyint,
@IsArchived bit,
@StartDate date,
@EndDate date)

AS 

INSERT INTO Course(TeacherID, SubjectID, CourseName, CourseDescription, GradeLevel, IsArchived, StartDate, EndDate)
VALUES(@UserID, @SubjectID, @CourseName, @CourseDescription, @GradeLevel, @IsArchived, @StartDate, @EndDate)


