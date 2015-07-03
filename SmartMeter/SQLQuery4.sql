ALTER PROC dbo.usp_GetConsumption
(
	@Month			INT = 0 ,
	@StartDate		VARCHAR(9) = '',
	@EndDate		VARCHAR(9) = '',
	@MeterID		VARCHAR(MAX) = ''
)
AS 
BEGIN
	WITH CTE_Usage AS
	(
		SELECT MeterID, 		
		CONVERT(VARCHAR(8),CONVERT( VARCHAR(30), StartTime ,105),10) AS StartDate,
		StartReading, 
		CONVERT(VARCHAR(8),CONVERT( VARCHAR(30), EndTime ,105),10) AS EndDate,
		EndReading,(EndReading-StartReading) AS DailyUsage
		FROM Usage
	) 
	SELECT CTE_Usage.MeterID, 
	SUM(DailyUsage) AS Consumption,	C.Name, C.Address, C.PinCode, C.CustomerID 
	FROM 
	CTE_Usage 
	INNER JOIN Customer C ON C.MeterID = CTE_Usage.MeterID
	GROUP BY CTE_Usage.MeterID, C.Name, C.Address, C.PinCode, C.CustomerID
END