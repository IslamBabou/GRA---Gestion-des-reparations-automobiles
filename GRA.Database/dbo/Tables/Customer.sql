CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [CompanyName] NVARCHAR(50) NOT NULL,
    [InsuranceNumber] NVARCHAR(50) NULL,
    [NIN] NVARCHAR(50) NULL,
    [Email] NVARCHAR(100) NOT NULL, 
    [Phone] NVARCHAR(20) NULL, 
    [Address] NVARCHAR(200) NULL, 
    [ZipCode] NVARCHAR(10) NULL, 
    [City] NVARCHAR(50) NULL   

)
