USE ConsumptionValidator
-- SELECT * FROM dbo.ContractBands 
-- SELECT * FROM DistributionLosses 
-- WHERE MarketParticipantId = 'TEST'
-- SELECT * FROM dbo.IDNOs;

-- SELECT * FROM dbo.IDNOs
-- WHERE Area = 'GTC';

-- SELECT * FROM dbo.IDNOs
-- WHERE MarketParticipantId IN ('IPNL');

-- SELECT * FROM dbo.ContractBands;

-- SELECT * FROM dbo.DistributionLosses
-- WHERE MarketParticipantId = 'LOND'
-- AND LLF = '807'
-- AND Date = CONVERT(datetime, '01/06/2016 00:00:00', 103);

-- SELECT * FROM dbo.DuosTariffs 
-- WHERE MarketParticipantId = 'LOND'
-- AND '2012-01-01 00:00:00' BETWEEN StartDate AND EndDate 

-- DELETE FROM dbo.DistributionLosses
-- WHERE MarketParticipantId = 'LOND';

-- USE ConsumptionValidator
-- SELECT * FROM dbo.ProfileRows 
-- WHERE Mpan = '001112229912345678345'
-- AND Date = '2012-02-01'

-- SELECT * FROM dbo.DuosTariffs
-- WHERE Date = '2012-02-01'

-- SELECT * FROM dbo.ContractBands 
-- WHERE Mpan = '001112229912345678345'
-- AND Customer = 'Test Customer' 
-- AND Date = '2012-02-01';

-- SELECT * FROM dbo.TuosCharges

-- INSERT INTO EnergyBuyer.dbo.SuperTable 
--     ( Area ) 
-- VALUES  
--     ('Test Area');

-- USE EnergyBuyer
-- SELECT * FROM SuperTable;
-- DROP TABLE EnergyBuyer.dbo.SuperTable ;



-- SELECT * FROM dbo.TotalledEnergy 
-- WHERE Mpan = '001112229912345678345';

-- SELECT * FROM dbo.TotalledEnergy 
-- WHERE SupplyPointRef = '9912345678345'
-- AND Date BETWEEN '2012-02-01' AND '2012-02-02';


SELECT * FROM dbo.TotalledDuos

-- '001112229912345678345', 
-- '9912345678345', 