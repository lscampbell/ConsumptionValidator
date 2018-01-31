USE ConsumptionValidator
DROP TABLE dbo.TuosCharges
INSERT INTO dbo.TuosCharges
    (
        MarketParticipantId,
        StartDate,
        EndDate, 
        Charge
    )
VALUES
    ('TEST', CONVERT(datetime, '01/04/2011 00:00:00', 103), CONVERT(datetime, '31/03/2012 00:00:00', 103), 29.89186600),
    ('TEST', CONVERT(datetime, '01/04/2013 00:00:00', 103), CONVERT(datetime, '31/03/2014 00:00:00', 103), 29.89186600),
    ('TEST', CONVERT(datetime, '01/04/2014 00:00:00', 103), CONVERT(datetime, '31/03/2015 00:00:00', 103), 34.63000000),
    ('TEST', CONVERT(datetime, '01/04/2015 00:00:00', 103), CONVERT(datetime, '31/03/2016 00:00:00', 103), 41.17642700),
    ('TEST', CONVERT(datetime, '01/04/2016 00:00:00', 103), CONVERT(datetime, '31/03/2017 00:00:00', 103), 46.54311300);

INSERT INTO dbo.DNOs 
    (
        AreaId, 
        Area,
        Operator,
        MarketParticipantId,
        GSPGroupId
    ) 
VALUES 
    (10, 'Eastern England', 'UK Power Networks', 'EELC', '_A'),
    (11, 'East Midlands', 'Western Power Distribution', 'EMEB', '_B'),
    (12, 'London', 'UK Power Networks', 'LOND', '_C'),
    (13, 'Merseyside and Northern Wales', 'ScottishPower', 'MANW', '_D'),
    (14, 'West Midlands', 'Western Power Distribution', 'MIDE', '_E'),
    (15, 'North Eastern England', 'Northern Powergrid', 'NEEB', '_F'),
    (16, 'North Western England', 'Electricity North West', 'NORW', '_G'),
    (17, 'Northern Scotland', 'SSE Power Distribution', 'HYDE', '_P'),
    (18, 'Southern Scotland', 'ScottishPower', 'SPOW', '_N'),
    (19, 'South Eastern England', 'UK Power Networks', 'SEEB', '_J'),
    (20, 'Southern England', 'SSE Power Distribution', 'SOUT', '_H'),
    (21, 'Southern Wales', 'Western Power Distribution', 'SWAE', '_K'),
    (22, 'South Western England', 'Western Power Distribution', 'SWEB', '_L'),
    (23, 'Yorkshire', 'Northern Powergrid', 'YELG', '_M');
    
INSERT INTO dbo.DNOs 
    (
        AreaId, 
        Area,
        Operator,
        MarketParticipantId,
        GSPGroupId
    ) 
VALUES  
    (99, 'Test Area', 'Test Networks', 'TEST', '_Z');

SELECT * FROM DNOs;
SELECT * FROM DNOs WHERE AreaId = 10;

USE ConsumptionValidator
SELECT * FROM DNOs WHERE AreaId = 10;

INSERT INTO dbo.IDNOs 
    (
        AreaId, 
        Area,
        Licensee,
        MarketParticipantId
    ) 
VALUES 
    (24, 'GTC', 'Independent Power Networks', 'IPNL'),
    (25, 'ESP Electricity', 'ESP Electricity', 'LENG'),
    (26, 'Energetics', 'Global Utilities Connections (Electric) Ltd', 'GUCL'),
    (27, 'GTC', 'The Electricity Network Company Ltd', 'ETCL'),
    (28, 'EDF IDNO', 'UK Power Networks (IDNO) Ltd', 'EDFI'),
    (29, '', 'Harlaxton Energy Networks Ltd', 'HARL'),
    (30, '', 'Peel Electricity Networks Ltd', 'PENL'),
    (31, '', 'UK Power Distributions Ltd', 'UKPD'),
    (32, 'UDN', 'Utility Distribution Networks Ltd', 'UDNL');

SELECT * FROM IDNOs;

USE ConsumptionValidator

INSERT INTO dbo.MTCs
    (
        MeterTimeSwitchClassId,
        ClassDescription
    ) 
VALUES
    ('001 - 399', 'DNO specific'),
    ('400 - 499', 'Reserved'),
    ('500 - 509', 'Codes for related Metering Systems - common across the Industry'),
    ('510 - 799', 'Codes for related Metering Systems - DNO specific'),
    ('800 - 999', 'Codes common across the Industry');

SELECT * FROM MTCs;

USE ConsumptionValidator

INSERT INTO dbo.PCs
    (
        ProfileId,
        ClassDescription
    ) 
VALUES
    ('00', 'Half-hourly supply (import and export)'),
    ('01', 'Domestic Unrestricted'),
    ('02', 'Domestic Economy Meter of 2 or more rates'),
    ('03', 'Non-Domestic Unrestricted'),
    ('04', 'Non-Domestic Economy 7'),
    ('05', 'Non-domestic, with MD recording capability and with LF less than or equal to 20%'),
    ('06', 'Non-domestic, with MD recording capability and with LF less than or equal to 30% and greater than 20%'),
    ('07', 'Non-domestic, with MD recording capability and with LF less than or equal to 40% and greater than 30%'),
    ('08', 'Non-domestic, with MD recording capability and with LF greater than 40% (also all NHH export MSIDs)');

SELECT * FROM PCs;

USE ConsumptionValidator
TRUNCATE TABLE dbo.SupplyPoint

INSERT INTO dbo.SupplyPoint
    (
        Mpan,
        SupplyPointRef,
        SiteId,
        SiteName,
        AccountId,
        SupplierId,
        SupplierName,
        MarketParticipantId,
        MeterSerialNumber
    )
VALUES
    (
        '001112221212345678345',
        '9912345678345',
        '0001',
        'Test Site',
        '00000000001',
        '10000',
        'Test Supplier',
        'TEST',
        'AB12345678'
    );


SELECT * FROM SupplyPoint;

USE ConsumptionValidator

TRUNCATE TABLE MPANs
INSERT INTO MPANs 
    (
        Mpan,
        SupplyPointRef,
        ProfileType,
        MeterTimeSwitchCode,
        LLF,
        DistributionId,
        UniqueIdentifer,
        CheckDigit
    ) 
VALUES
    (
        '001112229912345678345',
        '9912345678345',
        '00',
        '111',
        '222',
        '99',
        '12345678',
        '345'
    );

SELECT * FROM MPANs;

USE ConsumptionValidator

TRUNCATE TABLE dbo.Customer
INSERT INTO Customer
    (
        Mpan,
        SupplyPointRef,
        Customer
    )
VALUES
    (
        '001112229912345678345',
        '9912345678345',
        'Test Customer'
    );

SELECT * FROM Customer;

USE ConsumptionValidator

TRUNCATE TABLE dbo.SupplyCapacity
INSERT INTO SupplyCapacity
    (
        Mpan,
        SupplyPointRef, 
        EffectiveDate,
        AvailableCapacity  
    )
VALUES
    (
        '001112229912345678345',
        '9912345678345',
        CONVERT(datetime, '01/01/2012 00:00:00', 103),
        1500
    );



SELECT * FROM SupplyCapacity;

USE ConsumptionValidator

INSERT INTO ContractBands
    (
        Mpan,
        SupplyPointRef,
        Customer, 
        Date, 
        PencePerKwh, 
        StartTime, 
        EndTime, 
        Name
    )
    VALUES
    (

    );


USE ConsumptionValidator

TRUNCATE TABLE dbo.ProfileRows 
INSERT INTO dbo.ProfileRows 
    (
        Mpan, 
        SupplyPointRef,
        Date, 
        Kwh, 
        StartTime, 
        EndTime
    )
SELECT '001112229912345678345', '9912345678345', CONVERT(datetime, '01/02/2012 00:00:00', 103), 800, '00:00:00', '00:30:00' 
UNION 
SELECT '001112229912345678345', '9912345678345', CONVERT(datetime, '01/02/2012 00:00:00', 103), 400, '06:00:00', '06:30:00' 
UNION 
SELECT '001112229912345678345', '9912345678345', CONVERT(datetime, '01/02/2012 00:00:00', 103), 600, '07:00:00', '07:30:00' 
UNION 
SELECT '001112229912345678345', '9912345678345', CONVERT(datetime, '01/02/2012 00:00:00', 103), 200, '10:30:00', '11:00:00' 
UNION 
SELECT '001112229912345678345', '9912345678345', CONVERT(datetime, '01/02/2012 00:00:00', 103), 700, '11:00:00', '11:30:00' 
UNION 
SELECT '001112229912345678345', '9912345678345', CONVERT(datetime, '01/02/2012 00:00:00', 103), 650, '13:30:00', '14:00:00'


SELECT * FROM ContractBands;

USE ConsumptionValidator

INSERT INTO dbo.TransmissionLoss 
    (
        EffectiveDate, 
        Factor
    )
VALUES
    ( 
        CONVERT(datetime, '01/02/2009 00:00:00', 103), 
        1.01
    );


USE ConsumptionValidator

INSERT INTO dbo.TotalledEnergy
    (
        Mpan,
        SupplyPointRef,
        Date,
        Band,
        PencePerKwh,
        Kwh,
        EnergyCost,
        Count
    )
VALUES
    (
        '001112229912345678345', 
        '9912345678345', 
        CONVERT(datetime, '01/02/2012 00:00:00', 103),
        'Green',
        6.54,
        700,
        68362.33,
        2
    );

USE ConsumptionValidator

INSERT INTO dbo.TotalledEnergy
    (
        Mpan,
        SupplyPointRef,
        Date,
        Band,
        PencePerKwh,
        Kwh,
        EnergyCost,
        Count
    )
VALUES
    (
        '001112229912345678345', 
        '9912345678345', 
        CONVERT(datetime, '03/02/2012 00:00:00', 103),
        'Amber',
        3.54,
        500,
        57895.33,
        4
    );

USE ConsumptionValidator

INSERT INTO dbo.TotalledEnergy
    (
        Mpan,
        SupplyPointRef,
        Date,
        Band,
        PencePerKwh,
        Kwh,
        EnergyCost,
        Count
    )
VALUES
    (
        '001112229912345678345', 
        '9912345678345', 
        CONVERT(datetime, '02/02/2012 00:00:00', 103),
        'Red',
        10.54,
        800,
        80233.33,
        3
    );

    USE ConsumptionValidator

INSERT INTO dbo.TotalledDuos
    (
        Mpan,
        SupplyPointRef,
        Date,
        Band,
        Units,
        UnitCharge,
        Charge,
        Count
    )
VALUES
    (
        '001112229912345678345', 
        '9912345678345', 
        CONVERT(datetime, '02/02/2012 00:00:00', 103),
        'Red',
        10.54,
        800,
        80233.33,
        3
    );