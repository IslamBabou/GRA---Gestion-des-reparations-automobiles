CREATE PROCEDURE [dbo].[spUser_Upsert]
	@Id INT = NULL,
    @IdRole INT,
    @LastName NVARCHAR(50), 
    @FirstName NVARCHAR(50), 
    @Email NVARCHAR(100),  
    @BirthDay DATE, 
    @Phone NVARCHAR(50),
    @LastLogin DATETIME = NULL, 
    @IsDeactivated BIT 
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM [User] WHERE Id = @Id)
        BEGIN
        IF NOT EXISTS (SELECT * FROM [User] WHERE Email = @Email)
            BEGIN
                INSERT INTO [User](
                    IdRole,
                    LastName, 
                    FirstName, 
                    Email, 
                    BirthDay,
                    Phone, 
                    LastLogin,
                    IsDeactivated
                ) VALUES (
                    @IdRole,
                    @LastName, 
                    @FirstName,
                    @Email,
                    @BirthDay,
                    @Phone,
                    @LastLogin,
                    @IsDeactivated
                )
            END
        END
    ELSE 
        BEGIN
            UPDATE [User] 
                SET IdRole=@IdRole,
                    LastName=@LastName, 
                    FirstName=@FirstName, 
                    Email=@Email, 
                    BirthDay=@BirthDay,
                    Phone=@Phone, 
                    LastLogin=@LastLogin,
                    IsDeactivated=@IsDeactivated
                WHERE Id = @Id
        END
END;
GO
