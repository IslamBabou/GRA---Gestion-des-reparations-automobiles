CREATE PROCEDURE [dbo].[spCustomer_GetAll]

	AS
	BEGIN
		SELECT Id, LastName, FirstName, CompanyName, NIN, Email, Phone, Address, ZipCode, City 
		FROM Customer
	END;
GO