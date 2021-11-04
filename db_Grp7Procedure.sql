CREATE PROCEDURE [dbo].[Procedure]
	@param1 nvarchar(10),
	@mode nvarchar(10),
	@Id int,
	@Name  nvarchar(20),
	@Email  nvarchar(50),
	@Birth datetime2(7),
	@Nationality nvarchar(15),
	@CourseProgram nvarchar(30),
	@Semester  int,	
	@Location  nvarchar(20)
AS
	SELECT @param1

	IF @mode ='Create'
	BEGIN
	insert into [D:\Canada Georgian College\Course\course_dataProgramming\HW\Grp7_assinment1\DB\dbo.Table]
	(Name,
	Email,
	Birth,
	Nationality,
	CourseProgram,
	Semester,	
	Location
	)
	VALUES
	(
	@Name,
	@Email,
	@Birth,
	@Nationality,
	@CourseProgram,
	@Semester,	
	@Location
	)
END 
RETURN 0
