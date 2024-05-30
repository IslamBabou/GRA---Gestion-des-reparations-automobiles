CREATE PROCEDURE [dbo].[spMessage_Create]
	@Id INT = NULL,
	@UserName NVARCHAR(20),
	@Content NVARCHAR(MAX),
	@PublicationDate DATETIME,
	@IsRead bit = 0,
	@Tag NVARCHAR(20)

AS
BEGIN
	INSERT INTO [Message](
				UserName,
				Content,
				PublicationDate,
				IsRead,
				Tag)
		VALUES(
				@UserName,
				@Content,
				@PublicationDate,
				@IsRead,
				@Tag)
END
GO