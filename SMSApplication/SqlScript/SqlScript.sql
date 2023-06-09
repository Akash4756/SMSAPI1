USE [smsapi1]
GO
/****** Object:  Table [dbo].[tbl_Admin]    Script Date: 14-04-2023 15:35:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Mobile] [varchar](20) NULL,
	[Password] [varchar](15) NULL,
	[IsActive] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Employee]    Script Date: 14-04-2023 15:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Gender] [varchar](50) NULL,
	[Mobile] [varchar](20) NULL,
	[Salary] [money] NULL,
	[Address] [varchar](500) NULL,
	[Emp_Code]  AS ('INF'+right('0000'+CONVERT([varchar](5),[Id]),(5))) PERSISTED
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Admin] ON 

INSERT [dbo].[tbl_Admin] ([Id], [Name], [Email], [Mobile], [Password], [IsActive]) VALUES (1, N'admin', N'admin54@gmail.com', N'8755622155', N'12345', 1)
INSERT [dbo].[tbl_Admin] ([Id], [Name], [Email], [Mobile], [Password], [IsActive]) VALUES (2, N'user', N'user98@gmail.com', N'8754221551', N'124', 1)
INSERT [dbo].[tbl_Admin] ([Id], [Name], [Email], [Mobile], [Password], [IsActive]) VALUES (3, N'Rohan', N'rohan55@gmail.com', N'8755145166', N'12594', 1)
INSERT [dbo].[tbl_Admin] ([Id], [Name], [Email], [Mobile], [Password], [IsActive]) VALUES (4, N'Surya', N'surya251@gmail.com', N'8756664251', N'16632', 1)
SET IDENTITY_INSERT [dbo].[tbl_Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Employee] ON 

INSERT [dbo].[tbl_Employee] ([Id], [Name], [Email], [Gender], [Mobile], [Salary], [Address]) VALUES (1, N'Akash Kumar', N'akashkumar98@gmail.com', N'Male', N'9830698711', 26000.0000, N'Dhanbad')
INSERT [dbo].[tbl_Employee] ([Id], [Name], [Email], [Gender], [Mobile], [Salary], [Address]) VALUES (2, N'Rajesh prajapati', N'rajeshprajapati46@gmail.com', N'Male', N'6250598711', 30000.0000, N'Azamgarh')
INSERT [dbo].[tbl_Employee] ([Id], [Name], [Email], [Gender], [Mobile], [Salary], [Address]) VALUES (3, N'Abhay Singh', N'abhaysingh54@gmail.com', N'Male', N'9831259658', 25000.0000, N'Hardoi')
INSERT [dbo].[tbl_Employee] ([Id], [Name], [Email], [Gender], [Mobile], [Salary], [Address]) VALUES (4, N'Gaurav Kumar', N'gauravkumar65@gmail.com', N'Male', N'8789598245', 32000.0000, N'Banaras')
INSERT [dbo].[tbl_Employee] ([Id], [Name], [Email], [Gender], [Mobile], [Salary], [Address]) VALUES (5, N'Rahul Jain', N'rahuljain67@gmail.com', N'Male', N'8102598444', 36000.0000, N'Bangalore')
INSERT [dbo].[tbl_Employee] ([Id], [Name], [Email], [Gender], [Mobile], [Salary], [Address]) VALUES (6, N'Ayushi Rathore', N'ayushirathore14@gmail.com', N'FeMale', N'8247598548', 24000.0000, N'Kanpur')
INSERT [dbo].[tbl_Employee] ([Id], [Name], [Email], [Gender], [Mobile], [Salary], [Address]) VALUES (7, N'Rahul', N'rahul07@gmail.com', N'Male', NULL, 30000.0000, NULL)
INSERT [dbo].[tbl_Employee] ([Id], [Name], [Email], [Gender], [Mobile], [Salary], [Address]) VALUES (8, N'Abhishek Singh', N'abhishek13214@gmail.com', N'Male', NULL, 27000.0000, NULL)
INSERT [dbo].[tbl_Employee] ([Id], [Name], [Email], [Gender], [Mobile], [Salary], [Address]) VALUES (9, N'Priya Bob', N'priya55@gmail.com', N'Female', NULL, 26000.0000, NULL)
INSERT [dbo].[tbl_Employee] ([Id], [Name], [Email], [Gender], [Mobile], [Salary], [Address]) VALUES (11, N'Khushi', N'khushi54@gmail.com', N'Male', NULL, 26000.0000, NULL)
INSERT [dbo].[tbl_Employee] ([Id], [Name], [Email], [Gender], [Mobile], [Salary], [Address]) VALUES (12, N'Anand', N'anand4@gmail.com', N'Male', NULL, 30000.0000, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Employee] OFF
GO
/****** Object:  StoredProcedure [dbo].[login_user]    Script Date: 14-04-2023 15:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[login_user]
@email varchar(100),
@password varchar(100)
as
begin

if(EXISTS(select email from tbl_Admin where email=@email and password=@password))
begin

select 1 isauthenticated
end
else
begin
select 0 isauthenticated
end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_Employees]    Script Date: 14-04-2023 15:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_delete_Employees]
@id int
as
begin

delete from tbl_Employee where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_get_employee]    Script Date: 14-04-2023 15:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_get_employee]
@Id int=null
as
begin
select Id,Name,Email,Gender,Mobile,Salary,Address,Emp_Code from tbl_Employee where Id = isnull(@Id,Id)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_employees]    Script Date: 14-04-2023 15:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_insert_employees]
@name varchar(100),
@email varchar(100),
@gender varchar(10),
@salary money
as 
Begin

declare @c int
select @c=count(*) from tbl_Employee where email=@email
if(@c>0)
begin
	
	select 0 as Created
end
else
begin
insert into tbl_Employee(name,email,gender,salary)values
(@name,@email,@gender,@salary)

	select 1 as Created
end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_update_employees]    Script Date: 14-04-2023 15:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_update_employees]
@id int,
@name varchar(100)=null,
@email varchar(100)=null,
@gender varchar(10)=null,
@salary money=null
as
begin

update tbl_Employee set name=isnull(@name,name),email=isnull(@email,email),gender=isnull(@gender,gender),Salary=isnull(@salary,salary) where id=@id
select 1 as updated
end
GO
