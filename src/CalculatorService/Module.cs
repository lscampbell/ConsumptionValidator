using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Nancy;
using CalculatorService.Models;
using LoggingService.Models;
using Nancy.Validation;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace CalculatorService
{
    public class Module : NancyModule
    {
        ILogger<Module> _logger;
        ServiceClient<LogRequest, LogResponse> _logServiceClient;

        public Module(ILoggerFactory loggerFactory, ServiceClient<LogRequest, LogResponse> loggingServiceClient)
        {
            // Route for the API

            _logger = loggerFactory.CreateLogger<Module>();
            _logServiceClient = loggingServiceClient;

            _logger.LogInformation("Welcome to the Calculation Service MVP");

            Post("/calculate/{supplyPoint}/{marketParticipantId}/{llf}/{date}", p => CalculateAsync(new CalculatorRequest{ 
                Date = p.date, SupplyPoint = p.supplyPoint, MarketParticipantId = p.marketParticipantId, LLF = p.llf }));
        }

        async Task<CalculatorResponse> CalculateAsync(CalculatorRequest request)
        {
            // Do async requests for the data

            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to Calculate for {request.SupplyPoint}-{request.Date}" });
                return new CalculatorResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var taskResult = GetTheDataToMakeCalculationsAsync(request);

            var result = new CalculatorResponse { Success = true, Reply = HttpStatusCode.OK };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Calculation complete for: {request.SupplyPoint}-{request.MarketParticipantId}-{request.LLF}-{request.Date}" });

          return result;
        }

        async Task GetTheDataToMakeCalculationsAsync(CalculatorRequest request)
        {
            // This is set up for one off requests at the moment

            var retrievedData = new RetrieveData(request.Date, request.SupplyPoint, request.LLF, request.MarketParticipantId);

            // Get the customer information just in case its needed
            var customer = retrievedData.GetCustomerName();

            var calculated = new CalculatedData(
                                retrievedData.GetProfileData(), retrievedData.GetDuosTimeBands(),
                                retrievedData.GetDuosTariffs()[0], retrievedData.GetLosses(), 
                                retrievedData.GetTLossFactor(), retrievedData.GetContractBands());
            calculated.Calculate();

            var total = new TotalledCalculations(
                            calculated.CombinedLosses, retrievedData.GetSupplyCapacity(),
                            retrievedData.GetDuosTariffs()[0],
                            calculated.LossBand, calculated.EnergyBand);
            total.Total();

            var totalledDuos = total.DuosBand
                .Select(s => new {
                    SupplyPointRef = request.SupplyPoint,
                    Date = request.Date,                
                    Band = s.Band,
                    Units = s.Units,
                    UOM = s.UOM, 
                    UnitCharge = s.UnitCharge,
                    Charge = s.Charge,
                    Count = s.Count
                }).ToList();

            var doneDuos = new PostDataArray(totalledDuos);
            string duosPath = "http://localhost:1521/api/duos";
            await doneDuos.MakeCallAsync(duosPath);

            var totalledLoss = calculated.LossBand.GroupBy(s => s.Band)
                .Select(g => new {
                    SupplyPointRef = request.SupplyPoint,
                    Date = request.Date,
                    Band = g.Key,
                    PencePerKwh = g.Max(s => s.PencePerKwh),
                    TLossKwh = g.Sum(s => s.TLossKwh),
                    DLossKwh = g.Sum(s => s.DLossKwh),
                    Count =  g.Sum(s => s.Count)
                }).ToList();

            var doneLoss= new PostDataArray(totalledLoss);
            string lossPath = "http://localhost:1521/api/loss";
            await doneLoss.MakeCallAsync(lossPath);

            var totalledEnergy = calculated.EnergyBand.GroupBy(g => g.Band)
                .Select(s => new {
                    SupplyPointRef = request.SupplyPoint,
                    Date = request.Date,
                    Band = s.Key,
                    PencePerKwh = s.Max(g => g.PencePerKwh),
                    Kwh = s.Sum(g => g.Kwh),
                    EnergyCost = s.Sum(g => g.EnergyCost),
                    Count = s.Sum(g => g.Count)
                }).ToList();

            var doneEnergy = new PostDataArray(totalledEnergy);
            string energyPath = "http://localhost:1521/api/energy";
            await doneEnergy.MakeCallAsync(energyPath);
        }
    }
}