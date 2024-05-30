CREATE PROCEDURE [dbo].[spStock_Search]
	@SearchTerm NVARCHAR(50) 
AS
BEGIN
	SELECT Id, ItemName, Quantity, Unit, MinQty FROM Stock
	WHERE ItemName LIKE '%' + @SearchTerm + '%'
END
GO
