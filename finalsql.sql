create database mobile_centre_management

create table customer (
	serviceid varchar(60) PRIMARY KEY NOT  NULL,
	employeeid varchar(60) NOT NULL,
	name varchar(20) NOT NULL,
	sex varchar(3) NOT NULL,
	imeino bigint NOT NULL,
	brandname varchar(20) NOT NULL,
	modelname varchar(10) NOT NULL,
	brandtype varchar(20) NOT NULL,
	dos varchar(30) NOT NULL,
	mobileno bigint NOT NULL,
	address varchar(150) NOT NULL,
	problems varchar(120)NOT NULL,
	CONSTRAINT FK_brandid FOREIGN KEY (imeino) REFERENCES mobilemodel(imeino)
	)

drop table customer
alter table customer add imeino bigint foreign key REFERENCES mobilemodel(imeino) NOT NULL
	
select *from customer

CREATE TABLE UNREPAIRED
(
	unrepaired int identity(1,1) PRIMARY KEY  NOT NULL,
	serviceid varchar(60)  NOT  NULL,
	employeeid varchar(60) NOT NULL,
	name varchar(20) NOT NULL,
	sex varchar(3) NOT NULL,
	imeino bigint NOT NULL,
	brandname varchar(30) NOT NULL,
	modelname varchar(10) NOT NULL,
	brandtype varchar(20) NOT NULL,
	dos varchar(30) NOT NULL,
	mobileno bigint NOT NULL,
	address varchar(150) NOT NULL,
	problems varchar(120)NOT NULL,
	operation varchar(1) NOT NULL

)
select *from UNREPAIRED
drop table UNREPAIRED

CREATE TRIGGER trgafterinsertcustomer ON customer
for INSERT
AS
BEGIN
DECLARE @serviceid varchar(60),@employeeid varchar (60),@name varchar (20),@sex varchar (3),@imeino bigint ,@brandname varchar(30),@modelname varchar(10),@brandtype varchar(15),@dos varchar(25),@mobileno bigint,@address varchar (150),@problems varchar(120)

SELECT @serviceid = serviceid from inserted
SELECT @employeeid = employeeid from inserted
SELECT @name = name  from inserted
SELECT @sex = sex from inserted
select @imeino = imeino from inserted
SELECT @brandname = brandname from inserted
SELECT @modelname = modelname from inserted
SELECT @brandtype = brandtype from inserted
SELECT @dos = dos from inserted
SELECT @mobileno = mobileno from inserted
SELECT @address = address from inserted
SELECT @problems = problems from inserted
insert into UNREPAIRED(serviceid,employeeid,name,sex,imeino,brandname,modelname,brandtype,dos,mobileno,address,problems,operation) values(@serviceid,@employeeid,@name,@sex,@imeino,@brandname,@modelname,@brandtype,@dos,@mobileno,@address,@problems,'I');
SET NOCOUNT ON;
END

create table mobilebrand
( 
	IdBrand bigint not null,
	Brandname varchar(20) not null,
	Primary Key(Idbrand)
)

create table mobilemodel
(
	imeino bigint Primary key not null,
	IdBrand bigint Not null,
	modelname varchar (20) unique NOT NULL,
	
)
ALTER TABLE mobilemodel
ADD FOREIGN KEY (Idbrand) REFERENCES mobilebrand(IdBrand);

drop table mobilemodel

SELECT mobilemodel.modelname
FROM mobilebrand
FULL OUTER JOIN mobilemodel
ON mobilebrand.IdBrand = mobilemodel.IdBrand
WHERE mobilebrand.Brandname = 'MI'		

create table repairdetails
(
	employeeid varchar(50) NOT NULL,
	details varchar(100) NOT NULL,
	brandname varchar(20) NOT NULL,
	type varchar(20) NOT NULL,
	dateofdelievery  varchar (30) NOT NULL,
	modelname varchar(60),
	cost int NOT NULL,
	INSURANCE varchar NOT NULL,
	serviceid varchar(60) FOREIGN KEY REFERENCES customer(serviceid),
	imeino bigint FOREIGN KEY REFeRENCES mobilemodel(imeino)
)
 drop