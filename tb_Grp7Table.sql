CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(20) NULL, 
    [Email] NCHAR(50) NULL, 
    [Birth] DATETIME2 NULL, 
    [Nationality] NCHAR(15) NULL, 
    [CourseProgram] NCHAR(30) NULL, 
    [Semester] INT NULL, 
    [Location] NCHAR(20) NULL
)
