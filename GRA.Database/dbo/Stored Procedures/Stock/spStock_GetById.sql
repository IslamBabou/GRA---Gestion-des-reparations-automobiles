CREATE PROCEDURE [dbo].[spStock_GetById]
	@Id INT
AS
BEGIN
	SELECT Id, ItemName, Quantity, Unit, MinQty FROM Stock
	WHERE Id = @Id
END;
GO