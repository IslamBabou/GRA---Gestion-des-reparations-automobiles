CREATE PROCEDURE [dbo].[spReport_SearchByCustomerId]
    	@Id INT
AS
BEGIN
	SELECT * FROM Report 
	WHERE CustomerId = @Id
END
