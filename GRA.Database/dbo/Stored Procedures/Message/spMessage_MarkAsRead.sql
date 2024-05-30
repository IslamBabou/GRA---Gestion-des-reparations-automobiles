CREATE PROCEDURE [dbo].[spMessage_MarkAsRead]
	@Id INT
AS
BEGIN
	UPDATE [Message]
	SET	IsRead = 1
	WHERE Id = @Id
END
RETURN 0
