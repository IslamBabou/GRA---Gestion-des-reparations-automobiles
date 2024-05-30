CREATE PROCEDURE [dbo].[spStock_Delete]
	@Id INT
AS
BEGIN
	DELETE FROM Stock
	WHERE [Stock].Id = @Id
END
