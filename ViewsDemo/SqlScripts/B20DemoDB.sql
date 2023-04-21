create database B20DemoDB
go
use B20DemoDB
go
create table Category
(
CategoryId int primary key identity,
Name varchar(200),
Description varchar(500)
)
go
insert into Category values 
('Shirt', 'Shirt Description')
,('Shoes', 'Shoes Description')
go
use B20DemoDB
go
create table Product
(
ProductId int primary key identity,
Name varchar(500),
UnitPrice int
)
go
insert into Product values ('Mobile', 10000)
insert into Product values ('Laptop', 50000)
insert into Product values ('TV', 15000)
go
select * from Product
go 
create proc usp_InsertProduct
@Name varchar(500), @Price int
as
begin
	insert into product values(@Name, @Price)
end
go 
alter proc usp_InsertProduct
@Name varchar(500), @Price int, @Status bit out
as
begin
begin try
	insert into product values(@Name, @Price)
	set @Status = 1
end try
begin catch
	set @Status = 0
end catch
end