using Microsoft.AspNetCore.Mvc;
using UPNprojectApi.Models;
using WebAppUpnQ8Api.ViewModels;
using WebAppUpnQ8Api.ViewModels.ServicesViewModels;

namespace WebAppUpnQ8Api.Repository
{
    public interface IServiceRepository
    {

        //Services
        Task<Result<PagedResult<ServiceViewModel>>> AllServices(ServiceQueryParameters parameters);
        Task<Result<ServiceViewModel>> DetailsService(int id);
        Task<Result<string>> EditService(AddServiceModel data, IFormFile upload);
        Task<Result<string>> AddService(AddServiceModel data, IFormFile upload);
        Task<Result<string>> DeleteService(int id);

        //Sub Services
        Task<Result<PagedResult<SubServiceViewModel>>> AllSubServices(SubServiceQueryParameters query);
        Task<Result<string>> AddSubService(SubServiceDetailsModel data , IFormFile upload);
        Task<Result<string>> EditSubService(SubServiceDetailsModel data, IFormFile upload);
        Task<Result<string>> DeleteSubService(int id);


        Task<Result<PagedResult<SubFeatureModel>>> AllSubFeatures(SubFeatureQueryParameters query);

        Task<Result<string>> AddSubFeature(SubFeatureModel data);
        Task<Result<string>> EditSubFeature(SubFeatureModel data);
        Task<Result<string>> DeleteSubFeature(int id);

        //Special features
        Task<Result<PagedResult<SpecialFeatureModel>>> AllSpecialFeatures(SpecialFeatureQueryParameters query);
        Task<Result<string>> AddSpecialFeature(SpecialFeatureModel data);
        Task<Result<string>> EditSpecialFeature(SpecialFeatureModel data);
        Task<Result<string>> DeleteSpecialFeature(int id);

        // Subscribe Services
        Task<Result<PagedResult<ServiceRequestDetailsModel>>> AllSubscribeServices(SubscribeServiceQuery query);
        Task<Result<PagedResult<ServiceRequestDetailsModel>>> AllServiceRequests(ServiceRequestQuery query);
        Task<Result<ServiceRequestDetailsModel>> ServiceRequestDetails(int id);
        Task<Result<string>> AcceptServiceRequest(int id , RequestFileDescriptionsModel data);

    }
}
