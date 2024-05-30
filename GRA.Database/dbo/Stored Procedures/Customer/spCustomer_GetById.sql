CREATE PROCEDURE [dbo].[spCustomer_GetByID]
	@Id INT

	AS
	BEGIN
		SELECT Id, LastName, FirstName, CompanyName, NIN, Email, Phone, Address, ZipCode, City  FROM [Customer] 
		WHERE [Customer].Id = @Id;
	END;
GO