-- =========================================
-- Create table template Windows Azure SQL Database 
-- =========================================
--DROP TABLE Mst_Customer
CREATE TABLE Mst_Customer
(
	Customer_Row_Id INT IDENTITY PRIMARY KEY NOT NULL,
	Customer_Serial INT,
	Name VARCHAR(1000) NULL,
	IsHof BIT,
	Age INT,
	Address VARCHAR(MAX),
	Family_Id INT,
	Hof_Id INT, --customer_id of the Hof
	Adhar_No VARCHAR(50),
	Relation_With_Hof_Id INT,
	Gaurdian_Name VARCHAR(1000),
	Gaurdian_Rel_Id INT,
	Mobile_No VARCHAR(20),
	CardNumber VARCHAR(100) NULL,
	Card_Category_Id INT,
	Active BIT,
	Created_Date DATETIME,
	Inactivated_Date DATETIME
)
GO
--DROP TABLE Mst_Cat
CREATE TABLE Mst_Cat
(
	Cat_Id INT IDENTITY PRIMARY KEY NOT NULL,
	Cat_Desc VARCHAR(100) NULL
)
GO
--DROP TABLE Mst_Role
CREATE TABLE Mst_Role
(
	Role_Id INT IDENTITY PRIMARY KEY NOT NULL,
	Dist_Id INT,
	Role_Desc VARCHAR(50),
	ControlIdToHide VARCHAR(50)
)
GO
--DROP TABLE Mst_Dist
CREATE TABLE Mst_Dist
(
	Dist_Id INT IDENTITY PRIMARY KEY NOT NULL,
	Dist_Name VARCHAR(500),
	Dist_Locked BIT,
	MobileNoToNotifyViaSms VARCHAR(500),
	EmailToNotify VARCHAR(500),
	Dist_Mobile_No VARCHAR(20),	
	Dist_Email VARCHAR(50),
	Dist_Login VARCHAR(50),	
	Dist_Address VARCHAR(MAX),
	Dist_GoogleMapLocation VARCHAR(MAX),
	Dist_Fps_Code VARCHAR(50),
	Dist_Fps_Liscence_No VARCHAR(50),
	Dist_Mr_Shop_No VARCHAR(50),
	Active BIT,
	Created_Date DATETIME
)
GO

--DROP TABLE Login_His
CREATE TABLE Login_His
(
	Dist_Id INT,
	Dist_Login VARCHAR(100),
	Login_Success BIT,
	Created_Date DATETIME
)
GO
--DROP TABLE App_Start_His
CREATE TABLE App_Start_His
(	
	Internal_Ip VARCHAR(20),
	Public_Ip VARCHAR(20),
	Gateway_Addr VARCHAR(100),
	Created_Date DATETIME
)
GO

--DROP TABLE Mst_Rel
CREATE TABLE Mst_Rel
(
	Mst_Rel_Id INT IDENTITY PRIMARY KEY NOT NULL,
	Relation VARCHAR(50)
)
GO
