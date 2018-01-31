-- USE [MASTER];

-- CREATE DATABASE ConsumptionValidator;
USE ConsumptionValidator

CREATE TABLE TuosCharges (
    Id INT PRIMARY KEY IDENTITY,
    MarketParticipantId NVARCHAR(4),
    StartDate DATETIME2(7),
    EndDate DATETIME2(7), 
    Charge Float
)

DROP TABLE DuosTariffs;
CREATE TABLE DuosTariffs (
    Id INT PRIMARY KEY IDENTITY,
    MarketParticipantId NVARCHAR(4),
    StartDate DATETIME2(7),
    EndDate DATETIME2(7),
    LLF NVARCHAR(3),
    Name NVARCHAR(30),
    Red FLOAT,
    Amber FLOAT,
    Green FLOAT,
    Fixed FLOAT,
    Capacity FLOAT,
    ExceededCapacity FLOAT
);

DROP TABLE DuosTimeBands;
CREATE TABLE DuosTimeBands (
    Id INT PRIMARY KEY IDENTITY,
    MarketParticipantId NVARCHAR(4),
    StartDate DATETIME2(7),
    EndDate DATETIME2(7),
    LLF NVARCHAR(3),
    ApplicableDays NVARCHAR(30),
    ApplicableMonths NVARCHAR(60),
    StartTime NVARCHAR(8),
    EndTime NVARCHAR(8),
    Band NVARCHAR(8)
);

SET DATEFORMAT dmy;
-- CREATE TABLE NAME (
--     Id INT PRIMARY KEY IDENTITY
-- );
DROP TABLE DistributionLosses;
CREATE TABLE DistributionLosses (
    Id INT PRIMARY KEY IDENTITY,
    Date DATETIME2(7),
    StartTime NVARCHAR(8),
    EndTime NVARCHAR(8),
    MarketParticipantId NVARCHAR(4),
    LLF NVARCHAR(3),
    Factor FLOAT   
);

CREATE TABLE TransmissionLoss (
    Id INT PRIMARY KEY IDENTITY,
    EffectiveDate DATETIME2(7),
    Factor FLOAT   
);

CREATE TABLE ContractBands (
    Id INT PRIMARY KEY IDENTITY,
    Mpan NVARCHAR(21),
    SupplyPointRef NVARCHAR(13),
    Customer NVARCHAR(50),
    Date DATETIME2(7),
    PencePerKwh FLOAT,
    StartTime NVARCHAR(8),
    EndTime NVARCHAR(8),
    Name NVARCHAR(26)
);

CREATE TABLE ProfileRows (
    Id INT PRIMARY KEY IDENTITY,
    Mpan NVARCHAR(21),
    SupplyPointRef NVARCHAR(13),
    Date DATETIME2(7),
    Kwh INT,
    StartTime NVARCHAR(8),
    EndTime NVARCHAR(8),
);

CREATE TABLE DNOs (
    Id INT PRIMARY KEY IDENTITY,
    AreaId INT,
    Area NVARCHAR(50),
    Operator NVARCHAR(100),
    MarketParticipantId NVARCHAR(7),
    GSPGroupId NVARCHAR(2)
);

DROP TABLE SupplyPoint
CREATE TABLE SupplyPoint (
    Id INT PRIMARY KEY IDENTITY,
    Mpan NVARCHAR(21),
    SupplyPointRef NVARCHAR(13),
    SiteId NVARCHAR(7),
    SiteName NVARCHAR(50),
    AccountId NVARCHAR(50),
    SupplierId NVARCHAR(7),
    SupplierName NVARCHAR(50),
    MarketParticipantId NVARCHAR(4),
    MeterSerialNumber NVARCHAR(50)
);

CREATE TABLE MPANs (
    Id INT PRIMARY KEY IDENTITY,
    Mpan NVARCHAR(21),
    SupplyPointRef NVARCHAR(13),
    ProfileType NVARCHAR(2),
    MeterTimeSwitchCode NVARCHAR(3),
    LLF NVARCHAR(3),
    DistributionId NVARCHAR(2),
    UniqueIdentifer NVARCHAR(8),
    CheckDigit NVARCHAR(3),
);

CREATE TABLE Customer (
    Id INT PRIMARY KEY IDENTITY,
    Mpan NVARCHAR(21),
    SupplyPointRef NVARCHAR(13),
    Customer NVARCHAR(50)
);

CREATE TABLE PCs (
    Id INT PRIMARY KEY IDENTITY,
    ProfileId NVARCHAR(2),
    ClassDescription NVARCHAR(150)
);

CREATE TABLE MTCs (
    Id INT PRIMARY KEY IDENTITY,
    MeterTimeSwitchClassId NVARCHAR(10),
    ClassDescription NVARCHAR(100)
);

CREATE TABLE IDNOs (
    Id INT PRIMARY KEY IDENTITY,
    AreaId INT,
    Area NVARCHAR(50),
    Licensee NVARCHAR(50),
    MarketParticipantId  NVARCHAR(7)
);

CREATE TABLE SupplyCapacity (
    Id INT PRIMARY KEY IDENTITY,
    Mpan NVARCHAR(21),
    SupplyPointRef NVARCHAR(13), 
    EffectiveDate DATETIME2(7),
    AvailableCapacity INT   
);

CREATE TABLE SuperTable(
    Id INT PRIMARY KEY IDENTITY,
    Area NVARCHAR(50),
    Timestamp DATETIME NULL DEFAULT GETDATE()
);

USE ConsumptionValidator

TRUNCATE TABLE TotalledEnergy;

CREATE TABLE TotalledEnergy(
    Id INT PRIMARY KEY IDENTITY,
    Mpan NVARCHAR(21),
    SupplyPointRef NVARCHAR(13),
    Date DATETIME2(7),
    Band NVARCHAR(8),
    PencePerKwh FLOAT,
    Kwh INT,
    EnergyCost DECIMAL,
    Count INT,
    Created DATETIME NULL DEFAULT GETDATE()
);

TRUNCATE TABLE TotalledLoss;

CREATE TABLE TotalledLoss(
    Id INT PRIMARY KEY IDENTITY,
    Mpan NVARCHAR(21),
    SupplyPointRef NVARCHAR(13),
    Date DATETIME2(7),
    Band NVARCHAR(8),
    PencePerKwh FLOAT,
    TLossKwh FLOAT,
    DLossKwh FLOAT,
    Count INT,
    Created DATETIME NULL DEFAULT GETDATE()
);

USE ConsumptionValidator
-- DROP TABLE TotalledDuos;


CREATE TABLE TotalledDuos(
    Id INT PRIMARY KEY IDENTITY,
    Mpan NVARCHAR(21),
    SupplyPointRef NVARCHAR(13),
    Date DATETIME2(7),
    Band NVARCHAR(30),
    Units INT,
    UOM NVARCHAR(50),
    UnitCharge FLOAT,
    Charge DECIMAL,
    Count INT,
    Created DATETIME NULL DEFAULT GETDATE()
);