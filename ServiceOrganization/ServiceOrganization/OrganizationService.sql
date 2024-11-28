-- Создание таблицы Organizations, если она не существует
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Organizations]') AND type in (N'U'))
BEGIN
CREATE TABLE Organizations (
                               Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                               Name NVARCHAR(100) NOT NULL,
                               Address NVARCHAR(200) NOT NULL
);
END;

-- Создание таблицы Employees, если она не существует
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
BEGIN
CREATE TABLE Employees (
                           Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                           OrganizationId UNIQUEIDENTIFIER NOT NULL,
                           FirstName NVARCHAR(100) NOT NULL,
                           MiddleName NVARCHAR(100),
                           LastName NVARCHAR(100),
                           Email NVARCHAR(100) NOT NULL,
                           PhoneNumber NVARCHAR(20),
                           FOREIGN KEY (OrganizationId) REFERENCES Organizations(Id) ON DELETE CASCADE
);
END;

-- Создание таблицы Documentations, если она не существует
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Documentations]') AND type in (N'U'))
BEGIN
CREATE TABLE Documentations (
                                Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                                EmployeesId UNIQUEIDENTIFIER NOT NULL,
                                DateTime DATETIME NOT NULL,
                                FOREIGN KEY (EmployeesId) REFERENCES Employees(Id) ON DELETE CASCADE
);
END;
