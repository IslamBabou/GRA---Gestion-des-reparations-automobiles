CREATE TABLE [dbo].[Appointment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT NOT NULL, 
    [VehicleId] INT NOT NULL, 
    [DateAppointment] DATE NOT NULL, 
    [UserId] INT NULL, 
    [IsCompleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Appointment_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]), 
    CONSTRAINT [FK_Appointment_Vehicle] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicle]([Id]), 
    CONSTRAINT [FK_AppointmentUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),

)
