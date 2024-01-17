-- Création de la table Client
CREATE TABLE Client (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nom VARCHAR(50) NOT NULL,
    Prenom VARCHAR(50),
    Adresse VARCHAR(200),
    CodePostal VARCHAR(10),
    Ville VARCHAR(50),
    Telephone VARCHAR(20)
);

-- Création de la table Commande
CREATE TABLE Commande (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ClientId INT NOT NULL,
    Date DATETIME NOT NULL,
    Total DECIMAL(10, 2) NOT NULL,
    CONSTRAINT FK_Commande_Client FOREIGN KEY (ClientId) REFERENCES Client(Id)
);
