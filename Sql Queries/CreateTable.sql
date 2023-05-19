create database TEST; 
use TEST;

CREATE TABLE Employees (
    PersonID int IDENTITY(1,1) PRIMARY Key ,
    FirstName nvarchar(100) Not NULL,
    MiddleInitial nvarchar(5) ,
    LastName nvarchar(100) Not NULL ,
    Address nvarchar(255),
    DateofBirth date,
    SSN int Not NULL
);
--drop table Employees
INSERT into Employees VALUES( 'Khrystyna', 'K', 'Kryzh' , '85021 W Dunlap Phoenix AZ' ,'02/19/1998' , '854546545');
INSERT into Employees VALUES( 'Volodymyr', '', 'Pentek' , '85021 W Dunlap Phoenix AZ' ,'02/19/1988' , '854546561');
INSERT into Employees VALUES( 'Sam', 'L', 'Smith' , '25 W Sunny St, Deerfield IL' ,'07/28/1997' , '488846545');
INSERT into Employees VALUES( 'Olga', '', 'Mehs' , '857 Green Ave Chicago IL' ,'02/19/1998' , '713546545');
INSERT into Employees VALUES( 'Fiona', 'S', 'Dove' , '8531 N 1st Ave San Diego CA' ,'08/15/1978' , '854458545');

Select * from Employees;
--delete  from Employees where PersonId = 6;