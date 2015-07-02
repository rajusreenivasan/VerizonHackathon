SELECT * FROM Tariff
SELECT * FROM Customer
select * from Usage
--truncate table Customer

select distinct meterid from Usage where meterid not in (select MeterID from Customer)

[usp_GetConsumption]

INSERT INTO Customer(MeterID,[Name],[Address],PinCode,[Status])
select distinct meterid,'New','New',600678,1 from Usage where meterid not in (select MeterID from Customer)


DECLARE @MeterID INT
SET @MeterID = 12345678
DECLARE @index	INT
SET @index = 1
WHILE(@index <= 100)
BEGIN
	INSERT INTO Customer(MeterID, [Name],Address,PinCode,Status)
	SELECT @MeterID,
	'Name = A ' + CAST(@index AS VARCHAR(50)) AS [Name],
	'Address = A ' + CAST(@index AS VARCHAR(50)) AS Address,
	60041 AS PinCode, 1 AS Status
SET @MeterID = @MeterID + 1
SET @index = @index + 1
END

