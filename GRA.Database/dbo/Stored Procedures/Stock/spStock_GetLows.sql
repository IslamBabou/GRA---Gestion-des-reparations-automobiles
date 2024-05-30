CREATE PROCEDURE [dbo].[spStock_GetLows]
	
AS
BEGIN
	SELECT Id, ItemName, Quantity, Unit, MinQty  FROM [Stock]
	WHERE [Stock].Quantity <= [Stock].MinQty

END
GO
