INSERT INTO Mst_Cat
(
	Cat_Desc
)
VALUES
('AAY'),
('PHH'),
('RKSY-I'),
('RKSY-II'),
('SPHH')

GO

INSERT INTO Mst_Dist
(
	Dist_Name,
	Dist_Locked,
	MobileNoToNotifyViaSms,
	EmailToNotify,
	Dist_Mobile_No,	
	Dist_Email,
	Dist_Login,
	Dist_Address,
	Dist_GoogleMapLocation,
	Dist_Fps_Code,
	Dist_Fps_Liscence_No,
	Dist_Mr_Shop_No,
	Active,
	Created_Date
)
VALUES
('Jayanta Ghosh', 0, '8777757781', 'jayanta98314@gmail.com', '9831461743', 'jayanta98314@gmail.com', 'jayanta98314@gmail.com', '27, RNC Road(West), Subhasgram,Kolkara 700147', 'https://goo.gl/maps/rRzGuHyNjUJm99CZ7', '134301100020', '24 P(S)- BRP-RPSP-134301100020', '11', 1, GETDATE()),
('Arindam Dey', 0, '9830609366', 'biplabhome@gmail.com', '9830609366', 'biplabhome@gmail.com', 'biplabhome@gmail.com', '102, Gandi Para Road East, Subhasgram,Kolkara 700147', 'https://goo.gl/maps/WeDABAb4BYSEk1mj9', 'admin', 'admin', 'admin', 1, GETDATE())

GO

INSERT INTO Mst_Role
(
	Dist_Id,
	Role_Desc,
	ControlIdToHide
)
VALUES
(1,'Normal Distributor', 'btnAdmin'),
(2,'Admin', '')

GO

--Truncate table Mst_Rel
INSERT INTO Mst_Rel
(
	Relation
)
VALUES
('Self'),
('Father'),
('Mother'),
('Wife'),
('Brother'),
('Daughter'),
('Son'),
('Daughter In Law'),
('Sister In Law'),
('Father In Law'),
('Mother in Law'),
('Brother In Law'),
('Brother'),
('Nice'),
('Elder Sister'),
('Uncle'),
('Aunt'),
('Husband'),
('Other'),
('Granddaughter'),
('Grandson'),
('NA'),
('Elder Sister Daughter'),
('SonInLow'),
('Granddaughter in law'),
('Grandson in law'),
('Nephew'),
('Elder sister''s daughter'),
('Elder sister''s Sons'),
('Nephew Wife''s'),
('Brother''s daughter'),
('Brother''s son'),
('Grandchild'),
('Grandmother'),
('Sister'),
('self'),
('Grandfather'),
('Elder Brother'),
('Elder Sister inlaw'),
('Grand daughter'),
('husband'),
('Wife''s sister'),
('Brother wife'),
(''),
('sister daughter'),
('husband brother'),
('uncle DAUGHTER'),
('wife mother')
GO