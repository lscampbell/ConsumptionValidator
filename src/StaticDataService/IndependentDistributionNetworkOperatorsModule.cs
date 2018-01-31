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
    public class IndependentDistributionNetworkOperatorsModule : NancyModule
    {
        ILogger<IndependentDistributionNetworkOperatorsModule> _logger;
        ServiceClient<LogRequest, LogResponse> _logServiceClient;
        readonly IIndependentDistributionNetworkOperatorsRepository _repository;

        public IndependentDistributionNetworkOperatorsModule(
            ILoggerFactory loggerFactory,
            ServiceClient<LogRequest, LogResponse> loggingServiceClient,
            IIndependentDistributionNetworkOperatorsRepository repository)
        {
            _logger = loggerFactory.CreateLogger<IndependentDistributionNetworkOperatorsModule>();
            _logServiceClient = loggingServiceClient;
            _repository = repository;

            Get("/independent-distribution-network-operators", _ => GetIDNOAsync());
            Get("/independent-distribution-network-operators/{areaId}", p => GetIDNOByAreaIdAsync(new IndependentDistributionNetworkOperatorsRequest
            { AreaId = p.areaId }));
            Get("/independent-distribution-network-operators/{area}", p => GetIDNOByAreaAsync(new IndependentDistributionNetworkOperatorsRequest
            { Area = p.area }));
            Get("/independent-distribution-network-operators/{marketParticipantId}", p => GetIDNOByMarketParticipantIdAsync(new IndependentDistributionNetworkOperatorsRequest
            { MarketParticipantId = p.marketParticipantId }));
        }

        async Task<IndependentDistributionNetworkOperatorsResponse> GetIDNOByMarketParticipantIdAsync(IndependentDistributionNetworkOperatorsRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to get Profile Data for {request.MarketParticipantId}" });
                return new IndependentDistributionNetworkOperatorsResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new IndependentDistributionNetworkOperatorsResponse { Success = true, Operators = GetByMarketParticipantId(request.MarketParticipantId) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Retrieved Profile Data for {request.MarketParticipantId}: {result.Operators}" });

            return result;
        }

        IEnumerable<IndependentDistributionNetworkOperators> GetByMarketParticipantId(string marketParticipantId) => _repository.GetByMarketParticipantId(marketParticipantId);

        async Task<IndependentDistributionNetworkOperatorsResponse> GetIDNOByAreaAsync(IndependentDistributionNetworkOperatorsRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to get Profile Data for {request.Area}" });
                return new IndependentDistributionNetworkOperatorsResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new IndependentDistributionNetworkOperatorsResponse { Success = true, Operators = GetByArea(request.Area) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Retrieved Profile Data for {request.Area}: {result.Operators}" });

            return result;
        }

        IEnumerable<IndependentDistributionNetworkOperators> GetByArea(string area) => _repository.GetByArea(area);

        async Task<IndependentDistributionNetworkOperatorsResponse> GetIDNOByAreaIdAsync(IndependentDistributionNetworkOperatorsRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to get Profile Data for {request.AreaId}" });
                return new IndependentDistributionNetworkOperatorsResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new IndependentDistributionNetworkOperatorsResponse { Success = true, Operators = GetByAreaId(request.AreaId) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Retrieved Profile Data for {request.AreaId}: {result.Operators}" });

            return result;
        }

        IEnumerable<IndependentDistributionNetworkOperators> GetByAreaId(int areaId) => _repository.GetByAreaId(areaId);

        async Task<IndependentDistributionNetworkOperatorsResponse> GetIDNOAsync()
        {
            var result = new IndependentDistributionNetworkOperatorsResponse { Success = true, Operators = GetDistributionOperators() };
            await _logServiceClient.PostAsync(new LogRequest { Message = "Got the Distribution Operators" });

            return result;
        }

        IEnumerable<IndependentDistributionNetworkOperators> GetDistributionOperators() => _repository.GetAll();
    }
}