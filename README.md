# Physical-Media-Database-Step-8 #
By Xavier L.
05/16/2020
![Database Image](./2020-05-18_8-29-34.png)

---
### Description ###
By design this web app is a manual catelog of all physical media the user has.  

---
### Functionality ###
* Create categories of media and media entries
* Modify categories of media and media entries
* Delete categories of media and media entries
* Separated media entries by user and only you can access them

---
### Design ###
The data is stored in three tables. One containing user information, one with the media entries and one with the media categories.
For initial setup the user must provide a valid email address and password. From there the user will be greeted with a screen prompting the creation of a category or a list of existing user created categories.
Creation of the category is simple: just add the name of the category and click submit.
Once you have at least one category created and selected you can then add media entries into those categories.
You are required to have at least a title when filling out a media entry, the category is automatically generated based on the category you selected before and the media entry is saved under your account.

---
#### Create / Drop Database ####
```tsql
USE [master];

IF DB_ID(N'PhysicalMediaDB') IS NOT NULL DROP DATABASE [PhysicalMediaDB];

IF @@ERROR = 3702
	RAISERROR(N'Database cannot be dropped because there are still open connections.',127,127) WITH NOWAIT, LOG;

CREATE DATABASE [PhysicalMediaDB];
GO

USE [PhysicalMediaDB];
GO
```

---
#### mediaTyoes ####
```tsql
/****** Object:  Table [dbo].[mediaTypes]    Script Date: 5/14/2020 7:58:55 PM ******/
CREATE TABLE [dbo].[mediaTypes]
(
	[id]	[int]			IDENTITY		NOT NULL,
	[title] [nvarchar](20)					NOT NULL,
 CONSTRAINT [PK_mediaTypes] PRIMARY KEY([id] ASC)
);
```

---
#### users ####
```tsql
/****** Object:  Table [dbo].[users]    Script Date: 5/14/2020 7:58:55 PM ******/
CREATE TABLE [dbo].[users]
(
	[id]		[int]			IDENTITY		NOT NULL,
	[email]		[nvarchar](40)					NOT NULL,
	[password]	[nvarchar](40)					NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY([id]),
 CONSTRAINT [UQ_users] UNIQUE([email])
);
```

---
#### mediaCatelogs ####
```tsql
/****** Object:  Table [dbo].[mediaCatelog]    Script Date: 5/14/2020 7:58:55 PM ******/
CREATE TABLE [dbo].[mediaCatelog]
(
	[id]			[int]			IDENTITY		NOT NULL,
	[title]			[nvarchar](50)					NOT NULL,
	[dateModified]	[date]							NOT NULL,
	[size]			[float]							NULL,
	[qtyType]		[nchar](2)						NULL,
	[userId]		[int]							NOT NULL,
	[mediaTypeId]	[int]							NOT NULL,
	CONSTRAINT [PK_mediaCatelog] PRIMARY KEY([id]),
	CONSTRAINT [FK_mediaCatelog] FOREIGN KEY([mediaTypeId])
		REFERENCES [dbo].[mediaTypes]([id]),
	CONSTRAINT [FK_mediaCatelog_2] FOREIGN KEY([userId])
		REFERENCES [dbo].[users]([id])
);
```

---
#### Tests Data ####
```tsql
SET NOCOUNT ON;
--Populate table dbo.users
INSERT INTO [dbo].[users]([email],[password])
	VALUES(N'generic_user_1@mail.com',N'qwer1234QWER!@#$');
INSERT INTO [dbo].[users]([email],[password])
	VALUES(N'generic_user_2@mail.com',N'P@ssw0rd1234$');
INSERT INTO [dbo].[users]([email],[password])
	VALUES(N'generic_user_3@mail.com',N'password');
INSERT INTO [dbo].[users]([email],[password])
	VALUES(N'generic_user_4@mail.com',N'someotherpassword');

--Populate table dbo.mediaTypes
INSERT INTO [dbo].[mediaTypes]([title])
	VALUES(N'Manga');
INSERT INTO [dbo].[mediaTypes]([title])
	VALUES(N'PS4 Games');
INSERT INTO [dbo].[mediaTypes]([title])
	VALUES(N'Switch Games');
INSERT INTO [dbo].[mediaTypes]([title])
	VALUES(N'Guide Book');
INSERT INTO [dbo].[mediaTypes]([title])
	VALUES(N'Music CD');

--Populate table dbo.mediaCatelog
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'My First Manga Vol 1', N'2018-12-30', N'30', N'PG', N'1', N'1');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'My First Manga Vol 2', N'2018-12-30', N'45', N'PG', N'1', N'1');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'My First Manga Vol 5', N'2018-12-31', N'55', N'PG', N'1', N'3');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'Game A', N'2019-05-02', NULL, NULL, N'2', N'2');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'Game B', N'2020-01-25', NULL, NULL, N'2', N'1');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'Game C', N'2020-03-15', NULL, NULL, N'2', N'3');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'Game D', N'2015-10-03', NULL, NULL, N'3', N'4');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'Game E', N'2016-06-05', NULL, NULL, N'3', N'4');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'Game F', N'2017-05-05', NULL, NULL, N'3', N'4');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'Game A Guidebook', N'2020-05-14', N'256', N'PG', N'4', N'2');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'Game B Guidebook', N'2020-05-14', N'117', N'PG', N'4', N'1');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'Game C Guidebook', N'2020-05-14', N'400', N'PG', N'4', N'3');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'Time Life Music Collection', N'2020-01-01', N'7', N'TR', N'5', N'4');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'Greatest Hits: Volume 12', N'2020-01-01', N'9', N'TR', N'5', N'4');
INSERT INTO [dbo].[mediaCatelog]([title],[dateModified],[size],[qtyType],[mediaTypeId],[userId])
	VALUES(N'Now Thats What I Call Music', N'2020-01-01', N'10', N'TR', N'5', N'4');
GO

SET NOCOUNT OFF;
```
