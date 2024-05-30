﻿CREATE PROCEDURE [dbo].[spReport_SearchAllDashboard]
	
AS
BEGIN
	SELECT r.Id, r.EndDate, c.FirstName, c.LastName, v.NumberPlate, u.FirstName + ' ' + u.LastName, v.Brand, v.Model, v.Year
	FROM Report r
	INNER JOIN Customer c ON r.CustomerId = c.Id
	INNER JOIN Vehicle v ON r.VehicleId = v.Id 
	INNER JOIN [User] u ON r.UserId = u.Id
	ORDER BY r.EndDate DESC
END
RETURN 0
