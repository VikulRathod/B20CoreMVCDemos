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