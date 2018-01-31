using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Nancy;
using StaticDataService.Models;
using StaticDataService.Persistence;
using LoggingService.Models;
using Nancy.Validation;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace StaticDataService
{
    public class DistributionOperatorModule : NancyModule
    {
        ILogger<DistributionOperatorModule> _logger;
        ServiceClient<LogRequest, LogResponse> _logServiceClient;
        readonly IDistributionNetworkOperatorRepository _repository;
        public DistributionOperatorModule(
            ILoggerFactory loggerFactory, 
            ServiceClient<LogRequest, LogResponse> loggingServiceClient, 
            IDistributionNetworkOperatorRepository repository)
        {
            _logger = loggerFactory.CreateLogger<DistributionOperatorModule>();
            _logServiceClient = loggingServiceClient;
            _repository = repository;

            Get("/distribution-operators", _ => GetDBOAsync());
            Get("/distribution-operators/{areaId}", p => GetDBOByAreaIdAsync(new DistributionOperatorRequest 
                { AreaId = p.areaId }));
            Get("/distribution-operators/{area}", p => GetDBOByAreaAsync(new DistributionOperatorRequest 
                { Area = p.area }));
            Get("/distribution-operators/{marketParticipantId}", p => GetDBOByMarketParticipantIdAsync(new DistributionOperatorRequest 
                { MarketParticipantId = p.marketParticipantId }));
        }

        async Task<DistributionOperatorResponse> GetDBOByMarketParticipantIdAsync(DistributionOperatorRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to get Profile Data for {request.MarketParticipantId}" });
                return new DistributionOperatorResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new DistributionOperatorResponse { Success = true, Operators = GetByMarketParticipantIdAsync(request.MarketParticipantId) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Retrieved Profile Data for {request.MarketParticipantId}: {result.Operators}" });

            return result;
        }

        IEnumerable<DistributionNetworkOperator> GetByMarketParticipantId(string marketParticipantId) => _repository.GetByMarketParticipantId(marketParticipantId);

        async Task<DistributionOperatorResponse> GetDBOByAreaAsync(DistributionOperatorRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to get Profile Data for {request.Area}" });
                return new DistributionOperatorResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new DistributionOperatorResponse { Success = true, Operators = GetByArea(request.Area) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Retrieved Profile Data for {request.Area}: {result.Operators}" });

            return result;
        }

        IEnumerable<DistributionNetworkOperator> GetByArea(string area) => _repository.GetByArea(area);

        async Task<DistributionOperatorResponse> GetDBOByAreaIdAsync(DistributionOperatorRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to get Profile Data for {request.AreaId}" });
                return new DistributionOperatorResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new DistributionOperatorResponse { Success = true, Operators = GetByAreaId(request.AreaId) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Retrieved Profile Data for {request.AreaId}: {result.Operators}" });

            return result;
        }

        IEnumerable<DistributionNetworkOperator> GetByAreaId(int areaId) => _repository.GetByAreaId(areaId);

        async Task<DistributionOperatorResponse> GetDBOAsync()
        {
            var result = new DistributionOperatorResponse { Success = true, Operators = GetDistributionOperators() };
            await _logServiceClient.PostAsync(new LogRequest { Message = "Got the Distribution Operators" });

            return result;
        }
        IEnumerable<DistributionNetworkOperator> GetDistributionOperators() => _repository.GetAll();
    }
}