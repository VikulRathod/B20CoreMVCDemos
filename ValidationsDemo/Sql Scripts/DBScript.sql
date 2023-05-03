create database B20ValidationDB
go
use B20ValidationDB
go
create table Student
(
RollNumber int primary key identity,
Name varchar(50),
Gender varchar(10),
Mobile char(10),
Email varchar(100),
Age int
)
go
insert into Student values('Vishal', 'Male', '8956890522', 'v@v.com', 25)
go
create proc usp_AllStudents
as
begin
	select RollNumber, Name, Gender, Mobile, Email, Age from Student
end
go
create proc usp_StudentByRollNumber
@RollNumber int
as
begin
	select RollNumber, Name, Gender, Mobile, Email, Age from Student
	where RollNumber = @RollNumber
end

go
create proc usp_InsertStudent
@Name varchar(50), @Gender varchar(10), @Mobile char(10), @Email varchar(100), @Age int,
@Status bit output
as
begin
	begin try
		if not exists (Select RollNumber from Student where Mobile = @Mobile or Email = @Email)
		begin
			insert into Student values(@Name, @Gender, @Mobile, @Email, @Age)
			set @Status = 1
		end
		else
		begin
			set @Status = 0
		end		
	end try
	begin catch
		set @Status = 0
	end catch
end
go
create proc usp_UpdateStudent
@RollNumber int, @Name varchar(50), @Gender varchar(10), @Mobile char(10), @Email varchar(100), @Age int,
@Status bit output
as
begin
	begin try
		if exists (Select RollNumber from Student where RollNumber = @RollNumber)
		begin
			update Student 
			set Name = @Name, Gender = @Gender, Mobile = @Mobile, Email = @Email, Age = @Age
			where RollNumber = @RollNumber
			set @Status = 1
		end
		else
		begin
			set @Status = 0
		end		
	end try
	begin catch
		set @Status = 0
	end catch
end
go
create proc usp_DeleteStudent
@RollNumber int, @Status bit output
as
begin
	begin try
	begin transaction
		if exists (Select RollNumber from Student where RollNumber = @RollNumber)
		begin
			delete from Student where RollNumber = @RollNumber
			set @Status = 1
		end
		else
		begin
			set @Status = 0
		end	
	commit
	end try
	begin catch		
		set @Status = 0
		rollback
	end catch
end


