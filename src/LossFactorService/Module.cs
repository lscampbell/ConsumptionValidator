using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Nancy;
using LossFactorService.Models;
using LoggingService.Models;
using Nancy.Validation;
using System.Threading.Tasks;

namespace LossFactorService
{
    public class Module : NancyModule
    {
        ILogger<Module> _logger;
        ServiceClient<LogRequest, LogResponse> _logServiceClient;

        public Module(ILoggerFactory loggerFactory, ServiceClient<LogRequest, LogResponse> loggingServiceClient)
        {
            _logger = loggerFactory.CreateLogger<Module>();
            _logServiceClient = loggingServiceClient;

            Get("/t-loss/{date}", p => GetTLossFactorAsync(new TransmissionLossFactorRequest 
                { Date = p.date}));
            Get("/d-loss/{area}/{llf:int}/{date}", p => GetDLossFactorAsync(new DistributionLossFactorRequest 
                { Area = p.area,
                  LLF = p.llf,
                  Date = p.date}));
        }

        async Task<TransmissionLossFactorResponse> GetTLossFactorAsync(TransmissionLossFactorRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to get transmission loss factors for {request.Date}" });
                return new TransmissionLossFactorResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new TransmissionLossFactorResponse { Success = true, Factor = GetTransmissionFactor(request.Date) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Generated Factorial for {request.Date}: {result.Factor}" });

            return result;
        }

        async Task<DistributionLossFactorResponse> GetDLossFactorAsync(DistributionLossFactorRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to generate factorial for {request.Date} - {request.LLF}:{request.Area}" });
                return new DistributionLossFactorResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new DistributionLossFactorResponse { Success = true, Factors = GetDistributionFactor(request) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Generated Factorial for {request.Date} - {request.LLF}:{request.Area} : {result.Factors}" });

            return result;
        }

        // This is where i would get info from database
        float GetTransmissionFactor(string date) => 1.01F;

        IEnumerable<DistributionLLF> GetDistributionFactor(DistributionLossFactorRequest info)
        {
            return new DistributionLLF[] {
                new DistributionLLF { LossAdjustmentFactor = 1.02F, StartTime = "00:00:00", EndTime = "00:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.02F, StartTime = "00:30:00", EndTime = "01:00:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.02F, StartTime = "01:00:00", EndTime = "01:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.02F, StartTime = "01:30:00", EndTime = "02:00:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.02F, StartTime = "02:00:00", EndTime = "02:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.02F, StartTime = "02:30:00", EndTime = "03:00:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.02F, StartTime = "03:00:00", EndTime = "03:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.02F, StartTime = "03:30:00", EndTime = "04:00:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.02F, StartTime = "04:00:00", EndTime = "04:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.02F, StartTime = "04:30:00", EndTime = "05:00:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.02F, StartTime = "05:00:00", EndTime = "05:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.02F, StartTime = "05:30:00", EndTime = "06:00:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.04F, StartTime = "06:00:00", EndTime = "06:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.04F, StartTime = "06:30:00", EndTime = "07:00:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.04F, StartTime = "07:00:00", EndTime = "07:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.04F, StartTime = "07:30:00", EndTime = "08:00:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.06F, StartTime = "08:00:00", EndTime = "08:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.06F, StartTime = "08:30:00", EndTime = "09:00:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.06F, StartTime = "09:00:00", EndTime = "09:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.06F, StartTime = "09:30:00", EndTime = "10:00:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.06F, StartTime = "10:00:00", EndTime = "10:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.06F, StartTime = "10:30:00", EndTime = "11:00:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.06F, StartTime = "11:00:00", EndTime = "11:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.06F, StartTime = "11:30:00", EndTime = "12:00:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.06F, StartTime = "12:00:00", EndTime = "12:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.06F, StartTime = "12:30:00", EndTime = "13:00:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.06F, StartTime = "13:00:00", EndTime = "13:30:00" },
                new DistributionLLF { LossAdjustmentFactor = 1.06F, StartTime = "13:30:00", EndTime = "14:00:00" }
            };
        }
    }
}