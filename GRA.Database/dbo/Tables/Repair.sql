CREATE TABLE [dbo].[Repair]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Code] NVARCHAR(10) NOT NULL, 
    [VehicleId] INT NOT NULL, 
    [DateOpening] DATETIME NOT NULL, 
    [DateClosing] DATETIME NOT NULL, 
    [Status] INT NOT NULL, 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [UpdatedBy] NVARCHAR(50) NOT NULL, 
    [Total] DECIMAL(10, 2) NOT NULL DEFAULT 0, 
    [Paid] DECIMAL(10, 2) NOT NULL DEFAULT 0, 
    [PaymentStatus] INT NOT NULL, 

    CONSTRAINT [FK_Repair_Vehicle] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicle]([Id])
)
