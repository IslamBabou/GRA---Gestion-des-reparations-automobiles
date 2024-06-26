﻿CREATE TABLE [dbo].[Report]
(
    [Id] [int] PRIMARY KEY IDENTITY NOT NULL,
    [IsArchive] [bit] NOT NULL DEFAULT 0,
    [StartDate] [datetime] NOT NULL,
    [EndDate] [datetime] NOT NULL,
    [VehicleId] [int] NOT NULL,
    [UserId] [int] NOT NULL,
    [AppointmentId] [int] NOT NULL,
    [CustomerId] [int] NOT NULL,
    [Date] [datetime] NOT NULL,
    [Odometer] [int] NOT NULL,
    [RoadTestComments] [nvarchar](max) NULL,
    [GeneralComments] [nvarchar](max) NULL,
    [StoredFaultCodes] [nvarchar](max) NULL,
    [AirConditioning] [nvarchar](max) NULL,
    [Optics] [nvarchar](50) NULL,
    [Lights] [nvarchar](max) NULL,
    [LightsComments] [nvarchar](max) NULL,
    [FrontWiper] [nvarchar](50) NULL,
    [BackWiper] [nvarchar](50) NULL,
    [Battery] [nvarchar](50) NULL,
    [BatteryComments] [nvarchar](50) NULL,
    [RHFTyre] [nvarchar](50) NULL,
    [LHFTyre] [nvarchar](50) NULL,
    [RHRTyre] [nvarchar](50) NULL,
    [LHRTyre] [nvarchar](50) NULL,
    [TyresComments] [nvarchar](max) NULL,
    [IsNeedAlignment] [bit] NOT NULL DEFAULT 0,
    [AirFilter] [nvarchar](50) NULL,
    [CabinFilter] [nvarchar](50) NULL,
    [DriveBelts] [nvarchar](50) NULL,
    [TimingBelts] [nvarchar](50) NULL,
    [Radiator] [nvarchar](50) NULL,
    [Hoses] [nvarchar](50) NULL,
    [HosesComment] [nvarchar](max) NULL,
    [EngineOil] [nvarchar](50) NULL,
    [Coolant] [nvarchar](50) NULL,
    [BrakeFluid] [nvarchar](50) NULL,
    [PowerSteeringFluid] [nvarchar](50) NULL,
    [TransmissionFluid] [nvarchar](50) NULL,
    [WindScreenWasherFluid] [nvarchar](50) NULL,
    [FluidComments] [nvarchar](max) NULL,
    [SparkPlugs] [nvarchar](50) NULL,
    [FuelFilter] [nvarchar](50) NULL,
    [FrontSuspension] [nvarchar](50) NULL,
    [FrontSuspensionComments] [nvarchar](max) NULL,
    [RearSuspension] [nvarchar](50) NULL,
    [RearSuspensionComments] [nvarchar](max) NULL,
    [FrontBrakes] [nvarchar](50) NULL,
    [FrontBrakesComments] [nvarchar](max) NULL,
    [RearBrakes] [nvarchar](50) NULL,
    [RearBrakesComments] [nvarchar](max) NULL,
    [Exhaust] [nvarchar](50) NULL,
    [ExhaustComments] [nvarchar](max) NULL,
    [OilLeaks] [nvarchar](50) NULL,
    [OilLeaksComments] [nvarchar](max) NULL,
    [CoolantLeaks] [nvarchar](50) NULL,
    [CoolantLeaksComments] [nvarchar](max) NULL,
    [Other] [nvarchar](max) NULL,
    [OtherInspectionComments] [nvarchar](max) NULL, 
    CONSTRAINT [FK_Report_Vehicle] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicle]([Id]),
    CONSTRAINT [FK_Rapport_User] FOREIGN KEY([UserId]) REFERENCES [User] ([Id]),
    CONSTRAINT [FK_Rapport_Customer] FOREIGN KEY([CustomerId]) REFERENCES [Customer] ([Id]),
    CONSTRAINT [FK_Rapport_Appointment] FOREIGN KEY([AppointmentId]) REFERENCES [Appointment] ([Id])
 
 
)