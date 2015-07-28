USE SWC_LMS
GO

INSERT INTO GradeLevel(GradeLevelName)
VALUES ('K'),
('1'),
('2'),
('3'),
('4'),
('5'),
('6'),
('7'),
('8'),
('9'),
('10'),
('11'),
('12')

INSERT INTO LMSUser(ID, FirstName, LastName, Email, SuggestedRole, LMSUser.GradeLevelID)
VALUES (NULL,'Eric', 'Wise', 'ericw@swcg.com', 'Student', 1),
(NULL,'Sarah', 'Dutkiewicz', 'sdutk@swcg.com', 'Teacher', NULL),
(NULL,'Eric', 'Ward', 'ward@swcg.com', 'Administrator', NULL),
(NULL,'Elysha', 'Spector', 'espec@swcg.com', 'Parent', NULL),
(NULL,'Steve', 'Gross', 'sgro@swcg.com', 'Student', 12),
(NULL,'Lis', 'Bacus', 'lb@swcg.com', 'Student', 12),
(NULL,'Nikki', 'Karthan', 'nkar@swcg.com', 'Student', 1),
(NULL,'Suzanne', 'Martinez', 'sam@swcg.com', 'Student', 2),
(NULL,'Kel', 'Varnsen', 'kvar@swcg.com', 'Student', 2),
(NULL,'Sven', 'Grammersdorf', 'dorfy@swcg.com', 'Student', 3),
(NULL,'Daffy', 'Duck', 'daffy@swcg.com', 'Student', 3),
(NULL,'Bugs', 'Bunny', 'wabbit@swcg.com', 'Student', 4),
(NULL,'Foghorn', 'Leghorn', 'Isays@swcg.com', 'Student', 4),
(NULL,'Bart', 'Simpson', 'shorts@swcg.com', 'Student', 5),
(NULL,'Lisa', 'Simpson', 'sax@swcg.com', 'Student', 5),
(NULL,'Maggie', 'Simpson', 'pacifier@swcg.com', 'Student', 6),
(NULL,'Barney', 'Gumble', 'duff@swcg.com', 'Student', 6),
(NULL,'Apu', 'Nehostapemapetalon', 'kwik@swcg.com', 'Student', 7),
(NULL,'Moe', 'Sizlack', 'tavern@swcg.com', 'Student', 7),
(NULL,'C Montgomery', 'Burns', 'hounds@swcg.com', 'Student', 8),
(NULL,'Wayland', 'Smithers', 'malibu@swcg.com', 'Student', 8),
(NULL,'Hans', 'Moleman', 'hello@swcg.com', 'Student', 9),
(NULL,'Abraham', 'Simpson', 'gramps@swcg.com', 'Student', 9),
(NULL,'Charlie', 'Brown', 'footballhead@swcg.com', 'Student', 10),
(NULL,'Lucy', 'Ricardo', 'wahhhh@swcg.com', 'Student', 10),
(NULL,'Ethel', 'Mertz', 'neighbor@swcg.com', 'Student', 11),
(NULL,'Ricky', 'Ricardo', 'babaloo@swcg.com', 'Student', 11),
(NULL,'Fred', 'Mertz', 'cheapskate@swcg.com', 'Student', 13),
(NULL,'Donald', 'Duck', 'sailor@swcg.com', 'Student', 13),
(NULL,'Marge', 'Simpson', 'Mmmmm@swcg.com', 'Parent', NULL),
(NULL,'Homer', 'Simpson', 'Donuts@swcg.com', 'Parent', NULL),
(NULL,'Ned', 'Flanders', 'okilie@swcg.com', 'Teacher', NULL),
(NULL,'Edna', 'Crabapple', 'ha@swcg.com', 'Teacher', NULL),
(NULL,'Seymore', 'Skinners', 'nam@swcg.com', 'Administrator', NULL)

INSERT INTO StudentGuardian(GuardianID, StudentID)
VALUES (31,14),
(31,15),
(30,14),
(30,15),
(31,16),
(30,16)

INSERT INTO Subject(SubjectName)
VALUES ('Math'),
('English'),
('Science'),
('Art'),
('Physical Education'),
('History')

INSERT INTO Course(TeacherID, SubjectID, CourseName, CourseDescription, GradeLevel, IsArchived, StartDate, EndDate)
VALUES
(1, 1, 'Algebra 2', 'This is the second Algebra class, we will introduce more complex things.', 8, 1, '20140101', '20140509'),
(1, 1, 'Algebra 1', 'This is the first Algebra 1 class, we will introduce variables and equations.', 8, 0, '20150101', '20150608')

UPDATE  COURSE
SET TeacherID = 2
WHERE TeacherID = 1


INSERT INTO Assignment(CourseID, AssignmentName, PossiblePoints, DueDate, AssignmentDescription)
VALUES(1, 'Quiz 1', 25, '20150606', 'Variables quiz'),
(1, 'Homework 1', 50, '20150506', 'Chapters 1-5 exercises')

INSERT INTO ROSTER(CourseID, UserID, CurrentGrade, IsDeleted)
Values(1, 9, 'F', 0)

INSERT INTO RosterAssignment(RosterID, AssignmentID, PointsEarned, Percentage, Grade)
VALUES (1, 2, 25, 50, 'F'),
(1, 1, 12.5,50,'F')

SELECT * 
FROM LMSUser

SELECT * 
FROM COURSE


