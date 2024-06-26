﻿CREATE PROCEDURE [dbo].[spReport_SearchAllNonArchivedDashboard]

AS
BEGIN
	SELECT r.Id, r.EndDate, c.FirstName, c.LastName, v.NumberPlate, u.FirstName + ' ' + u.LastName, v.Brand, v.Model, v.Year
	FROM Report r
	INNER JOIN Customer c ON r.CustomerId = c.Id
	INNER JOIN Vehicle v ON r.VehicleId = v.Id 
	INNER JOIN [User] u ON r.UserId = u.Id
	WHERE r.IsArchive = 0
	ORDER BY r.EndDate ASC
END
RETURN 0
