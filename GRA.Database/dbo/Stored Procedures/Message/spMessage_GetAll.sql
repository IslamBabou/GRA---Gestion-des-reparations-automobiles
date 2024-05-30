CREATE PROCEDURE [dbo].[spMessage_GetAll]
	
AS
BEGIN
	SELECT Id, UserName, Content, PublicationDate, IsRead, Tag FROM Message
	WHERE IsRead = 0
	ORDER BY PublicationDate DESC;
END
RETURN 0
