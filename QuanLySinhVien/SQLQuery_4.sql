create DATABASE QLSV
use QLSV
create table Account(
    ID VARCHAR(15) PRIMARY KEY,
    PWD VARCHAR(15) not null
)
r
select * from school
INSERT INTO  VALUES ('AT',N'An toàn thông tin')
SELECT NameFaculty FROM School;select * from Account
create table Class(
    NameMajors Nvarchar(50) not null,
    NameClass VARCHAR(8) PRIMARY KEY,
    Manager NVARCHAR(40) NOT NULL,
    Leader NVARCHAR(40),    
)
INSERT INTO Class VALUES (N'Công Nghệ Thông Tin','CT5B',N'Phan',N'Trung')
drop table Class
Delete class
SELECT * from Class
select * from Majors
create table Majors(
    IDMajors VARCHAR(10) not null  unique,
    NameMajors NVARCHAR(50) PRIMARY key,
    Amount int,
    Note NVARCHAR(60),
)
drop table Majors
delete Majors
INSERT INTO Majors VALUES('74201',N'Công Nghệ Thông Tin',40,N'Lập trình Mobile')
-- Update rows in table '[TableName]' in schema '[dbo]'
UPDATE Majors SET NameMajors =N'Thái', Amount = 22, Note = N'Code' WHERE IDMajors = '1'
-- Update rows in table '[TableName]' in schema '[dbo]'

DELETE Majors WHERE IDMajors = ''
SELECT COUNT(IDMajors) FROM Majors
create table Student(
    IDStudent VARCHAR(10) PRIMARY KEY,
    NameStudent NVARCHAR(50) not null,
    Class VARCHAR(8)not null,
    BirthDaySt SMALLDATETIME,
    SexSt bit,
    AddressStudent NVARCHAR(30),
    NumberPhoneSt VARCHAR(10),
)
    INSERT INTO Student VALUES ('CT040143',N'Phạm Ngọc Thanh','CT4A','2001/04/22',1,N'Vĩnh Phúc','0903264078')
    INSERT INTO Student VALUES ('CT040145',N'Hoàng Nghĩa Thái','CT4A','2002/04/22',0,N'Nghệ An','0903264079')
    INSERT INTO Student VALUES ('DT030401',N'Nguyễn Xuân Văn','DT3B','2002/04/22',0,N'Nghệ An','0903264079')

    SELECT * FROM Student WHERE Class LIKE '%CT%'
    select * from Student
    SELECT * from Class
select * from Majors
    DELETE Student WHERE IDStudent = 'AT160101'

drop table Student
create table Teacher(
    IDTeacher VARCHAR(10) PRIMARY KEY,
    NameTeacher NVARCHAR(50) not null,
    SexTe bit,
    SubjectTeacher NVARCHAR(50),
    NumberPhoneTe VARCHAR(10),
)
drop table Teacher
alter table Class add constraint NameMajor foreign key (NameMajors) references Majors(NameMajors)
alter table Student add constraint StudentClass foreign key (Class) references Class(NameClass)

INSERT INTO Student VALUES ('CT040142',N'Hoàng Nghĩa Thái','CT4A','2002/04/22',1,N'Nghệ An','0903264079')
