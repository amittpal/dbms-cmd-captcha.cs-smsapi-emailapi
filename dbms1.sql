create command :- create user <user_name> identified by <password>;
ex:>> create user itdb identified by 123;
=======================================================================
grant command :- it used to take permission for database object.
	syntax :-grant dba to <user_name>
	ex ->> grant dba to itdb;
=======================================================================
	connect user :- connect  usename/password
	                  connect itdb/abc;
=======================================================================
create table syntax :- 
	create table table_name
		(
		<field_name 1> datatype,
		<field_name 1> datatype,
		<field_name 1> datatype,
		.
		.
		.
		.
		<field_name n> datatype,
		)
		ex:- create table student
		(
			empid number(5,0) primary key,
			name varchar2(50)
			)

=========================================================================
for see the description of a table :-
syntax :- desc table_name;
==========================================================================================
direct connect to as superuser database:> sqlplus username/password 
									 sqlplus itdb/abc
==============================================================================================
insert command :>> is used to insert data in database table.
	a)) for inserting all field table :- insert into <table name> values(val1,val2...valn);
b)) for inserting some fields of table:- insert into <table name>(colname,clname n....) values(val1,val2,val n);
=================================================================================================
in():-if we have to get record from two or more condition we use in();
ex:-  	select * from student where rollno in(1234,54646);
================================================================================================
display in ascending and descending:-
select name from student order by name asc/desc;//ascending/decreasing
=========================================================================================
select name from student where name like '%r' or 'r%';//it display those name which starts or ends
with r letter. and if we use this %r% then it display name which contain r.
===============================================================================================
count number of rows in a table:- select count(*) from student;
=============================================================================================
update command :- update <table name> set <field_name>=<val>,<field_name>=<val2> where <field_name>
=<value>;
ex:- update student set rollno=55555 where rollno=12345;
================================================================================================
delete from <table name> where field-name=value;
==================================================================================
alter command is used to modify database structure(database object)
alter table <table name>
===================================================================================
to see all user of database :- select * from all_users;
==================================================================================
to delete table :- drop table <table name>
==================================================================================
to delete database :- drop user <db name> cascade;
===============================================================================
to delete all row from a table :- delete from <table name>
================================================================================
to see all table pof database :- select * from tab;
===================================================================================
to add new column in a table :- alter table <table name> add <field name> datatype(50);
ex :- alter table emp add email varchar2(15);

modify table column :- alter table <tablename> modify <field name> datatype(50)
ex :- alter table emp modify email number(10);

rename column name :- alter table <table name> rename column <field name > to
<new name of field name> datatype(20);

to delete a column of table :-
alter table <table name> drop column <field_name>;
ex:- alter table emp drop column emailid;
===========================================================================
foriegn key making :-
alter table <table_name> add foreign key (common field name in both table) references
<another table_name>(common field_name);
===============================================================================
to change table name :- rename <table_name> to <new table_name>;
=============================================================================
query to insert data in a table by auto increment :- 
insert into emp values((select nvl(max(sid),100)+1 from emp),2,8000,to_date('22-02-2010','dd-mm-yyyy'));
=======================================================================================	
*- when we want to delete a record from the table :- first we have to delete record from the
foreign key table then from primary key table.
*- similarly vice versa adding of record is performed as well;i.e; add first into primary
key then we add record into foreign key table.
=========================================================================================
join operation :-
1) full joining/outer join
2) inner join
3) left join
4) right join
======================================================================================
inner join :-by object :- 
select e.name,s.salary from emp e,student s where e.empid=s.empid;

select name,salary from student inner join emp on student.empid=emp.empid;
======================================================================================
full join :- select name,salary from emp full join student on emp.empid=student.empid;

syntax:select field_name,field_name from <table_name> full join <table_name> on condition;
======================================================================================
right join :- select name,salary from emp right join student on emp.empid=student.empid;
=======================================================================================
conditions :-
select * from <table_name> where name='aman' and/or empid=5;
=======================================================================================
database import/export :-
datatbase importing instructions :-

step 1: open cmd
step 2: exp user name/password file='file_name.dmp' //dont use semicolon in this command//not login//
ex :-   exp itdb/abc file='file_name.dmp'
note:- if u want to delete or drop database u can otherwise not;


to know here is file :- 
step 3: start. //opens file location in a window//


for importing instructions :-
remember username and password of that exported datatbase;
step 1: create that user_name and password in new database;
step 2:	then grant that user;
step 3: imp user_name/password full=y file='file_name.dmp' // dont use semicolon//
step 4: exit from all_users;
ex :- imp itdb/abc full=y file='itdb.dmp' //imported database and its tables and records//

now connect direct to created user :- sqlplus user_name/password //dont use semicolon//





