CREATE PROCEDURE [dbo].[spReport_Archive]
	@Id INT
AS
BEGIN
	UPDATE Report SET IsArchive = 1
	WHERE Id = @Id
END
RETURN 0
