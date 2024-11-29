-- Создание таблицы Organizations, если она не существует
CREATE TABLE IF NOT EXISTS Organizations (
                                             Id CHAR(36) PRIMARY KEY DEFAULT (UUID()),
                                             Name VARCHAR(100) NOT NULL,
                                             Address VARCHAR(200) NOT NULL
);

-- Создание таблицы Employees, если она не существует
CREATE TABLE IF NOT EXISTS Employees (
                                         Id CHAR(36) PRIMARY KEY DEFAULT (UUID()),
                                         OrganizationId CHAR(36) NOT NULL,
                                         FirstName VARCHAR(100) NOT NULL,
                                         MiddleName VARCHAR(100),
                                         LastName VARCHAR(100),
                                         Email VARCHAR(100) NOT NULL,
                                         PhoneNumber VARCHAR(20),
                                         FOREIGN KEY (OrganizationId) REFERENCES Organizations(Id) ON DELETE CASCADE
);

-- Создание таблицы Documentations, если она не существует
CREATE TABLE IF NOT EXISTS Documentations (
                                              Id CHAR(36) PRIMARY KEY DEFAULT (UUID()),
                                              EmployeesId CHAR(36) NOT NULL,
                                              DateTime DATETIME NOT NULL,
                                              FOREIGN KEY (EmployeesId) REFERENCES Employees(Id) ON DELETE CASCADE
);
