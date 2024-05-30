CREATE PROCEDURE [dbo].[spCustomer_Upsert]
	@Id INT = NULL,
    @LastName NVARCHAR(50), 
    @FirstName NVARCHAR(50), 
    @CompanyName NVARCHAR(100),  
    @InsuranceNumber NVARCHAR(50),
    @NIN NVARCHAR(50), 
    @Email NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Address NVARCHAR(200),
    @ZipCode NVARCHAR(50), 
    @City NVARCHAR(50)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM [Customer] WHERE Id = @Id)
            BEGIN
                INSERT INTO [Customer](
                    LastName, 
                    FirstName, 
                    CompanyName,
                    InsuranceNumber,
                    NIN,
                    Email, 
                    Phone, 
                    Address,
                    ZipCode,
                    City
                ) VALUES (
                   @LastName, 
                   @FirstName, 
                   @CompanyName,
                   @InsuranceNumber,
                   @NIN,
                   @Email, 
                   @Phone, 
                   @Address,
                   @ZipCode,
                   @City
                )
            END
    ELSE 
        BEGIN
            UPDATE [Customer] 
                SET         LastName=@LastName ,
                            FirstName=@FirstName ,
                            CompanyName=@CompanyName,
                            InsuranceNumber=@InsuranceNumber,
                            NIN=@NIN,
                            Phone=@Phone,
                            Address=@Address,
                            ZipCode=@ZipCode,
                            City=@City
           WHERE Id=@Id
        END
END;
GO
