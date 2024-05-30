CREATE PROCEDURE [dbo].[spCustomer_Delete]
	@Id INT
AS
BEGIN

    DELETE FROM Customer
    WHERE [Customer].Id = @Id
END;
GO




