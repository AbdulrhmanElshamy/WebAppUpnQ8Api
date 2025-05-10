using Grpc.Core;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MimeKit;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using UPNprojectApi.Models;
using WebAppUpnQ8Api.Helper;
using WebAppUpnQ8Api.Models;
using WebAppUpnQ8Api.Repository;
using WebAppUpnQ8Api.Services.EmailServices;
using WebAppUpnQ8Api.ViewModels;
using WebAppUpnQ8Api.ViewModels.HomeViewModels;
using WebAppUpnQ8Api.ViewModels.ServicesViewModels;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAppUpnQ8Api.RepositoryModels
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly WebAppUpnQ8ApiDBContext _dBContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IEmailSender _emailSender;
        public ServiceRepository(WebAppUpnQ8ApiDBContext dBContext,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor contextAccessor,
            IEmailSender emailSender)
        {
            _dBContext = dBContext;
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
            _emailSender = emailSender;
        }

        public async Task<Result<string>> AcceptServiceRequest(int id, RequestFileDescriptionsModel requestFiles)
        {
            try
            {
                var serviceRequest = await _dBContext.ServiceRequestsTbls.FindAsync(id);
                if (serviceRequest != null)
                {
                    serviceRequest.Request_Status = ServiceRequestStatus.finshed;
                    serviceRequest.Service_Active_Date = DateTime.Now;
                    serviceRequest.Finished_Date = requestFiles.Finished_Date;

                    serviceRequest.Renewal_price = requestFiles.Renewal_price;

                    string code = serviceRequest.Requset_Code;
                    await _dBContext.SaveChangesAsync();
                    return Result<string>.Success("تم قبول الطلب بنجاح");
                }
                else
                {
                    return Result<string>.Failed("لم يتم ايجاد العنصر");
                }
            }
            catch
            {
                return Result<string>.Failed("عذرا لقد حدثت مشكلة ما ");
            }
        }

        public async Task<Result<string>> AddService(AddServiceModel serviceDetails, IFormFile upload)
        {
            try
            {
                ServicesTbl service = new ServicesTbl();

                service.Service_Title = serviceDetails.Service_Title;
                service.Service_Description = serviceDetails.Service_Description;
                service.Service_Title_Ar = serviceDetails.Service_Title_Ar;
                service.Service_Description_Ar = serviceDetails.Service_Description_Ar;
                if (upload is null)
                    return Result<string>.Failed("يرجي اضافة صورة");

                var contentRootPath = _webHostEnvironment.WebRootPath;
                var uploadDirectory = Path.Combine(contentRootPath, "Images/ServicesImg");

                service.Image = await FileHelper.SaveFileAsync(upload, uploadDirectory);

                await _dBContext.ServicesTbls.AddAsync(service);

                if (await _dBContext.SaveChangesAsync() > 0)
                    return Result<string>.Success(data:service.Service_ID.ToString());

                return Result<string>.Failed("عذرا لم تتم اضافة الخدمة");
            }
            catch
            {
                return Result<string>.Failed("عذرا حدثت مشكلة ما");
            }
        }
        public async Task<Result<string>> EditService(AddServiceModel serviceDetails, IFormFile upload)
        {
            try
            {
                var Oldservice = _dBContext.ServicesTbls.Find(serviceDetails.Service_ID);

                if (Oldservice is null)
                    return Result<string>.Failed("الخدمة غير موجوده");


                Oldservice.Service_Title = serviceDetails.Service_Title;
                Oldservice.Service_Description = serviceDetails.Service_Description;
                Oldservice.Service_Title_Ar = serviceDetails.Service_Title_Ar;
                Oldservice.Service_Description_Ar = serviceDetails.Service_Description_Ar;
                if (upload is not null)
                {
                    string Old1IMG = "";
                    Old1IMG = Oldservice.Image;
                    var contentRootPath = _webHostEnvironment.WebRootPath;
                    if (!string.IsNullOrEmpty(Old1IMG))
                    {
                        FileHelper.DeleteFile(Old1IMG);
                    }


                    var uploadDirectory = Path.Combine(contentRootPath, "Images/ServicesImg");

                    Oldservice.Image = await FileHelper.SaveFileAsync(upload, uploadDirectory);

                }
                await _dBContext.SaveChangesAsync();

                return Result<string>.Success("تمت عملية التعديل بنجاح");


            }
            catch
            {
                return Result<string>.Failed("لم يتم حفط الخدمة");
            }
        }

        public async Task<Result<string>> AddSpecialFeature(SpecialFeatureModel subFeatures)
        {
            try
            {
                SpecialFeaturesTbl specialFeature = new SpecialFeaturesTbl();
                specialFeature.Feature_Description = subFeatures.Feature_Description;
                specialFeature.Feature_Description_Ar = subFeatures.Feature_Description_Ar;
                specialFeature.Feature_Price = subFeatures.Feature_Price;
                specialFeature.Feature_Name_Ar = subFeatures.Feature_Name_Ar;
                specialFeature.Feature_Name = subFeatures.Feature_Name;
                specialFeature.Service_ID = subFeatures.Service_ID;
                await _dBContext.SpecialFeaturesTbls.AddAsync(specialFeature);
                await _dBContext.SaveChangesAsync();
                return Result<string>.Success("Success");
            }
            catch
            {
                return Result<string>.Failed("Error");
            }

        }

        public async Task<Result<string>> AddSubService(SubServiceDetailsModel subService, IFormFile upload)
        {
            try
            {
                var service = await _dBContext.ServicesTbls.FindAsync(subService.Service_ID);
                if (service is null)
                    return Result<string>.Failed("الخدمة غير موجوده");

                if (upload is null)
                    return Result<string>.Failed("يرجي اختيار صورة");

                var imageFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", "ServicesImg");
                var savedFileName = await FileHelper.SaveFileAsync(upload, imageFolder);

                var newSubService = new SubServicesTbl
                {
                    Sub_Service_Title = subService.Sub_Service_Title,
                    Sub_Service_Title_Ar = subService.Sub_Service_Title_Ar,
                    Sub_Service_Price = subService.Sub_Service_Price,
                    Service_ID = subService.Service_ID,
                    Image = savedFileName
                };

                await _dBContext.SubServicesTbls.AddAsync(newSubService);
                await _dBContext.SaveChangesAsync();

                var subFeatures = subService.subFeatures.Select(c => new SubFeaturesTbl
                {
                    Sub_Feature_Text = c.Sub_Feature_Text,
                    Sub_Feature_Text_Ar = c.Sub_Feature_Text_Ar,
                    Sub_Service_ID = newSubService.Sub_Service_ID
                }).ToList();

                await _dBContext.SubFeaturesTbls.AddRangeAsync(subFeatures);
                await _dBContext.SaveChangesAsync();

                return Result<string>.Success(data: newSubService.Sub_Service_ID.ToString());
            }
            catch
            {
                return Result<string>.Failed("Error");
            }
        }


        public async Task<Result<PagedResult<ServiceRequestDetailsModel>>> AllServiceRequests(ServiceRequestQuery query)
        {
            try
            {
                var requestsQuery = _dBContext.ServiceRequestsTbls
                    .Include(a => a.CustomersTbl)
                    .Include(a => a.SubServicesTbl).ThenInclude(s => s.ServicesTbl)
                    .AsQueryable();

                if (query.RequestStatus.HasValue)
                {
                    requestsQuery = requestsQuery.Where(a => a.Request_Status == query.RequestStatus.Value);
                }

                if (!string.IsNullOrEmpty(query.CustomerId))
                {
                    requestsQuery = requestsQuery.Where(a => a.Customer_ID == query.CustomerId);
                }

                var totalCount = await requestsQuery.CountAsync();

                var pagedData = await requestsQuery
                    .Skip((query.PageNumber - 1) * query.PageSize)
                    .Take(query.PageSize)
                    .Select(a => new ServiceRequestDetailsModel
                    {
                        Service_Request_ID = a.Id,
                        Customer_ID = a.Customer_ID,
                        Service_Request_Date = a.Service_Request_Date,
                        Service_Response_Date = a.Service_Response_Date,
                        Sub_Service_ID = a.Sub_Service_ID,
                        Request_Status = a.Request_Status,
                        Service_Active_Date = a.Service_Active_Date,
                        Finished_Date = a.Finished_Date,
                        Renewal_price = a.Renewal_price,
                        Renewal_request = a.Renewal_request,
                        Requset_Code = a.Requset_Code,
                        First_Name = a.CustomersTbl.FirstName,
                        Last_Name = a.CustomersTbl.LastName,
                        Sub_Service_Title = a.SubServicesTbl.Sub_Service_Title,
                        Service_Title = a.SubServicesTbl.ServicesTbl.Service_Title,
                        Sub_Service_Title_Ar = a.SubServicesTbl.Sub_Service_Title_Ar,
                        Service_Title_Ar = a.SubServicesTbl.ServicesTbl.Service_Title_Ar
                    }).ToListAsync();

                return Result<PagedResult<ServiceRequestDetailsModel>>.Success(
                    new PagedResult<ServiceRequestDetailsModel>(pagedData, totalCount, query.PageNumber, query.PageSize,(int)Math.Ceiling((double)(int)Math.Ceiling((double)totalCount / query.PageSize)))
                );
            }
            catch
            {
                return Result<PagedResult<ServiceRequestDetailsModel>>.Failed("عذراً، حدث خطأ ما.");
            }
        }



        public async Task<Result<PagedResult<ServiceViewModel>>> AllServices(ServiceQueryParameters parameters)
        {
            try
            {
                var query = _dBContext.ServicesTbls.AsQueryable();

                if (!string.IsNullOrWhiteSpace(parameters.Search))
                {
                    query = query.Where(a =>
                        a.Service_Title.Contains(parameters.Search) ||
                        a.Service_Title_Ar.Contains(parameters.Search) ||
                        a.Service_Description.Contains(parameters.Search) ||
                        a.Service_Description_Ar.Contains(parameters.Search));
                }

                int totalCount = await query.CountAsync();

                var services = await query
                    .OrderByDescending(s => s.Service_ID)
                    .Skip((parameters.Page - 1) * parameters.PageSize)
                    .Take(parameters.PageSize)
                    .Select(a => new ServiceViewModel
                    {
                        Service_ID = a.Service_ID,
                        Service_Title = a.Service_Title,
                        Service_Description = a.Service_Description,
                        Service_Title_Ar = a.Service_Title_Ar,
                        Service_Description_Ar = a.Service_Description_Ar,
                        Image = a.Image,
                    })
                    .ToListAsync();

                var result = new PagedResult<ServiceViewModel>(services, totalCount, parameters.Page, parameters.PageSize, (int)Math.Ceiling((double)totalCount / parameters.PageSize));

                if (services.Any())
                {
                    return Result<PagedResult<ServiceViewModel>>.Success(result);
                }

                return Result<PagedResult<ServiceViewModel>>.Failed("عذرا لا يوجد خدمات بعد");
            }
            catch
            {
                return Result<PagedResult<ServiceViewModel>>.Failed("عذرا لقد حدثت مشكلة ما");
            }
        }



        public async Task<Result<List<ServiceViewModel>>> AllServices()
        {
            try
            {
                var query = await _dBContext.ServicesTbls.ToListAsync();

                var services =  query
                    .OrderByDescending(s => s.Service_ID)
                    .Select(a => new ServiceViewModel
                    {
                        Service_ID = a.Service_ID,
                        Service_Title = a.Service_Title,
                        Service_Description = a.Service_Description,
                        Service_Title_Ar = a.Service_Title_Ar,
                        Service_Description_Ar = a.Service_Description_Ar,
                        Image = a.Image,
                    })
                    .ToList();

             
                if (services.Any())
                {
                    return Result<List<ServiceViewModel>>.Success(services);
                }

                return Result<List<ServiceViewModel>>.Failed("عذرا لا يوجد خدمات بعد");
            }
            catch
            {
                return Result<List<ServiceViewModel>>.Failed("عذرا لقد حدثت مشكلة ما");
            }
        }


        public async Task<Result<PagedResult<SpecialFeatureModel>>> AllSpecialFeatures(SpecialFeatureQueryParameters query)
        {
            try
            {
                var queryable = _dBContext.SpecialFeaturesTbls
                    .Where(a => a.Service_ID == query.ServiceId);

                var totalCount = await queryable.CountAsync();

                var features = await queryable
                    .Skip((query.PageNumber - 1) * query.PageSize)
                    .Take(query.PageSize)
                    .Select(a => new SpecialFeatureModel
                    {
                        Special_Feature_ID = a.Special_Feature_ID,
                        Feature_Name = a.Feature_Name,
                        Feature_Name_Ar = a.Feature_Name_Ar,
                        Feature_Description = a.Feature_Description,
                        Feature_Description_Ar = a.Feature_Description_Ar,
                        Feature_Price = a.Feature_Price,
                        Service_ID = a.Service_ID
                    }).ToListAsync();

                var result = new PagedResult<SpecialFeatureModel>(features, totalCount, query.PageNumber, query.PageSize, (int)Math.Ceiling((double)totalCount / query.PageSize));

                return Result<PagedResult<SpecialFeatureModel>>.Success(result);
            }
            catch
            {
                return Result<PagedResult<SpecialFeatureModel>>.Failed("عذرا لقد حدثت مشكلة ما ");
            }
        }


        public async Task<Result<PagedResult<ServiceRequestDetailsModel>>> AllSubscribeServices(SubscribeServiceQuery query)
        {
            try
            {
                var serviceRequestsQuery = _dBContext.ServiceRequestsTbls
                    .Include(a => a.CustomersTbl)
                    .Include(a => a.SubServicesTbl).ThenInclude(s => s.ServicesTbl)
                    .AsQueryable();

                if (query.RequestStatus.HasValue)
                {
                    serviceRequestsQuery = serviceRequestsQuery
                        .Where(a => a.Request_Status == query.RequestStatus.Value);
                }

                var totalCount = await serviceRequestsQuery.CountAsync();

                var pagedRequests = await serviceRequestsQuery
                    .Skip((query.PageNumber - 1) * query.PageSize)
                    .Take(query.PageSize)
                    .Select(a => new ServiceRequestDetailsModel
                    {
                        Service_Request_ID = a.Id,
                        Customer_ID = a.Customer_ID,
                        Service_Request_Date = a.Service_Request_Date,
                        Service_Response_Date = a.Service_Response_Date,
                        Sub_Service_ID = a.Sub_Service_ID,
                        Request_Status = a.Request_Status,
                        Service_Active_Date = a.Service_Active_Date,
                        Finished_Date = a.Finished_Date,
                        Renewal_price = a.Renewal_price,
                        Renewal_request = a.Renewal_request,
                        Requset_Code = a.Requset_Code,
                        First_Name = a.CustomersTbl.FirstName,
                        Last_Name = a.CustomersTbl.LastName,
                        Sub_Service_Title_Ar = a.SubServicesTbl.Sub_Service_Title_Ar,
                        Service_Title_Ar = a.SubServicesTbl.ServicesTbl.Service_Title_Ar,
                        Sub_Service_Title = a.SubServicesTbl.Sub_Service_Title,
                        Service_Title = a.SubServicesTbl.ServicesTbl.Service_Title
                    }).ToListAsync();

                return Result<PagedResult<ServiceRequestDetailsModel>>.Success(
                    new PagedResult<ServiceRequestDetailsModel>(pagedRequests, totalCount, query.PageNumber, query.PageSize, (int)Math.Ceiling((double)totalCount / query.PageSize))
                );
            }
            catch
            {
                return Result<PagedResult<ServiceRequestDetailsModel>>.Failed("عذراً، حدث خطأ ما.");
            }
        }



        public async Task<Result<PagedResult<SubServiceViewModel>>> AllSubServices(SubServiceQueryParameters query)
        {
            try
            {
                var subServiceQuery = _dBContext.SubServicesTbls
                    .Where(s => s.Service_ID == query.ServiceId);

                if (!string.IsNullOrWhiteSpace(query.Title))
                {
                    subServiceQuery = subServiceQuery.Where(s => s.Sub_Service_Title.Contains(query.Title)
                                                               || s.Sub_Service_Title_Ar.Contains(query.Title));
                }

                if (query.MinPrice.HasValue)
                {
                    subServiceQuery = subServiceQuery.Where(s => s.Sub_Service_Price >= (double)query.MinPrice.Value);
                }

                if (query.MaxPrice.HasValue)
                {
                    subServiceQuery = subServiceQuery.Where(s => s.Sub_Service_Price <= (double)query.MaxPrice.Value);
                }

                var totalCount = await subServiceQuery.CountAsync();

                var result = await subServiceQuery
                    .Skip((query.PageNumber - 1) * query.PageSize)
                    .Take(query.PageSize)
                    .Select(s => new SubServiceViewModel
                    {
                        Sub_Service_ID = s.Sub_Service_ID,
                        Sub_Service_Title = s.Sub_Service_Title,
                        Sub_Service_Title_Ar = s.Sub_Service_Title_Ar,
                        Sub_Service_Price = s.Sub_Service_Price,
                        Image = s.Image,
                        Service_ID = s.Service_ID
                    }).ToListAsync();

                return Result<PagedResult<SubServiceViewModel>>.Success(new PagedResult<SubServiceViewModel>(result, totalCount, query.PageNumber, query.PageSize, (int)Math.Ceiling((double)totalCount / query.PageSize)));
            }
            catch
            {
                return Result<PagedResult<SubServiceViewModel>>.Failed("عذرا لقد حدثت مشكلة ما");
            }
        }

        public async Task<Result<string>> EditSubService(SubServiceDetailsModel data, IFormFile upload)
        {
            try
            {
                var Oldsubservice = await _dBContext.SubServicesTbls.FindAsync(data.Sub_Service_ID);

                if (Oldsubservice is null)
                    return Result<string>.Failed("sub service not found");


                var service = await _dBContext.ServicesTbls.FindAsync(data.Service_ID);
                if (Oldsubservice is null)
                    return Result<string>.Failed("service not found");


                Oldsubservice.Sub_Service_Title = data.Sub_Service_Title;
                Oldsubservice.Sub_Service_Title_Ar = data.Sub_Service_Title_Ar;
                Oldsubservice.Sub_Service_Price = data.Sub_Service_Price;
                if (upload != null)
                {
                    var contentRootPath = _webHostEnvironment.WebRootPath;
                    string Old1IMG = "";
                    Old1IMG = Oldsubservice.Image;
                    if (Old1IMG is not null)
                    {
                        FileHelper.DeleteFile(Old1IMG);
                    }

                    Oldsubservice.Image = await FileHelper.SaveFileAsync(upload, contentRootPath);

                }
                await _dBContext.SaveChangesAsync();

                return Result<string>.Success("Success");
            }
            catch
            {
                return Result<string>.Failed("Error");
            }
        }
        public async Task<Result<string>> DeleteSubService(int id)
        {
            try
            {
                var subfeatures = await _dBContext.SubFeaturesTbls.Where(a => a.Sub_Service_ID == id).CountAsync();
                var subscripes = await _dBContext.ServiceRequestsTbls.Where(a => a.Sub_Service_ID == id).CountAsync();
                if (subfeatures != 0 || subscripes != 0)
                {
                    return Result<string>.Failed("لا يمكن حذف الخدمة لوجود ارتباطات اخرى معها");
                }
                
                var subservice = await _dBContext.SubServicesTbls.FindAsync(id);

                if(subservice is null)
                    return Result<string>.Failed("sub service not found");

                _dBContext.SubServicesTbls.Remove(subservice);
                await _dBContext.SaveChangesAsync();
                return Result<string>.Success("تمت عملية الحذف بنجاح");
            }
            catch
            {
                return Result<string>.Failed("عذرا لقد حدثت مشكلة ما");
            }
        }
        public async Task<Result<string>> DeleteService(int id)
        {
            try
            {
                var specialfeatures = await _dBContext.SpecialFeaturesTbls.Where(a => a.Service_ID == id).CountAsync();
                var subservices = await _dBContext.SubServicesTbls.Where(a => a.Service_ID == id).CountAsync();
                var specialrequests = await _dBContext.SpecialRequestsTbls.Where(a => a.Service_ID == id).CountAsync();
                var requestquotes = await _dBContext.RequestsQuoteTbls.Where(a => a.Service_ID == id).CountAsync();

                if (specialfeatures != 0 || subservices != 0 || specialrequests != 0 || requestquotes != 0)
                {
                    return Result<string>.Failed("لا يمكن حذف الخدمة لوجود ارتباطات اخرى معها");
                }
                else
                {
                    var service = await _dBContext.ServicesTbls.FindAsync(id);
                    if (service != null)
                    {
                        _dBContext.ServicesTbls.Remove(service);
                        await _dBContext.SaveChangesAsync();
                        return Result<string>.Success("تمت عملية الحذف بنجاح");
                    }
                    else
                    {
                        return Result<string>.Failed("عذرا لم يتم ايجاد العنصر ");
                    }
                }
            }
            catch
            {
                return Result<string>.Failed("عذرا لقد حدثت مشكلة ما");
            }
        }

        public async Task<Result<string>> DeleteSpecialFeature(int id)
        {
            try
            {
                var specialfeatures = await _dBContext.SpecialRequestFeaturesTbls.Where(a => a.Special_Feature_ID == id).CountAsync();

                if (specialfeatures != 0)
                {
                    return Result<string>.Failed("لا يمكن حذف الخدمة لوجود ارتباطات اخرى معها");
                }
                else
                {
                    var service = await _dBContext.SpecialFeaturesTbls.FindAsync(id);
                    if (service != null)
                    {
                        _dBContext.SpecialFeaturesTbls.Remove(service);
                        await _dBContext.SaveChangesAsync();
                        return Result<string>.Success("تمت عملية الحذف بنجاح");
                    }
                    else
                    {
                        return Result<string>.Failed("عذرا لم يتم ايجاد العنصر ");
                    }
                }
            }
            catch
            {
                return Result<string>.Failed("عذرا لقد حدثت مشكلة ما");
            }
        }

        public async Task<Result<string>> DeleteSubFeature(int id)
        {
            try
            {
                var service = await _dBContext.SubFeaturesTbls.FindAsync(id);
                if (service != null)
                {
                    _dBContext.SubFeaturesTbls.Remove(service);
                    await _dBContext.SaveChangesAsync();
                    return Result<string>.Success("تمت عملية الحذف بنجاح");
                }
                else
                {
                    return Result<string>.Failed("عذرا لم يتم ايجاد العنصر ");
                }
            }
            catch
            {
                return Result<string>.Failed("عذرا لقد حدثت مشكلة ما");
            }
        }

        public async Task<Result<ServiceViewModel>> DetailsService(int id)
        {
            try
            {
                var servicesTbl = await _dBContext.ServicesTbls.Where(a => a.Service_ID == id).
                    Include(a => a.SubServicesTbls).Select(a => new ServiceViewModel
                    {
                        Service_ID = a.Service_ID,
                        Service_Title = a.Service_Title,
                        Service_Description = a.Service_Description,
                        Service_Title_Ar = a.Service_Title_Ar,
                        Service_Description_Ar = a.Service_Description_Ar,
                        Image = a.Image

                    }).FirstOrDefaultAsync();
                if (servicesTbl != null)
                {
                    return Result<ServiceViewModel>.Success(servicesTbl);
                }
                else
                {
                    return Result<ServiceViewModel>.Failed("عذرا لم يتم ايجاد العنصر");
                }
            }
            catch
            {
                return Result<ServiceViewModel>.Failed("عذرا حدث خطأ ما ");
            }
        }


        public async Task<Result<string>> EditSpecialFeature(SpecialFeatureModel subFeatures)
        {
            try
            {
                var OldFeature = await _dBContext.SpecialFeaturesTbls.FindAsync(subFeatures.Special_Feature_ID);
                var service = await _dBContext.ServicesTbls.FindAsync(subFeatures.Service_ID);
                if (service is null)
                    return Result<string>.Failed("لم يتم ايجاد الخدمة المطلوبة");

                if (OldFeature != null)
                {
                    OldFeature.Feature_Name = subFeatures.Feature_Name;
                    OldFeature.Feature_Name_Ar = subFeatures.Feature_Name_Ar;
                    OldFeature.Feature_Price = subFeatures.Feature_Price;
                    OldFeature.Feature_Description = subFeatures.Feature_Description;
                    OldFeature.Feature_Description_Ar = subFeatures.Feature_Description_Ar;
                    OldFeature.Service_ID = subFeatures.Service_ID;

                    await _dBContext.SaveChangesAsync();
                    return Result<string>.Success("تمت عملية التعديل بنجاح");
                }
                else
                {
                    return Result<string>.Failed("لم يتم ايجاد العنصر المطلوب");
                }
            }
            catch
            {
                return Result<string>.Failed("عذرا لقد حدث خطأ ما ");
            }
        }

        public async Task<Result<PagedResult<SubFeatureModel>>> AllSubFeatures(SubFeatureQueryParameters query)
        {
            try
            {
                var subFeatureQuery = _dBContext.SubFeaturesTbls
                    .Where(f => f.Sub_Service_ID == query.SubServiceId);

                if (!string.IsNullOrWhiteSpace(query.Text))
                {
                    subFeatureQuery = subFeatureQuery.Where(f =>
                        f.Sub_Feature_Text.Contains(query.Text) || f.Sub_Feature_Text_Ar.Contains(query.Text));
                }

                var totalCount = await subFeatureQuery.CountAsync();

                var result = await subFeatureQuery
                    .Skip((query.PageNumber - 1) * query.PageSize)
                    .Take(query.PageSize)
                    .Select(f => new SubFeatureModel
                    {
                        Sub_Feature_ID = f.Sub_Feature_ID,
                        Sub_Feature_Text = f.Sub_Feature_Text,
                        Sub_Feature_Text_Ar = f.Sub_Feature_Text_Ar,
                        Sub_Service_ID = f.Sub_Service_ID
                    }).ToListAsync();

                return Result<PagedResult<SubFeatureModel>>.Success(new PagedResult<SubFeatureModel>(result, totalCount, query.PageNumber, query.PageSize, (int)Math.Ceiling((double)totalCount / query.PageSize)));
            }
            catch
            {
                return Result<PagedResult<SubFeatureModel>>.Failed("عذرا لقد حدثت مشكلة ما");
            }
        }

        public async Task<Result<string>> EditSubFeature(SubFeatureModel subFeatures)
        {
            try
            {
                var OldFeature = await _dBContext.SubFeaturesTbls.FindAsync(subFeatures.Sub_Feature_ID);
                var service = await _dBContext.ServicesTbls.FindAsync(subFeatures.Sub_Service_ID);

                if(service is null)
                    return Result<string>.Failed("لم يتم ايجاد العنصر المطلوب");


                if (OldFeature != null)
                {
                    OldFeature.Sub_Feature_Text = subFeatures.Sub_Feature_Text;
                    OldFeature.Sub_Feature_Text_Ar = subFeatures.Sub_Feature_Text_Ar;
                    OldFeature.Sub_Service_ID = (int)subFeatures.Sub_Service_ID;
                    await _dBContext.SaveChangesAsync();
                    return Result<string>.Success("تمت عملية التعديل بنجاح");
                }
                else
                {
                    return Result<string>.Failed("لم يتم ايجاد العنصر المطلوب");
                }
            }
            catch
            {
                return Result<string>.Failed("عذرا لقد حدث خطأ ما ");
            }
        }
        public async Task<Result<string>> AddSubFeature(SubFeatureModel subFeatures)
        {
            try
            {
                var OldFeature = new SubFeaturesTbl();

                OldFeature.Sub_Feature_Text = subFeatures.Sub_Feature_Text;
                OldFeature.Sub_Feature_Text_Ar = subFeatures.Sub_Feature_Text_Ar;
                OldFeature.Sub_Service_ID = subFeatures.Sub_Service_ID ?? 0;
                await _dBContext.SubFeaturesTbls.AddAsync(OldFeature);
                await _dBContext.SaveChangesAsync();
                return Result<string>.Success(data:OldFeature.Sub_Feature_ID.ToString());

            }
            catch
            {
                return Result<string>.Failed("عذرا لقد حدث خطأ ما ");
            }
        }
        public async Task<Result<ServiceRequestDetailsModel>> ServiceRequestDetails(int id)
        {
            try
            {

                var serviceRequests = await _dBContext.ServiceRequestsTbls.Where(a => a.Id == id).Include(a => a.CustomersTbl)
                    .Include(a => a.SubServicesTbl).ThenInclude(a => a.ServicesTbl).Select(a =>
                new ServiceRequestDetailsModel()
                {
                    Service_Request_ID = a.Id,
                    Customer_ID = a.Customer_ID,
                    Service_Request_Date = a.Service_Request_Date,
                    Service_Response_Date = a.Service_Response_Date,
                    Sub_Service_ID = a.Sub_Service_ID,
                    Request_Status = a.Request_Status,
                    Service_Active_Date = a.Service_Active_Date,
                    Finished_Date = a.Finished_Date,
                    Renewal_price = a.Renewal_price,
                    Renewal_request = a.Renewal_request,
                    Requset_Code = a.Requset_Code,
                    First_Name = a.CustomersTbl.FirstName,
                    Last_Name = a.CustomersTbl.LastName,
                    Sub_Service_Title_Ar = a.SubServicesTbl.Sub_Service_Title_Ar,
                    Service_Title_Ar = a.SubServicesTbl.ServicesTbl.Service_Title_Ar,
                    Sub_Service_Title = a.SubServicesTbl.Sub_Service_Title,
                    Service_Title = a.SubServicesTbl.ServicesTbl.Service_Title

                }).FirstOrDefaultAsync();
                if (serviceRequests != null)
                {
                    return Result<ServiceRequestDetailsModel>.Success(serviceRequests);
                }
                else
                {
                    return Result<ServiceRequestDetailsModel>.Failed("عذرا لم يتم ايجاد العنصر");
                }
            }
            catch
            {
                return Result<ServiceRequestDetailsModel>.Failed("عذرا لقد حدثت مشكلة ما ");
            }
        }

        public async Task<Result<string>> AddSubServiceRequest(int subServiceId)
        {
            var subservice = await _dBContext.SubServicesTbls.FindAsync(subServiceId);

            if(subservice is null)
                return Result<string>.Failed("عذرا لم يتم ايجاد العنصر");


            var userId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _dBContext.Users.FindAsync(userId);

            var code = Guid.NewGuid().ToString().Substring(0,8);


            var serviceDiscount = await _dBContext.Discounts.FirstOrDefaultAsync(c => c.Service_ID == subservice.Service_ID && c.StartDate.Value.Date >= DateTime.Now.Date && c.EndDate.Value.Date <= DateTime.Now.Date);

            var Price = subservice.Sub_Service_Price;


            if (serviceDiscount is not null)
                Price = Price - (Price  * (double)serviceDiscount.DiscountPercentage);

            var requst = new ServiceRequestsTbl
            {
                Customer_ID = userId,
                Price = Price,
                Service_Request_Date = DateTime.Now,
                Sub_Service_ID = subservice.Sub_Service_ID,
                Requset_Code = code,
            };


            await _dBContext.AddAsync(requst);
            await _dBContext.SaveChangesAsync();

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("ViewModels/SendServiceRequestCode.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{code}", code);
            body = body.Replace("{UserName}", user.UserName);

            var mail = new MailData
            {
                EmailToId = user.Email,
                EmailToName = user.FirstName ?? "",
                EmailSubject = "Service Request Code",
                EmailBody = body
            };

            await _emailSender.SendEmailAsync(mail);

            return Result<string>.Success("Request Added Check Your Email");

        }

        public async Task<Result<string>> AddPlanRequest(int subServiceId, double price)
        {
            var plan = await _dBContext.PlansTbls.FindAsync(subServiceId);
            
            if(plan is null)
            return Result<string>.Failed("عذرا لم يتم ايجاد العنصر");

            var userId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _dBContext.Users.FindAsync(userId);


            PlanSubscripesTbl planSubscripes = new PlanSubscripesTbl();
            planSubscripes.Plan_ID = plan.Plan_ID;
            planSubscripes.Subscripe_Code = "";
            double price1 = price / 3.3;
            planSubscripes.Customer_ID = userId;
            planSubscripes.Subscription_Price = price1;
            if (plan.Price_6m * 6 == price1)
            {
                planSubscripes.DurationInMonth = 6;
            }
            if (plan.Price_1m == price1)
            {
                planSubscripes.DurationInMonth = 1;
            }
            if (plan.Price_1y * 12 == price1)
            {
                planSubscripes.DurationInMonth = 12;
            }
            if (plan.Price_2y * 24 == price1)
            {
                planSubscripes.DurationInMonth = 24;
            }

            planSubscripes.Subscription_Start_Date = DateTime.Now;
            DateTime date = DateTime.Now.AddMonths((int)planSubscripes.DurationInMonth);
            planSubscripes.Subscription_End_Date = date;

            planSubscripes.Subscripe_Code = Guid.NewGuid().ToString().Substring(0,8);

            await _dBContext.PlanSubscripesTbls.AddAsync(planSubscripes);

            await _dBContext.SaveChangesAsync();

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("ViewModels/SendPlaneRequestCode.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{code}", planSubscripes.Subscripe_Code);
            body = body.Replace("{UserName}", user.UserName);

            var mail = new MailData
            {
                EmailToId = user.Email,
                EmailToName = user.FirstName ?? "",
                EmailSubject = "Service Request Code",
                EmailBody = body
            };

            await _emailSender.SendEmailAsync(mail);

            return Result<string>.Success("Request Added Check Your Email");
        }

        public async Task<Result<string>> UpgradeSubServiceRequest(int subServiceId)
        {

            var serviceRequestsTbl = await _dBContext.ServiceRequestsTbls.FindAsync(subServiceId);
            serviceRequestsTbl.Service_Request_Date = DateTime.Now;
            serviceRequestsTbl.Request_Status = ServiceRequestStatus.Renewal;
            serviceRequestsTbl.Renewal_request = true;
            serviceRequestsTbl.Price = serviceRequestsTbl.Renewal_price;
            _dBContext.Update(serviceRequestsTbl);
            await _dBContext.SaveChangesAsync();

            var user = await _dBContext.Users.FindAsync(serviceRequestsTbl.Customer_ID);

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("ViewModels/SendServiceRequestCode.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{code}", serviceRequestsTbl.Requset_Code);
            body = body.Replace("{UserName}", user.UserName);

            var mail = new MailData
            {
                EmailToId = user.Email,
                EmailToName = user.FirstName ?? "",
                EmailSubject = "Service Request Code",
                EmailBody = body
            };

            await _emailSender.SendEmailAsync(mail);

            return Result<string>.Success("Request Added Check Your Email");
        }
    }
}
