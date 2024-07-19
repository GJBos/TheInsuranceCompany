using Microsoft.AspNetCore.Mvc;
using TIC.DomainAPI;
using TIC.WebAPI.Mappers;
using TIC.WebAPI.Models.Requests;
using TIC.WebAPI.Models.Responses;

namespace TIC.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InsuranceController : ControllerBase
    {
        private readonly ILogger<InsuranceController> _logger;
        private readonly IInsuranceDomain _insuranceDomain;
        private readonly IGetInsurancesRequestMapper _getInsurancesRequestMapper;
        private readonly IGetInsurancesResponseMapper _getInsurancesResponseMapper;
        private readonly IAddInsuranceRequestMapper _addInsuranceRequestMapper;
        private readonly IGetDutchTravelInsuranceRequestMapper _getDutchTravelInsuranceRequestMapper;
        private readonly IGetDutchTravelInsurancesResponseMapper _getDutchTravelInsurancesResponseMapper;

        public InsuranceController(ILogger<InsuranceController> logger, 
            IInsuranceDomain insuranceDomain, 
            IGetInsurancesRequestMapper getInsurancesRequestMapper, 
            IGetInsurancesResponseMapper getInsurancesResponseMapper, 
            IAddInsuranceRequestMapper addInsuranceRequestMapper,
            IGetDutchTravelInsuranceRequestMapper getDutchTravelInsuranceRequestMapper,
            IGetDutchTravelInsurancesResponseMapper getDutchTravelInsurancesResponseMapper)
        {
            _logger = logger;
            _insuranceDomain = insuranceDomain;
            _getInsurancesRequestMapper = getInsurancesRequestMapper;
            _getInsurancesResponseMapper = getInsurancesResponseMapper;
            _addInsuranceRequestMapper = addInsuranceRequestMapper;
            _getDutchTravelInsuranceRequestMapper = getDutchTravelInsuranceRequestMapper;
            _getDutchTravelInsurancesResponseMapper = getDutchTravelInsurancesResponseMapper;
        }

        [HttpPost(Name = "GetInsurances")]
        public GetInsurancesResponse GetInsurances(GetInsurancesRequest request)
        {
            try
            {
                var domainRequest = _getInsurancesRequestMapper.Map(request);
                var insurances = _insuranceDomain.GetInsurances(domainRequest);
                var mappedResponse = _getInsurancesResponseMapper.Map(insurances);
                return mappedResponse;
            }
            catch (Exception exception)
            {
                _logger.Log(LogLevel.Error, exception, exception.Message);
                throw;
            }
        }

        [HttpPost(Name = "AddInsurance")]
        public void AddInsurance(AddInsuranceRequest request)
        {
            try
            {
                var domainRequest = _addInsuranceRequestMapper.Map(request);
                _insuranceDomain.AddInsurance(domainRequest);
            }
            catch (Exception exception)
            {
                _logger.Log(LogLevel.Error, exception, exception.Message);
                throw;
            }
        }

        [HttpPost(Name = "GetDutchTravelInsurances")]
        public IEnumerable<GetDutchTravelInsurancesResponse> GetDutchTravelInsurances(GetDutchTravelInsuranceRequest request)
        {
            try
            {
                var domainRequest = _getDutchTravelInsuranceRequestMapper.Map(request);
                var dutchTravelInsurances = _insuranceDomain.GetDutchTravelInsurances(domainRequest);
                var mappedResponse = _getDutchTravelInsurancesResponseMapper.Map(dutchTravelInsurances);
                return mappedResponse;
            }
            catch (Exception exception)
            {
                _logger.Log(LogLevel.Error, exception, exception.Message);
                throw;
            }
        }
    }
}