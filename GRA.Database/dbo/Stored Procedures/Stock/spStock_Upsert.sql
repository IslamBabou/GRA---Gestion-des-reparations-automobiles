CREATE PROCEDURE [dbo].[spStock_Upsert]
    @Id INT = NULL,
	@ItemName NVARCHAR(100),
	@Quantity DECIMAL(5,2),
	@Unit NVARCHAR(15),
	@MinQty DECIMAL(5,2)

AS
BEGIN
        IF NOT EXISTS (SELECT * FROM [Stock] WHERE Id = @Id)
            BEGIN
                INSERT INTO [Stock](
                     ItemName,
                     Quantity,
                     Unit,
                     MinQty
                ) VALUES (
                    @ItemName,
                    @Quantity,
                    @Unit,
                    @MinQty
                )
            END
    ELSE 
        BEGIN
            UPDATE [Stock] 
                SET 
                     Quantity = @Quantity,
                     Unit = @Unit,
                     MinQty = @MinQty
                WHERE Id = @Id;
        END
END;
GO
	
