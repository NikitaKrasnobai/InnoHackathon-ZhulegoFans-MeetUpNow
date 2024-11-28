IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Event')
BEGIN
    CREATE TABLE Event (
        Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
        Name NVARCHAR(255) NOT NULL,
        Description NVARCHAR(MAX) NOT NULL,
        Time NVARCHAR(50) NULL
    );
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Purpose')
BEGIN
    CREATE TABLE Purpose (
        Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
        Name NVARCHAR(255) NOT NULL,
        Description NVARCHAR(MAX) NOT NULL,
        StartDate DATETIME NOT NULL,
        EndDate DATETIME NOT NULL,
        EventId UNIQUEIDENTIFIER NOT NULL
    );
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Place')
BEGIN
    CREATE TABLE Place (
        Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
        Name NVARCHAR(255) NOT NULL,
        Address NVARCHAR(MAX) NOT NULL,
        EventsTableId UNIQUEIDENTIFIER NOT NULL
    );
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EventsTable')
BEGIN
    CREATE TABLE EventsTable (
        Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
        EventId UNIQUEIDENTIFIER NOT NULL,
        PlaceId UNIQUEIDENTIFIER NOT NULL,
        CountOfVisits INT NOT NULL
    );
END