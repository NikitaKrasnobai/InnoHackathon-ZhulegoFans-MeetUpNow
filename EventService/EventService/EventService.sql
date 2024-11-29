-- Создание таблицы Event, если она не существует
CREATE TABLE IF NOT EXISTS Events (
                                     Id CHAR(36) PRIMARY KEY DEFAULT (UUID()),
                                     Name VARCHAR(255) NOT NULL,
                                     Description TEXT NOT NULL,
                                     Time VARCHAR(50) NULL,
                                     EmailAddress VARCHAR(255) NOT NULL
);

-- Создание таблицы Purpose, если она не существует
CREATE TABLE IF NOT EXISTS Purposes (
                                       Id CHAR(36) PRIMARY KEY DEFAULT (UUID()),
                                       Name VARCHAR(255) NOT NULL,
                                       Description TEXT NOT NULL,
                                       StartDate DATETIME NOT NULL,
                                       EndDate DATETIME NOT NULL,
                                       EventId CHAR(36) NOT NULL,
                                       FOREIGN KEY (EventId) REFERENCES Event(Id) ON DELETE CASCADE
);

-- Создание таблицы Place, если она не существует
CREATE TABLE IF NOT EXISTS Places (
                                     Id CHAR(36) PRIMARY KEY DEFAULT (UUID()),
                                     Name VARCHAR(255) NOT NULL,
                                     Address TEXT NOT NULL,
                                     EventsTableId CHAR(36) NOT NULL
);

-- Создание таблицы EventsTable, если она не существует
CREATE TABLE IF NOT EXISTS EventsTables (
                                           Id CHAR(36) PRIMARY KEY DEFAULT (UUID()),
                                           EventId CHAR(36) NOT NULL,
                                           PlaceId CHAR(36) NOT NULL,
                                           CountOfVisits INT NOT NULL,
                                           FOREIGN KEY (EventId) REFERENCES Event(Id) ON DELETE CASCADE,
                                           FOREIGN KEY (PlaceId) REFERENCES Place(Id) ON DELETE CASCADE
);