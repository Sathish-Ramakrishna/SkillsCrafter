
USE SkillsCrafter

--Test Data Begin
IF NOT EXISTS (SELECT 1 FROM Organizations WHERE OrgId = 1 AND OrgName = 'Smart Organization')
BEGIN
	INSERT INTO Organizations VALUES (1, 'Smart Organization');
END
--Test Data End

--Test Data Begin
IF NOT EXISTS (SELECT 1 FROM Resources WHERE Username = 'testresource1')
BEGIN
	INSERT INTO Resources (resourceId, OrgId, Username, Password, FirstName, LastName, Email, Title) VALUES (1, 1, 'testresource1', 'password','R1_FirstName', 'R1_LastName', 'nageshshugar@gmail.com', 'Dev');
END
IF NOT EXISTS (SELECT 1 FROM Resources WHERE Username = 'testresource2')
BEGIN
	INSERT INTO Resources (resourceId, OrgId, Username, Password, FirstName, LastName, Email, Title) VALUES (2, 1, 'testresource2', 'password','R2_FirstName', 'R2_LastName', 'nageshshugar@gmail.com', 'Dev');
END
IF NOT EXISTS (SELECT 1 FROM Resources WHERE Username = 'testresource3')
BEGIN
	INSERT INTO Resources (resourceId, OrgId, Username, Password, FirstName, LastName, Email, Title) VALUES (3, 1, 'testresource3', 'password','R3_FirstName', 'R3_LastName', 'nageshshugar@gmail.com', 'QA');
END
IF NOT EXISTS (SELECT 1 FROM Resources WHERE Username = 'testresource4')
BEGIN
	INSERT INTO Resources (resourceId, OrgId, Username, Password, FirstName, LastName, Email, Title) VALUES (4, 1, 'testresource4', 'password','R4_FirstName', 'R4_LastName', 'nageshshugar@gmail.com', 'QA');
END
IF NOT EXISTS (SELECT 1 FROM Resources WHERE Username = 'testmanager')
BEGIN
	INSERT INTO Resources (resourceId, OrgId, Username, Password, FirstName, LastName, Email, Title, isManager) VALUES (5, 1, 'testmanager', 'password','M_FirstName', 'M_LastName', 'nageshshugar@gmail.com', 'Manager', 1);
END
IF NOT EXISTS (SELECT 1 FROM Resources WHERE Username = 'testadmin')
BEGIN
	INSERT INTO Resources (resourceId, OrgId, Username, Password, FirstName, LastName, Email, Title, isAdmin) VALUES (6, 1, 'testadmin', 'password','A_FirstName', 'A_LastName', 'nageshshugar@gmail.com', 'Admin', 1);
END
--Test Data End

--Test Data Begin
IF NOT EXISTS (SELECT 1 FROM Portfolios WHERE Id = 1 AND OrgId = 1 AND Name = 'CRM')
BEGIN
	INSERT INTO Portfolios (Id, OrgId, Name)VALUES (1, 1, 'CRM');
END
IF NOT EXISTS (SELECT 1 FROM Portfolios WHERE Id = 2 AND OrgId = 1 AND Name = 'ERP')
BEGIN
	INSERT INTO Portfolios (Id, OrgId, Name)VALUES (2, 1, 'ERP');
END
IF NOT EXISTS (SELECT 1 FROM Portfolios WHERE Id = 3 AND OrgId = 1 AND Name = 'SCM')
BEGIN
	INSERT INTO Portfolios (Id, OrgId, Name)VALUES (3, 1, 'SCM');
END
--Test Data End

--Test Data Begin
IF NOT EXISTS (SELECT 1 FROM Products WHERE Id = 1 AND OrgId = 1 AND Name = 'CRM_Product1')
BEGIN
	INSERT INTO Products (Id, OrgId, Name, PortfolioName)VALUES (1, 1, 'CRM_Product1', 'CRM');
END
IF NOT EXISTS (SELECT 1 FROM Products WHERE Id = 2 AND OrgId = 1 AND Name = 'CRM_Product2')
BEGIN
	INSERT INTO Products (Id, OrgId, Name, PortfolioName)VALUES (2, 1, 'CRM_Product2', 'CRM');
END
IF NOT EXISTS (SELECT 1 FROM Products WHERE Id = 3 AND OrgId = 1 AND Name = 'ERP_Product1')
BEGIN
	INSERT INTO Products (Id, OrgId, Name, PortfolioName)VALUES (3, 1, 'ERP_Product1', 'ERP');
END
IF NOT EXISTS (SELECT 1 FROM Products WHERE Id = 4 AND OrgId = 1 AND Name = 'ERP_Product2')
BEGIN
	INSERT INTO Products (Id, OrgId, Name, PortfolioName)VALUES (4, 1, 'ERP_Product2', 'ERP');
END
IF NOT EXISTS (SELECT 1 FROM Products WHERE Id = 5 AND OrgId = 1 AND Name = 'SCM_Product1')
BEGIN
	INSERT INTO Products (Id, OrgId, Name, PortfolioName)VALUES (5, 1, 'SCM_Product1', 'SCM');
END
IF NOT EXISTS (SELECT 1 FROM Products WHERE Id = 6 AND OrgId = 1 AND Name = 'SCM_Product2')
BEGIN
	INSERT INTO Products (Id, OrgId, Name, PortfolioName)VALUES (6, 1, 'SCM_Product2', 'SCM');
END
--Test Data End

--Test Data Begin
IF NOT EXISTS (SELECT 1 FROM SkillsDefinitions WHERE Id = 1 AND OrgId = 1 AND Name = '.Net')
BEGIN
	INSERT INTO SkillsDefinitions (Id, OrgId, Name, SkillType)VALUES (1, 1, '.Net', 'Technical');
END
IF NOT EXISTS (SELECT 1 FROM SkillsDefinitions WHERE Id = 2 AND OrgId = 1 AND Name = 'C#')
BEGIN
	INSERT INTO SkillsDefinitions (Id, OrgId, Name, SkillType)VALUES (2, 1, 'C#', 'Technical');
END
IF NOT EXISTS (SELECT 1 FROM SkillsDefinitions WHERE Id = 3 AND OrgId = 1 AND Name = 'Incoming Inventory')
BEGIN
	INSERT INTO SkillsDefinitions (Id, OrgId, Name, SkillType)VALUES (3, 1, 'Incoming Inventory', 'Functional');
END
--Test Data End

--Test Data Begin
IF NOT EXISTS (SELECT 1 FROM SkillAssociations WHERE Id = 1 AND OrgId = 1 AND ProductName = 'CRM_Product1' AND SkillName = '.Net')
BEGIN
	INSERT INTO SkillAssociations (Id, OrgId, ProductName, SkillName, SkillType, Categoty, Role) VALUES (1, 1, 'CRM_Product1', '.Net', 'Technical', 'Core', 'Dev');
END
IF NOT EXISTS (SELECT 1 FROM SkillAssociations WHERE Id = 2 AND OrgId = 1 AND ProductName = 'CRM_Product1' AND SkillName = 'C#')
BEGIN
	INSERT INTO SkillAssociations (Id, OrgId, ProductName, SkillName, SkillType, Categoty, Role) VALUES (2, 1, 'CRM_Product1', 'C#', 'Technical', 'Optional', 'Dev');
END
IF NOT EXISTS (SELECT 1 FROM SkillAssociations WHERE Id = 3 AND OrgId = 1 AND ProductName = 'CRM_Product1' AND SkillName = 'Incoming Inventory')
BEGIN
	INSERT INTO SkillAssociations (Id, OrgId, ProductName, SkillName, SkillType, Categoty, Role) VALUES (3, 1, 'CRM_Product1', 'Incoming Inventory', 'Functional', 'Optional', 'Dev, QA, BA');
END
IF NOT EXISTS (SELECT 1 FROM SkillAssociations WHERE Id = 4 AND OrgId = 1 AND ProductName = 'CRM_Product2' AND SkillName = '.Net')
BEGIN
	INSERT INTO SkillAssociations (Id, OrgId, ProductName, SkillName, SkillType, Categoty, Role) VALUES (4, 1, 'CRM_Product2', '.Net', 'Technical', 'Core', 'Dev');
END
IF NOT EXISTS (SELECT 1 FROM SkillAssociations WHERE Id = 5 AND OrgId = 1 AND ProductName = 'CRM_Product2' AND SkillName = 'Incoming Inventory')
BEGIN
	INSERT INTO SkillAssociations (Id, OrgId, ProductName, SkillName, SkillType, Categoty, Role) VALUES (5, 1, 'CRM_Product2', 'Incoming Inventory', 'Functional', 'Optional', 'Dev, QA, BA');
END
--Test Data End

--Test Data Begin
IF NOT EXISTS (SELECT 1 FROM SkillAssesment WHERE Id = 1 AND OrgId = 1 AND ProductName = 'CRM_Product1' AND SkillName = '.Net')
BEGIN
	INSERT INTO SkillAssesment (Id, OrgId, ProductName, SkillName, SkillType, Categoty, Role, resName, resRating, ManagerName) VALUES (1, 1, 'CRM_Product1', '.Net', 'Technical', 'Core', 'Dev', 'testresource1', 2.5, 'testmanager');
END
IF NOT EXISTS (SELECT 1 FROM SkillAssesment WHERE Id = 2 AND OrgId = 1 AND ProductName = 'CRM_Product1' AND SkillName = 'C#')
BEGIN
	INSERT INTO SkillAssesment (Id, OrgId, ProductName, SkillName, SkillType, Categoty, Role, resName, resRating, ManagerName) VALUES (2, 1, 'CRM_Product1', 'C#', 'Technical', 'Optional', 'Dev', 'testresource1', 2, 'testmanager');
END
IF NOT EXISTS (SELECT 1 FROM SkillAssesment WHERE Id = 3 AND OrgId = 1 AND ProductName = 'CRM_Product1' AND SkillName = 'Incoming Inventory')
BEGIN
	INSERT INTO SkillAssesment (Id, OrgId, ProductName, SkillName, SkillType, Categoty, Role, resName, resRating, ManagerName) VALUES (3, 1, 'CRM_Product1', 'Incoming Inventory', 'Functional', 'Optional', 'Dev, QA, BA', 'testresource1', 3.2, 'testmanager');
END
IF NOT EXISTS (SELECT 1 FROM SkillAssesment WHERE Id = 4 AND OrgId = 1 AND ProductName = 'CRM_Product2' AND SkillName = '.Net')
BEGIN
	INSERT INTO SkillAssesment (Id, OrgId, ProductName, SkillName, SkillType, Categoty, Role, resName, resRating, ManagerName) VALUES (4, 1, 'CRM_Product2', '.Net', 'Technical', 'Core', 'Dev', 'testresource2', 2.2, 'testmanager');
END
IF NOT EXISTS (SELECT 1 FROM SkillAssesment WHERE Id = 5 AND OrgId = 1 AND ProductName = 'CRM_Product2' AND SkillName = 'Incoming Inventory')
BEGIN
	INSERT INTO SkillAssesment (Id, OrgId, ProductName, SkillName, SkillType, Categoty, Role, resName, resRating, ManagerName) VALUES (5, 1, 'CRM_Product2', 'Incoming Inventory', 'Functional', 'Optional', 'Dev, QA, BA', 'testresource2', 3.4, 'testmanager');
END
--Test Data End

--Test Data Begin
IF NOT EXISTS (SELECT 1 FROM KnowledgeActions WHERE Id = 1 AND OrgId = 1 AND ProductName = 'CRM_Product1' AND TrainingCourse = '.Net')
BEGIN
	INSERT INTO KnowledgeActions (Id, OrgId, ProductName, TrainingCourse, ActionType, Duration, SelfAssesment) VALUES (1, 1, 'CRM_Product1', '.Net', 'Online', '35 hours', 'Review Designs for ABC Module');
END
IF NOT EXISTS (SELECT 1 FROM KnowledgeActions WHERE Id = 2 AND OrgId = 1 AND ProductName = 'CRM_Product1' AND TrainingCourse = 'Sencha Framework')
BEGIN
	INSERT INTO KnowledgeActions (Id, OrgId, ProductName, TrainingCourse, ActionType, Duration, SelfAssesment) VALUES (2, 1, 'CRM_Product1', 'Sencha Framework', 'Workshop', '2 days', 'Protype for sales module');
END
IF NOT EXISTS (SELECT 1 FROM KnowledgeActions WHERE Id = 3 AND OrgId = 1 AND ProductName = 'CRM_Product1' AND TrainingCourse = 'Incoming Inventory')
BEGIN
	INSERT INTO KnowledgeActions (Id, OrgId, ProductName, TrainingCourse, ActionType, Duration, SelfAssesment) VALUES (3, 1, 'CRM_Product1', 'Incoming Inventory', 'On-Job Training', '1 Month', '20 Sev 3 & 4 bugs fixed');
END
IF NOT EXISTS (SELECT 1 FROM KnowledgeActions WHERE Id = 4 AND OrgId = 1 AND ProductName = 'CRM_Product2' AND TrainingCourse = '.Net')
BEGIN
	INSERT INTO KnowledgeActions (Id, OrgId, ProductName, TrainingCourse, ActionType, Duration, SelfAssesment) VALUES (4, 1, 'CRM_Product2', '.Net', 'Online', '35 hours', 'Review Designs for ABC Module');
END
IF NOT EXISTS (SELECT 1 FROM KnowledgeActions WHERE Id = 5 AND OrgId = 1 AND ProductName = 'CRM_Product2' AND TrainingCourse = 'Incoming Inventory')
BEGIN
	INSERT INTO KnowledgeActions (Id, OrgId, ProductName, TrainingCourse, ActionType, Duration, SelfAssesment) VALUES (5, 1, 'CRM_Product2', 'Incoming Inventory', 'On-Job Training', '1 Month', '20 Sev 3 & 4 bugs fixed');
END
--Test Data End
