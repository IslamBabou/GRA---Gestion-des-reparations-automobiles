CREATE PROCEDURE [dbo].[spVehicle_Upsert]
	@Id INT = NULL,
    @CustomerId INT, 
    @NumberPlate NVARCHAR(10), 
    @Brand NVARCHAR(50),  
    @Model NVARCHAR(50), 
    @Year CHAR(4),
    @ChassisNumber NVARCHAR(17),
    @FuelType NVARCHAR(15),
    @TransmissionType NVARCHAR(10),
    @EngineDescription NVARCHAR(MAX), 
    @Cylinder NVARCHAR(6), 
    @BodyType NVARCHAR(50), 
    @SizeLitre DECIMAL(4, 2), 
    @FirstVisit DATETIME 
AS
BEGIN
        IF NOT EXISTS (SELECT * FROM [Vehicle] WHERE NumberPlate = @NumberPlate)
            BEGIN
                INSERT INTO [Vehicle](
                     CustomerId, 
                     NumberPlate, 
                     Brand,  
                     Model, 
                     Year,
                     ChassisNumber,
                     FuelType,
                     TransmissionType,
                     EngineDescription, 
                     Cylinder, 
                     BodyType, 
                     SizeLitre, 
                     FirstVisit 
                ) VALUES (
                    @CustomerId, 
                    @NumberPlate, 
                    @Brand,  
                    @Model, 
                    @Year,
                    @ChassisNumber,
                    @FuelType,
                    @TransmissionType,
                    @EngineDescription, 
                    @Cylinder, 
                    @BodyType, 
                    @SizeLitre, 
                    @FirstVisit 
                )
            END
    ELSE 
        BEGIN
            UPDATE [Vehicle] 
                SET 
                     CustomerId = @CustomerId,
                     NumberPlate = @NumberPlate,
                     Brand = @Brand,
                     Model = @Model,
                     Year = @Year,
                     ChassisNumber = @ChassisNumber,
                     FuelType= @FuelType,
                     TransmissionType = @TransmissionType,
                     EngineDescription = @EngineDescription, 
                     Cylinder = @Cylinder,
                     BodyType = @BodyType,
                     SizeLitre = @SizeLitre,
                     FirstVisit = @FirstVisit
                WHERE Id = @Id;
        END
END;
GO
