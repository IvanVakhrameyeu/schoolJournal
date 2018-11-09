
use master 
create database schooldb
use schooldb
---------Дропнуть---------
drop database schooldb
------------1------------
create table Subjects  -- ПРЕДМЕТ
(SubjectsID tinyint not null identity primary key, 
SubName varchar(150) not null, 
);

create table Employee -- УЧИТЕЛЬ
(EmployeeID tinyint not null identity primary key, 
SubjectsID tinyint not null foreign key references Subjects(SubjectsID),
FIOEmployee varchar(150) not null, 
Sex varchar(2) not null ,
DOB Date not null, 
Tel varchar(20) not null,
--constrain CheckTeacher check (Sex = 'М' OR Sex= 'Ж') 
);
create table GroupName -- Группы
(GroupNameID tinyint not null identity primary key,
EmployeeID tinyint not null foreign key references Employee(EmployeeID),
Name varchar(20) not null
);
create table MedGroup
(MedGroupID tinyint not null identity primary key,
MedName varchar(50) not null,
);
create table Student -- СТУДЕНТ
(StudentID tinyint not null identity primary key,
GroupNameID tinyint not null foreign key references GroupName(GroupNameID),
MedGroupID tinyint not null foreign key references MedGroup(MedGroupID),
FIO varchar(150) not null, 
Sex varchar(2) not null,
DOB Date not null, 
Tel varchar(20) not null,
AverRating float(50) null
);
----------------- 


---------Таблицы не будет----------- ВМЕСТО НЕЁ, ПРИДМЕТЫ К КАЖДОЙ ГРУППЕ
create table SubjNameTeacher
(
SubjNameTeacherID tinyint not null identity primary key, 
EmployeeID tinyint not null foreign key references Employee(EmployeeID),
SubjectID tinyint not null foreign key references Subjects(SubjectID),
);
----------------- ------------------------
create table Logs  -- ЖУРНАЛ
(LogsID tinyint not null identity primary key, 
Data Date not null, 
StudentID tinyint not null foreign key references Student(StudentID), 
SubjectsID tinyint not null foreign key references Subjects(SubjectsID), 
Missed varchar(1) null,
Rating tinyint null,
Comment varchar(150) null
);
----------ПОЛЬЗОВАТЕЛИ-----------
create table Users
(UsersID tinyint not null identity primary key,
EmployeeID tinyint null foreign key references Employee(EmployeeID),
StudentID tinyint null foreign key references Student(StudentID),
[Login] varchar(50) not null,
[Password] varchar(50) not null,
Access varchar(10) not null
);

---------------УРОКИ--------------
create table Lessons
(LessonsID tinyint not null identity primary key,
SubjectsID tinyint null foreign key references Subjects(SubjectsID),
GroupNameID tinyint null foreign key references GroupName(GroupNameID),
);

---------------------------ТРИГЕРЫ
-------------------------------СТАВИТЬ МОЖНО ТОЛЬКО Нку
------------------------------ Если пропуск, то оценку нельзя поставить
create trigger UpdateRating 
on Logs
after insert, update
as
begin
declare @ID tinyint
declare @Rating tinyint
declare @Missed varchar(1)
set @Rating = (select inserted.Rating from inserted join deleted on (inserted.LogsID = deleted.LogsID))-- join Logs on (inserted.LogsID = Logs.LogsID))
set @ID = (select inserted.LogsID from inserted join deleted on (inserted.LogsID = deleted.LogsID)) --join Logs on (inserted.LogsID = Logs.LogsID))
set @Missed = (select inserted.Missed from inserted join deleted on (inserted.LogsID = deleted.LogsID))-- join Logs on (inserted.LogsID = Logs.LogsID))

if(@Missed != Null AND @Missed !='н')
begin
update Logs set Missed = null where (Logs.LogsID = @ID)
end

if (@Missed = 'н') 
begin 
update Logs set Rating = null where (Logs.LogsID = @ID) 
end
end

drop trigger UpdateRating
-------------средний баллл студента-----------------
create trigger ChangeRating 
on Logs
after insert, update
as
begin
declare @ID tinyint
declare @AvRating float
set @ID = (select inserted.StudentID from  inserted )--on inserted.LogsID =Logs.LogsID) --join deleted on (Logs.LogsID = deleted.LogsID)) --join Logs on (inserted.LogsID = Logs.LogsID))
set @AvRating = (select Avg(Rating) from Logs where (Logs.StudentID = @ID))
update Student set AverRating =  @AvRating where Student.StudentID=@ID
end


drop trigger ChangeRating
--------------------------------------------------------------------------------------
--------------------СТАВИТЬ МОЖНО ТОЛЬКО Нку (пропуск, ничего другого нельзя) сделал в друои триггере
create trigger TMissed 
on Logs
after insert, update
as
begin
declare @ID tinyint
declare @Missed varchar(1)
set @ID = (select inserted.LogsID from inserted join deleted on (inserted.LogsID = deleted.LogsID)) --join Logs on (inserted.LogsID = Logs.LogsID))
set @Missed = (select inserted.Missed from inserted join deleted on (inserted.LogsID = deleted.LogsID))-- join Logs on (inserted.LogsID = Logs.LogsID))

if(@Missed != Null AND @Missed !='н')
begin
update Logs set Missed = null where (Logs.LogsID = @ID)
end
end

drop trigger TMissed
-------------------------------------------
insert Subjects(SubName) 
values 
('Математика'),
('Русский язык'),
('Русская литература'),
('Беларуский язык'),
('Беларуская литература'),
('Физ ра'),
('Физика'),
('Химия'),
('Биология'),
('Георграфия'),
('Английский язык'),
('Труды'),
('Всемирная история'),
('История Беларуси'),
('Обществоведение'),
('Астраномия'),
('Информатика');
--------------
insert Employee(SubjectsID, FIOEmployee, Sex, DOB, Tel) 
values 
('1','Admin',   'М', '1982-08-27', '152-33-32'),
('1','Вася',   'М', '1982-09-27', '252-33-32'),
('2','Оля',    'Ж', '1982-10-17' , '332-11-11'),
('3','Степан',   'М', '1982-02-27', '452-33-32'),
('4','Женя',    'Ж', '1982-01-17' , '532-11-11'),
('5','Антон',    'М', '1982-03-17' , '532-11-11'),
('6','Виктория',    'Ж', '1982-04-17' , '632-11-11'),
('7','Григорий',    'М', '1982-05-17' , '732-11-11'),
('8','Ваня',    'М', '1982-06-17' , '832-11-11'),
('9','Дима',    'М', '1982-07-17' , '932-11-11'),
('10','Паша',    'М', '1982-01-18' , '132-21-11'),
('11','Анатолий',    'М', '1982-01-19' , '532-31-11'),
('12','Егор',    'М', '1982-01-20' , '532-41-11'),
('13','Никитий',    'М', '1982-01-21' , '532-51-11'),
('14','Артем',    'М', '1982-01-22' , '532-61-11'),
('15','Леха',    'М', '1982-01-23' , '532-71-11'),
('16','Данииил',    'М', '1982-01-24' , '532-81-11'),
('17','Саша',    'Ж', '1982-01-25' , '532-91-11');


insert GroupName(EmployeeID,Name) 
values 
(2,'4-а'),
(3,'4-б'),
(4,'7-а'),
(5,'7-б'),
(6,'8-а'),
(7,'8-б'),
(8,'9-а'),
(9,'9-б'),
(10,'10-а'),
(11,'10-б'),
(12,'11-а'),
(13,'11-б');

insert MedGroup(MedName) 
values 
('СМГ'),
('ЛФК'),
('ПОДГ'),
('ОСН');


insert Student(GroupNameID,MedGroupID,FIO, Sex, DOB, Tel) 
values 
(1,1,'Вася',   'М', '1982-08-27', '252-33-32'),
(1,2,'Оля',    'Ж', '1982-08-17' , '232-11-11'),
(2,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(2,3,'Степан',   'М', '1982-02-27', '352-33-32'),
(2,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(3,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(2,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(4,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(2,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(5,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(2,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(6,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(2,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(7,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(2,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(8,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(2,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(9,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(2,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(10,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(10,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(11,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(11,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(12,4,'Женя',    'Ж', '1982-01-17' , '532-11-11'),
(12,4,'Женя',    'Ж', '1982-01-17' , '532-11-11');
-------------------
insert Users(EmployeeID,StudentID, [Login], [Password],Access) 
values
(1,NULL,'Admin',   '1','High'),
(2,NULL,'Teacher',    '1','Middle'),
(3,NULL,'Teacher3',    '1','Middle'),
(4,NULL,'Teacher4',    '1','Middle'),
(5,NULL,'Teacher5',    '1','Middle'),
(6,NULL,'Teacher6',    '1','Middle'),
(7,NULL,'Teacher7',    '1','Middle'),
(8,NULL,'Teacher8',    '1','Middle'),
(9,NULL,'Teacher9',    '1','Middle'),
(10,NULL,'Teacher10',    '1','Middle'),
(11,NULL,'Teacher11',    '1','Middle'),
(12,NULL,'Teacher12',    '1','Middle'),
(13,NULL,'Teacher13',    '1','Middle'),
(14,NULL,'Teacher14',    '1','Middle'),
(15,NULL,'Teacher15',    '1','Middle'),
(16,NULL,'Teacher16',    '1','Middle'),
(17,NULL,'Teacher17',    '1','Middle'),
(NULL,1,'Student',   '1','Low'),
(NULL,2,'Parent',    '1','Low');

---------Таблицы не будет-----------
insert SubjNameTeacher(EmployeeID,SubjectID) 
values 
(2,2),
(3,3),
(4,4);
----------------------------------------------
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) 
values 
('1997-1-2',1,1,'н',4,''),
('1997-2-2',2,3,NULL,5,''),
('1997-3-2',3,2,'н',6,''),
('1997-4-2',4,1,NULL,7,'');
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-1',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-2',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-3',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-4',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-5',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-6',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-7',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-8',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-9',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-10',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-11',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-12',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-13',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-14',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-15',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-16',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-17',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('2018-1-18',1,1,NULL,5,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('1997-1-2',2,1,NULL,6,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('1997-1-2',3,1,'н',7,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('1997-1-2',4,1,'н',8,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('1997-1-2',2,2,NULL,9,'')
insert Logs(Data,StudentID,SubjectsID,Missed,Rating,Comment) values ('1997-1-2',3,3,NULL,10,'')
insert Lessons(GroupNameID,SubjectsID) 
values 
(1,1),
(1,2),
(2,1),
(3,1);




