/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
if not exists (select 1 from dbo.Role)
begin
insert into dbo.Role (Name)
values ('Manager'), ('Mecanicien'), ('Client')
end

if not exists (select 1 from dbo.[User]) 
begin
--Password after decrypting = Admin@1234
INSERT [dbo].[Auth] ([Email], [PasswordHash], [PasswordSalt])
VALUES (N'admin@graservice.com', 0xD869E335B644E53F10ABBF03D0C3337000BD4D2DD55787F7A4A8C55796FAD34D, 0xE24B5344AB148AA6749523D8EFA964E6)

INSERT [dbo].[User] ([IdRole], [LastName], [FirstName], [Email], [BirthDay], [Phone], [InsuranceNumber], [CreationDate], [LastLogin], [IsDeactivated])
VALUES (1, N'Adminstrateur', N'Adminstrateur', N'admin@graservice.com', CAST(N'2024-04-28' AS Date), N'0655472483', N'40947493448324296283907684626963826037544316673997', CAST(N'2024-04-28T23:22:40.307' AS DateTime), CAST(N'2024-04-28T22:19:24.310' AS DateTime), 1)

end

