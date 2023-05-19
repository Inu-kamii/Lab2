CREATE TABLE Animals (
    AnimalId INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT,
    Weight INTEGER NOT NULL,
    Age INTEGER NOT NULL,
    Type TEXT
);

CREATE TABLE Cheeses (
    CheeseId INTEGER,
    Fatness INTEGER,
    Moisture INTEGER,
    Salt INTEGER,
    Hardness INTEGER,
    FOREIGN KEY (CheeseId) REFERENCES Products (ProductId)
);

CREATE TABLE Cows (
    CowID INTEGER,
    MuscleType TEXT,
    FOREIGN KEY (CowID) REFERENCES Animals (AnimalId)
);

CREATE TABLE Eggs (
    EggID INTEGER,
    Mass REAL,
    Size TEXT,
    FOREIGN KEY (EggID) REFERENCES Products (ProductId)
);

CREATE TABLE Milks (
    MilkId INTEGER,
    Fattness REAL NOT NULL,
    Density REAL NOT NULL,
    PurityGroup REAL NOT NULL,
    FOREIGN KEY (MilkId) REFERENCES Products (ProductId)
);

CREATE TABLE Pigs (
    PigId INTEGER,
    FatLength REAL,
    FOREIGN KEY (PigId) REFERENCES Animals (AnimalId)
);

CREATE TABLE Products (
    ProductId INTEGER PRIMARY KEY AUTOINCREMENT,
    ExpirationDate TEXT
);

CREATE TABLE Users (
    UserId INTEGER PRIMARY KEY AUTOINCREMENT,
    Login TEXT,
    Password TEXT,
    Email TEXT,
    Phone TEXT,
    Type TEXT,
    UNIQUE (Login)
);

CREATE TABLE UserAnimal (
    UserId INTEGER,
    AnimalId INTEGER,
    FOREIGN KEY (AnimalId) REFERENCES Animals (AnimalId),
    FOREIGN KEY (UserId) REFERENCES Users (UserId)
);

CREATE TABLE UserProduct (
    UserId INTEGER,
    ProductId INTEGER,
    FOREIGN KEY (ProductId) REFERENCES Products (ProductId),
    FOREIGN KEY (UserId) REFERENCES Users (UserId)
);

