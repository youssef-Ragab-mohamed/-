use university;
go
create table faculty
(
f_name varchar(50)  unique,
f_presedint varchar(50)   unique,
f_founded_date date   ,
f_address varchar(50) ,
)
create table department
(
d_id int primary key  ,
d_name varchar(30)  ,
d_manager varchar(50)   unique,
f_name varchar(50)  foreign key (f_name) references faculty(f_name),
)
create table programm
(
p_id int primary key ,
p_name varchar(30)  unique,
d_id int foreign key (d_id) references department(d_id), 

)
create table studentss
(
ssn int primary key  ,
student_name varchar(50)  ,
student_email  varchar(50) ,
student_address varchar(50) ,
student_birthDate date ,
p_id int  foreign key (p_id) references programm(p_id), 
d_id int foreign key (d_id) references department(d_id), 
)
create table courses
(
c_id int primary key  ,
c_name varchar(30)  ,
c_level int  ,
c_hours int  ,
semester int  ,
p_id int foreign key(p_id) references programm(p_id),
d_id int foreign key(d_id) references department(d_id),
 
)
 
create table lecturer
(

l_id int primary key,
l_name varchar(50)  ,
d_id int foreign key (d_id) references department(d_id),
)
create table register
(
 ssn int foreign key(ssn) references studentss(ssn),
 c_id int foreign key(ssn) references courses(c_id),
 mark int   ,
 grade varchar(2) ,
)
select * from studentss
insert into studentss
values(303050,'ali','gmail','cairo','2003-2-7',null,null)
select * from faculty
select  d.d_id,d_name ,f.f_name
from department d join  faculty f  on f.f_name=d.f_name;
CREATE  VIEW student AS
SELECT 
s.ssn,s.student_name,s.student_email,s.student_address,s.student_birthDate,d.d_name,p.p_name
from studentss s join department d on s.d_id=d.d_id join programm p on s.p_id=p.p_id;



 