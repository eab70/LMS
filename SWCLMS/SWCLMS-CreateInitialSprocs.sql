USE SWC_LMS
GO

--------------------------------------------------------
ALTER PROCEDURE UserViewDetails  (
@UserID INT)
 
AS
 
Select LMSUser.UserID, LastName, FirstName, GradeLevelID, Email, SuggestedRole, AspNetRoles.Name, AspNetRoles.Id, AspNetUserRoles.UserId, AspNetUserRoles.RoleId
FROM LMSUser
	FULL OUTER JOIN AspNetUserRoles ON LMSUser.ID = AspNetUserRoles.UserId
	FULL OUTER JOIN AspNetRoles ON AspNetUserRoles.RoleId = AspNetRoles.Id 
WHERE LMSUser.UserID = @UserID

EXECUTE UserViewDetails

SELECT *
FROM LMSUser

--------------------------------------------------------
ALTER PROCEDURE UserUpdateDetails --Updated: 06/12/2015 12:54pm--
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


--------------------------------------------------------
ALTER PROCEDURE UserSearch(
@LastNamePartial varchar(30) = Null, 
@FirstNamePartial varchar(30) = Null, 
@EmailPartial varchar(50) = Null, 
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


--------------------------------------------------------
CREATE PROCEDURE UserStudentDashboard(
@UserID int)

AS 

SELECT CourseName, CurrentGrade
FROM Roster 
INNER JOIN Course ON Course.CourseID = Roster.CourseID
WHERE UserID = @UserID

--------------------------------------------------------
CREATE PROCEDURE UserParentDashboard(
@UserID int)

AS

SELECT FirstName, LastName
FROM LMSUser
INNER JOIN StudentGuardian ON StudentID = UserID
WHERE GuardianID = @UserID

--------------------------------------------------------
CREATE PROCEDURE UserTeacherDashboard ( --6/9 **RUN ME**
@UserID int)

AS

SELECT CourseName, Count(UserID) AS StudentsPerCourse
FROM Roster
INNER JOIN Course ON Course.CourseID = Roster.CourseID
WHERE TeacherID = @UserID AND IsArchived = 0
GROUP BY CourseName

--------------------------------------------------------
CREATE PROCEDURE UserTeacherDashboardArchived ( --6/9 **RUN ME**
@UserID int)

AS

SELECT CourseName, Count(UserID) AS StudentsPerCourse
FROM Roster
INNER JOIN Course ON Course.CourseID = Roster.CourseID
WHERE TeacherID = @UserID AND IsArchived = 1
GROUP BY CourseName

--------------------------------------------------------
CREATE PROCEDURE AssignmentAdd  ( --6/9 **RUN ME**
@UserID int,
@CourseID int,
@AssignmentName varchar(50),
@PossiblePoints int,
@DueDate date,
@AssignmentDescription varchar(255) = NULL)

AS

INSERT INTO Assignment (AssignmentName,PossiblePoints,DueDate,AssignmentDescription)
VALUES (@AssignmentName, @PossiblePoints, @DueDate, @AssignmentDescription)
WHERE CourseID = @CourseID                                                    --Is where necessary?

--------------------------------------------------------
CREATE PROCEDURE CourseInformationGet  (  --6/10 Slide #6 **DONE**
@UserID int,
@CourseID int)

AS

SELECT CourseName,SubjectName,CurrentGrade,StartDate,EndDate,GradeLevel,CourseDescription,IsArchived,
Count(RosterID) AS TotalStudents,
Count(CurrentGrade) AS TotalByGrade
FROM Course
INNER JOIN [Subject] ON Course.SubjectID = Subject.SubjectID
INNER JOIN Roster ON Course.CourseID = Roster.CourseID
WHERE Course.CourseID = @CourseID
GROUP BY CourseName,CurrentGrade,SubjectName,StartDate,EndDate,GradeLevel,CourseDescription,IsArchived
ORDER BY CurrentGrade DESC

--------------------------------------------------------
ALTER PROCEDURE RosterGetStudentsInCourse  (
@TeacherID int,                            
@CourseID int)

AS

SELECT FirstName,LastName,Email,IsDeleted,GradeLevelID,RosterID, Roster.CourseID
FROM LMSUser
LEFT JOIN Roster ON LMSUser.UserID = Roster.UserID
LEFT JOIN Course ON LMSUser.UserID = Course.TeacherID
WHERE Roster.CourseID = @CourseID AND IsDeleted = 0
ORDER BY LastName

--------------------------------------------------------
CREATE PROCEDURE RosterInsertStudent (   
@CourseID int,                           
@UserID int,                             
@CurrentGrade varchar(3) = NULL)

AS

IF Exists (SELECT RosterID FROM Roster WHERE CourseID = @CourseID AND UserID = @UserID)

UPDATE Roster
SET IsDeleted = 0
WHERE UserID = @UserID AND CourseID = @CourseID;

ELSE

INSERT INTO Roster (CourseID,UserID,CurrentGrade,IsDeleted)
VALUES (@CourseID,@UserID,@CurrentGrade,0)

--------------------------------------------------------
--ALTER PROCEDURE RosterGetStudentsNotInCourse(
--@LastNamePartial varchar(30) = Null,  
--@GradeLevelID varchar(256) = Null,
--@CourseID int = Null)
 
--AS 
 
--SELECT LmsUser.UserID, FirstName, LastName, GradeLevelID, CourseID
--FROM LMSUser

--LEFT JOIN Roster on LMSUser.UserID = Roster.UserID
 
--WHERE  
--((@LastNamePartial IS NULL OR LastName LIKE @LastNamePartial + '%')
--AND (@GradeLevelID IS NULL OR GradeLevelID LIKE @GradeLevelID + '%')
--AND (@CourseID != CourseID))
--OR ((@LastNamePartial IS NULL OR LastName LIKE @LastNamePartial + '%')
--AND (@GradeLevelID IS NULL OR GradeLevelID LIKE @GradeLevelID + '%')
--AND (@CourseID = CourseID AND IsDeleted = 1))
--OR ((LMSUser.UserID NOT IN (SELECT Roster.UserID FROM Roster))
--AND (SuggestedRole = 'Student')
--AND (@GradeLevelID IS NULL OR GradeLevelID LIKE @GradeLevelID + '%')
--AND (@CourseID != CourseID))

--ALTER PROCEDURE RosterGetStudentsNotInCourse(
--@LastName varchar(30) = Null,  
--@GradeLevelID varchar(256) = Null,
--@CourseID int = Null)
 
--AS 

--SELECT UserID, FirstName, LastName, GradeLevelName
--FROM LMSUser
--	INNER JOIN GradeLevel ON LMSUser.GradeLevelID = GradeLevel.GradeLevelID
--WHERE UserID NOT IN (SELECT UserID FROM Roster WHERE CourseID = @CourseID AND IsDeleted = 0
--AND LastName LIKE @LastName + '%'
--AND @GradeLevelID IS NOT NULL OR LMSUser.GradeLevelID LIKE @GradeLevelID + '%')

--------------------------------------------------------
ALTER PROCEDURE RosterGetStudentsNotInCourse (
@LastName varchar(30) = Null,  
@GradeLevelID tinyint = Null,
@CourseID int = Null
)

AS

SELECT LmsUser.UserID, FirstName, LastName, GradeLevelName
FROM LMSUser
	INNER JOIN GradeLevel ON LMSUser.GradeLevelID = GradeLevel.GradeLevelID
WHERE LMSUser.UserID NOT IN (SELECT UserID FROM Roster WHERE CourseID = @CourseID AND IsDeleted = 0)
AND (@GradeLevelID IS NULL OR LMSUser.GradeLevelID = @GradeLevelID)
AND (@LastName IS NULL or LastName LIKE @LastName + '%')
AND SuggestedRole = 'Student'
ORDER BY LastName

--------------------------------------------------------
--ALTER PROCEDURE TEST (
--@CourseID int = 2
--)

--AS

--SELECT LmsUser.UserID, FirstName, LastName, GradeLevelID, CourseID, RosterID, IsDeleted
--FROM LMSUser

--LEFT JOIN Roster on LMSUser.UserID = Roster.UserID

--WHERE LMSUser.UserID NOT IN (SELECT UserID FROM Roster WHERE CourseID = @CourseID AND IsDeleted = 0)
--and GradeLevelID IS NOT NULL


--exec TEST
--------------------------------------------------------
ALTER PROCEDURE RosterRemoveStudent (
@RosterID int
) 

AS

UPDATE Roster
SET IsDeleted = 1
WHERE RosterID = @RosterID
--------------------------------------------------------

CREATE PROCEDURE CourseGetGradebook  (  --6/10 Slide #8 **DONE**
@UserID int,                             
@CourseID int)

AS

SELECT LMSUser.UserID,FirstName,LastName,CurrentGrade,Percentage,AssignmentName
FROM LMSUser
INNER JOIN Roster ON LMSUser.UserID = Roster.UserID
INNER JOIN RosterAssignment ON Roster.RosterID = RosterAssignment.RosterID
INNER JOIN Assignment ON RosterAssignment.AssignmentID = Assignment.AssignmentID
WHERE Roster.CourseID = @CourseID

--------------------------------------------------------
CREATE PROCEDURE CourseGradebookAddScore  (  --6/10 Slide #8 **DONE**
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

--------------------------------------------------------
CREATE PROCEDURE CourseAssignmentGradesSlide12  (  --6/10 Slide #12 **REVIEW**
@UserID int,                                       --2 views: all children view for parents; all student view for teacher
@CourseID int)

AS

SELECT AssignmentDescription,Percentage,Grade,DueDate  --more?
FROM Assignment
INNER JOIN RosterAssignment ON Assignment.AssignmentID = RosterAssignment.AssignmentID
WHERE CourseID = @CourseID

--------------------------------------------------------
ALTER PROCEDURE AdministratorDashboardSlide2  --(  --6/10 Slide #2 **REVIEW**
--@UserID int)

AS

SELECT UserID,ID,FirstName,LastName,Email,SuggestedRole,GradeLevelID
FROM LMSUser

SELECT *
FROM LMSUser

--------------------------------------------------------
CREATE PROCEDURE MainPageExistingUserLogin  (  --6/11 Slide #1 **REVIEW**
@UserID int,
@Email varchar(50),
@Password  --??)

AS

SELECT UserID,Email
FROM LMSUser
WHERE UserID = @UserID AND Email = @Email

--------------------------------------------------------
CREATE PROCEDURE MainPageNewUserLogin  (  --6/11 Slide #1 **REVIEW**
@UserID int,
@FirstName varchar(30),
@LastName varchar(30),
@Email varchar (50),
@Password --?
@ConfirmPassword  --?
@SuggestedRole varchar (50),
@GradeLevelID tinyint)

AS

SELECT UserID,FirstName,LastName,Email,SuggestedRole,GradeLevelID
FROM LMSUser
WHERE UserID = @UserID AND FirstName = @FirstName AND LastName = @LastName AND Email = @Email
AND SuggestedRole = @SuggestedRole AND GradeLevelID = @GradeLevelID


CREATE PROCEDURE RoleGetAll  --6/17

AS

SELECT *
FROM LMSUser

CREATE PROCEDURE LMSUserSelectRoleNames
	@UserID int

AS

SELECT LMSUser.UserID, LMSUser.ID, FirstName, LastName, LMSUser.Email, SuggestedRole, GradeLevelID
FROM LMSUser
	INNER JOIN AspNetUsers ON LMSUser.ID = AspNetUsers.Id
	INNER JOIN AspNetUserRoles ON AspNetUsers.Id = AspNetUserRoles.UserId
	INNER JOIN AspNetRoles ON AspNetUserRoles.RoleId = AspNetRoles.Id
WHERE LMSUser.UserId = @UserID

ALTER PROCEDURE LMSUserSelectUnassigned

AS

SELECT *
FROM LMSUser U
	INNER JOIN AspNetUsers ON U.ID = AspNetUsers.Id
	LEFT JOIN  AspNetUserRoles ON AspNetUsers.Id = AspNetUserRoles.UserId
WHERE AspNetUsers.Id NOT IN (SELECT AspNetUserRoles.UserId FROM AspNetUserRoles)

--------------------------------------------------------
CREATE PROCEDURE AspNetUserDeleteRoles
@Id nvarchar(128)

AS

DELETE FROM AspNetUserRoles WHERE UserId = @Id;

--------------------------------------------------------
CREATE PROCEDURE AspNetUserAddRole
@UserId nvarchar(128),
@Name nvarchar(256)

AS

INSERT INTO AspNetUserRoles (UserId, RoleId)
SELECT @UserId, Id AS RoleId
FROM AspNetRoles
WHERE Name = @Name;

--------------------------------------------------------








