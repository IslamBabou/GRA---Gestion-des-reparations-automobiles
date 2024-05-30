CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdRole] INT NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(100) NOT NULL, 
    [BirthDay] DATE NOT NULL, 
    [Phone] NVARCHAR(50) NULL,
    [CreationDate] DATETIME NOT NULL DEFAULT GETDATE(), 
    [LastLogin] DATETIME NULL, 
    [IsDeactivated] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([IdRole]) REFERENCES [Role]([Id]) 
     
)
