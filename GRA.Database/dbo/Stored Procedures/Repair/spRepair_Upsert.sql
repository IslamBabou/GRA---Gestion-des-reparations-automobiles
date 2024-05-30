CREATE PROCEDURE [dbo].[spRepair_Upsert]
	@Id  INT = NULL,
	@Code  NVARCHAR(10),
	@VehicleId INT,
	@DateOpening DATETIME,
	@DateClosing DATETIME,
	@Status INT,
	@CreatedBy NVARCHAR(50),
	@UpdatedBy NVARCHAR(50),
	@Total DECIMAL(10, 2),
	@Paid DECIMAL(10, 2),
	@PaiemntStatus NVARCHAR(150)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Repair WHERE Id = @Id)
		BEGIN
			INSERT INTO Repair(
				
				Code,
				VehicleId,
				DateOpening,
				DateClosing,
				Status,
				CreatedBy,
				UpdatedBy,
				Total,
				Paid,
				PaiementStatus
				) 
				VALUES (
				
				@Code,
				@VehicleId,
				@DateOpening,
				@DateClosing,
				@Status,
				@CreatedBy,
				@UpdatedBy,
				@Total,
				@Paid,
				@PaiemntStatus)
		END		
	ELSE
	BEGIN
		UPDATE Repair SET 
							Code = @Code,
							VehicleId = @VehicleId,
							DateOpening = @DateOpening,
							DateClosing = @DateClosing,
							Status = @Status,
							CreatedBy = @CreatedBy,
							UpdatedBy = @UpdatedBy,
							Total = @Total,
							Paid = @Paid,
							PaiementStatus = @PaiemntStatus
							WHERE Id = @Id 
	END

END