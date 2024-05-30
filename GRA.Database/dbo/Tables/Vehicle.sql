CREATE TABLE [dbo].[Vehicle]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [CustomerId]INT NOT NULL, 
    [NumberPlate] NVARCHAR(10) NOT NULL, 
    [Brand] NVARCHAR(50) NOT NULL, 
    [Model] NVARCHAR(50) NOT NULL, 
    [Year] CHAR(4) NOT NULL, 
    [ChassisNumber] NVARCHAR(17) NOT NULL, 
    [FuelType] NVARCHAR(15) NOT NULL, 
    [TransmissionType] NVARCHAR(10) NOT NULL,
    [EngineDescription] NVARCHAR(MAX) NOT NULL, 
    [Cylinder] NVARCHAR(6) NOT NULL, 
    [BodyType] NVARCHAR(50) NOT NULL, 
    [SizeLitre] DECIMAL(4, 2) NOT NULL, 
    [FirstVisit] DATETIME NULL, 
    CONSTRAINT [FK_Vehicle_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id])
)
