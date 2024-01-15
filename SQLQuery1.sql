CREATE TABLE [dbo].[Etudiant] (
    [id]     INT           IDENTITY (1, 1) NOT NULL,
    [nom] VARCHAR (50)  NOT NULL,
    [prenom]    VARCHAR (50)  NOT NULL,
    [numeroClasse]  VARCHAR (255) NOT NULL,
    [dateDiplome]  DATETIME  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);