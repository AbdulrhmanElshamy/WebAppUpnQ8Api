using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UPNprojectApi.Models;
using WebAppUpnQ8Api.Repository;
using WebAppUpnQ8Api.RepositoryModels;
using WebAppUpnQ8Api.ViewModels;
using WebAppUpnQ8Api.ViewModels.ServicesViewModels;

namespace WebAppUpnQ8Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        #region Services

        [HttpPost("GetAll")]
        public async Task<Result<PagedResult<ServiceViewModel>>> GetAllServices([FromQuery] ServiceQueryParameters queryParameters)
            => await _serviceRepository.AllServices(queryParameters);

        [HttpPost("create")]
        public Task<Result<string>> CreateService([FromForm] AddServiceModel serviceDetails)
            => _serviceRepository.AddService(serviceDetails, serviceDetails.upload);

        [HttpPost("update")]
        public Task<Result<string>> UpdateService([FromForm] AddServiceModel serviceDetails)
            => _serviceRepository.EditService(serviceDetails, serviceDetails.upload);

        [HttpGet("{id:int}")]
        public Task<Result<ServiceViewModel>> DetailsService(int id)
            => _serviceRepository.DetailsService(id);

        [HttpPost("{id:int}")]
        public Task<Result<string>> DeleteService(int id)
            => _serviceRepository.DeleteService(id);
        #endregion

        #region SpecialFeatures 

        [HttpPost("special-features")]
        public Task<Result<PagedResult<SpecialFeatureModel>>> AllSpecialFeatures(SpecialFeatureQueryParameters queryParameters)
            => _serviceRepository.AllSpecialFeatures(queryParameters);

        [HttpPost("special-features/create")]
        public Task<Result<string>> CreateSpecialFeature([FromBody] SpecialFeatureModel subFeatures)
            => _serviceRepository.AddSpecialFeature(subFeatures);

        [HttpPost("special-features/update")]
        public Task<Result<string>> UpdateSpecialFeature([FromBody] SpecialFeatureModel subFeatures)
            => _serviceRepository.EditSpecialFeature(subFeatures);

        [HttpPost("special-features/{id:int}")]
        public Task<Result<string>> DeleteSpecialFeature(int id)
            => _serviceRepository.DeleteSpecialFeature(id);

        #endregion

        #region SubServices

        [HttpPost("sub-services")]
        public Task<Result<PagedResult<SubServiceViewModel>>> AllSubServices(SubServiceQueryParameters queryParameters)
            => _serviceRepository.AllSubServices(queryParameters);

        [HttpPost("sub-services/create")]
        public Task<Result<string>> CreateSubService([FromForm] SubServiceDetailsModel subService)
            => _serviceRepository.AddSubService(subService, subService.upload);

        [HttpPost("sub-services/update")]
        public Task<Result<string>> UpdateSubService([FromForm] SubServiceDetailsModel data)
            => _serviceRepository.EditSubService(data, data.upload);

        [HttpPost("sub-services/{id:int}")]
        public Task<Result<string>> DeleteSubService(int id)
            => _serviceRepository.DeleteSubService(id);

        #endregion

        #region SubFeatures

        [HttpPost("sub-features")]
        public Task<Result<PagedResult<SubFeatureModel>>> AllSubFeatures(SubFeatureQueryParameters queryParameters)
            => _serviceRepository.AllSubFeatures(queryParameters);

        [HttpPost("sub-features/create")]
        public Task<Result<string>> CreateSubFeature([FromBody] SubFeatureModel subFeatures)
            => _serviceRepository.AddSubFeature(subFeatures);

        [HttpPost("sub-features/update")]
        public Task<Result<string>> EditSubFeature([FromBody] SubFeatureModel subFeatures)
            => _serviceRepository.EditSubFeature(subFeatures);

        [HttpPost("sub-features/{id:int}")]
        public Task<Result<string>> DeleteSubFeature(int id)
            => _serviceRepository.DeleteSubFeature(id);

        #endregion

        #region ServiceRequests 
        [HttpPost("requests")]
        public Task<Result<PagedResult<ServiceRequestDetailsModel>>> AllServiceRequests(ServiceRequestQuery query)
            => _serviceRepository.AllServiceRequests(query);

        [HttpPost("subscriptions")]
        public Task<Result<PagedResult<ServiceRequestDetailsModel>>> AllSubscribeServices(SubscribeServiceQuery query)
            => _serviceRepository.AllSubscribeServices(query);

        [HttpGet("requests/{id:int}")]
        public Task<Result<ServiceRequestDetailsModel>> ServiceRequestDetails(int id)
            => _serviceRepository.ServiceRequestDetails(id);

        [HttpPost("requests/{id:int}/accept")]
        public Task<Result<string>> AcceptServiceRequest(int id, [FromForm] RequestFileDescriptionsModel requestFiles)
            => _serviceRepository.AcceptServiceRequest(id, requestFiles);

        #endregion
    }
}
