CREATE PROCEDURE [dbo].[spStock_GetAll]

AS
BEGIN
	SELECT Id, ItemName, Quantity, Unit, MinQty FROM Stock 
END;
GO