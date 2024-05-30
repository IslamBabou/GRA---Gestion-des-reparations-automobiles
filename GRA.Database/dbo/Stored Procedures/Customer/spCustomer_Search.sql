CREATE PROCEDURE [dbo].[spCustomer_Search]
	@SearchTerm NVARCHAR(20)
AS
BEGIN
	
	SELECT Id, LastName, FirstName, CompanyName, NIN, Email, Phone, Address, ZipCode, City FROM Customer
	WHERE FirstName LIKE '%' + @SearchTerm + '%'
	OR LastName LIKE '%' + @SearchTerm + '%'
	OR CompanyName LIKE '%' + @SearchTerm + '%'
	OR Phone LIKE '%' + @SearchTerm + '%'
END

RETURN 0
