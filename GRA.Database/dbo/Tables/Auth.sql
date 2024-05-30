CREATE TABLE [dbo].[Auth]
(
	[Email] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [PasswordHash] VARBINARY(MAX) NULL, 
    [PasswordSalt] VARBINARY(MAX) NULL
)
