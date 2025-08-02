USE master

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'GrowWithLove')
BEGIN
    DROP DATABASE [GrowWithLove]
	USE master
END

CREATE DATABASE GrowWithLove
GO

USE GrowWithLove
GO

CREATE TABLE [dbo].[Users]
(
	UserId		INT PRIMARY KEY IDENTITY (1, 1),
	FirstName	VARCHAR(100) NULL,
	LastName	VARCHAR(100) NULL,
	Age			INT NULL,
	Gender		CHAR(1) NULL
)
GO

CREATE TABLE [dbo].[GroupActivities]
(
	GroupActivityId	INT PRIMARY KEY IDENTITY (1, 1),
	Name			VARCHAR(100) NULL,
	Description		VARCHAR(500) NULL,
	Date			DATETIME NULL,
	Place			VARCHAR(500) NULL,
	UserId			INT NOT NULL

	FOREIGN KEY (UserId) REFERENCES Users(UserId)
)
GO

CREATE TABLE [dbo].[GroupActivityRequirements] (
    GroupActivityRequirementId	INT PRIMARY KEY IDENTITY(1,1),
    Name						INT NOT NULL,    
	GroupActivityId				INT

    FOREIGN KEY (GroupActivityId) REFERENCES GroupActivities(GroupActivityId)
);
GO

/*---------------------------- SELECTS ----------------------------*/
SELECT * FROM [dbo].[Users]
SELECT * FROM [dbo].[GroupActivities]
SELECT * FROM [dbo].[GroupActivityRequirements]

