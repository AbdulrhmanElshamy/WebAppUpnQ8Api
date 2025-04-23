using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UPNprojectApi.Models;
using WebAppUpnQ8Api.Models;
using WebAppUpnQ8Api.ViewModels;
using WebAppUpnQ8Api.ViewModels.HomeViewModels;

namespace WebAppUpnQ8Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly WebAppUpnQ8ApiDBContext _dBContext;

        public HomeController(WebAppUpnQ8ApiDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        [HttpGet]
        public async Task<Result<List<GetServicesModel>>> GetAllServices()
        {
            var servicesAr = await _dBContext.ServicesTbls.Select(a =>
            new GetServicesModel()
            {
                Service_ID = a.Service_ID,
                Service_Title = a.Service_Title_Ar,
                Service_Description = a.Service_Description_Ar,
                Image = a.Image
            }).ToListAsync();

            var servicesEng = await _dBContext.ServicesTbls.Select(a =>
            new GetServicesModel()
            {
                Service_ID = a.Service_ID,
                Service_Title = a.Service_Title,
                Service_Description = a.Service_Description,
                Image = a.Image
            }).ToListAsync();

            return Result<List<GetServicesModel>>.Success(servicesAr, servicesEng);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTestmonial()
        {
            var testmonials = await _dBContext.TestmonialsTbls.Include(a => a.CustomersTbl).Select(a => new
            {
                Customer_ID = a.Customer_ID,
                Testmonial_ID = a.Testmonial_ID,
                Rating_Stars = a.Rating_Stars,
                Testmonial_Note = a.Testmonial_Note,
                First_Name = a.CustomersTbl.FirstName,
                Last_Name = a.CustomersTbl.LastName
            }).ToListAsync();
            return Ok(testmonials);
        }
        [HttpGet]
        public async Task<Result<List<GetPlanModel>>> GetAllPlans()
        {

            var plans = await _dBContext.PlansTbls.Include(a => a.PlanContentsTbls.Where(s => s.Plan_ID == a.Plan_ID)).ThenInclude(s => s.ContentsTbl).Select(
             a => new GetPlanModel()
             {
                 Plan_ID = a.Plan_ID,
                 Plan_Title = a.Plan_Title_Ar,

                 Plan_Description = a.Plan_Description_Ar,

                 Price_6m = a.Price_6m,
                 Price_1y = a.Price_1y,
                 Price_2y = a.Price_2y,
                 Price_1m = a.Price_1m,
                 Plan_Contents = a.PlanContentsTbls.Select(s => new GetPlanContentModel()
                 {
                     Plan_Content_ID = s.Plan_Content_ID,
                     Content_ID = s.Content_ID,
                     Plan_ID = s.Plan_ID,
                     Content_Value = s.Content_Value_Ar,
                     Content_Name = s.ContentsTbl.Content_Name_Ar
                 }).ToList()
             }).ToListAsync();
            var plansEng = await _dBContext.PlansTbls.Include(a => a.PlanContentsTbls.Where(s => s.Plan_ID == a.Plan_ID)).ThenInclude(s => s.ContentsTbl).Select(
             a => new GetPlanModel()
             {
                 Plan_ID = a.Plan_ID,

                 Plan_Title = a.Plan_Title,

                 Plan_Description = a.Plan_Description,
                 Price_6m = a.Price_6m,
                 Price_1y = a.Price_1y,
                 Price_2y = a.Price_2y,
                 Price_1m = a.Price_1m,
                 Plan_Contents = a.PlanContentsTbls.Select(s => new GetPlanContentModel()
                 {
                     Plan_Content_ID = s.Plan_Content_ID,
                     Content_ID = s.Content_ID,
                     Plan_ID = s.Plan_ID,
                     Content_Value = s.Content_Value,
                     Content_Name = s.ContentsTbl.Content_Name
                 }).ToList()
             }).ToListAsync();
            return Result<List<GetPlanModel>>.Success(plans, plansEng);
        }
        [HttpGet]
        public async Task<Result<GetServiceDetailsModel>> GetServiceDetails(int id)
        {

            var serviceAr = await _dBContext.ServicesTbls.Where(a => a.Service_ID == id).Include(a => a.SubServicesTbls.Where(s => s.Service_ID == a.Service_ID)).
                Include(a => a.SpecialFeaturesTbls.Where(s => s.Service_ID == a.Service_ID)).Select(a =>
                new GetServiceDetailsModel()
                {
                    Service_ID = a.Service_ID,
                    Service_Title = a.Service_Title_Ar,
                    Service_Description = a.Service_Description_Ar,
                    Image = a.Image,
                    SubServices = a.SubServicesTbls.Select(b =>
                    new GetSubServiceModel()
                    {
                        Sub_Service_ID = b.Sub_Service_ID,
                        Sub_Service_Title = b.Sub_Service_Title_Ar,
                        Sub_Service_Price = b.Sub_Service_Price,
                        Image = b.Image,
                        subServiceFeatures = b.SubFeaturesTbls.Select(s =>
                        new GetSubServiceFeatureModel()
                        {
                            Sub_Feature_ID = s.Sub_Feature_ID,
                            Sub_Feature_Text = s.Sub_Feature_Text_Ar
                        }).ToList()
                    }).ToList(),
                    IsSpecialService = (a.SpecialFeaturesTbls.Where(s => s.Service_ID == a.Service_ID).Count() != 0)
                }).FirstOrDefaultAsync();

            var serviceEng = await _dBContext.ServicesTbls.Where(a => a.Service_ID == id).Include(a => a.SubServicesTbls.Where(s => s.Service_ID == a.Service_ID)).
                Include(a => a.SpecialFeaturesTbls.Where(s => s.Service_ID == a.Service_ID)).Select(a =>
                new GetServiceDetailsModel()
                {
                    Service_ID = a.Service_ID,
                    Service_Title = a.Service_Title,
                    Service_Description = a.Service_Description,
                    Image = a.Image,
                    SubServices = a.SubServicesTbls.Select(b =>
                    new GetSubServiceModel()
                    {
                        Sub_Service_ID = b.Sub_Service_ID,
                        Sub_Service_Title = b.Sub_Service_Title,
                        Sub_Service_Price = b.Sub_Service_Price,
                        Image = b.Image,
                        subServiceFeatures = b.SubFeaturesTbls.Select(s =>
                        new GetSubServiceFeatureModel()
                        {
                            Sub_Feature_ID = s.Sub_Feature_ID,
                            Sub_Feature_Text = s.Sub_Feature_Text
                        }).ToList()
                    }).ToList(),
                    IsSpecialService = (a.SpecialFeaturesTbls.Where(s => s.Service_ID == a.Service_ID).Count() != 0)
                }).FirstOrDefaultAsync();

            return Result<GetServiceDetailsModel>.Success(serviceAr, serviceEng);
        }
        [HttpGet]
        public async Task<Result<List<GetSpecialServiceFeatureModel>>> GetSpecialFeatures(int id) // service id 
        {
            var specialFeaturesAr = await _dBContext.SpecialFeaturesTbls.Where(a => a.Service_ID == id).Select(a =>
            new GetSpecialServiceFeatureModel()
            {
                Special_Feature_ID = a.Special_Feature_ID,
                Feature_Name = a.Feature_Name_Ar,
                Feature_Description = a.Feature_Description_Ar,
                Feature_Price = a.Feature_Price
            }).ToListAsync();
            var specialFeaturesEng = await _dBContext.SpecialFeaturesTbls.Where(a => a.Service_ID == id).Select(a =>
            new GetSpecialServiceFeatureModel()
            {
                Special_Feature_ID = a.Special_Feature_ID,
                Feature_Name = a.Feature_Name,
                Feature_Description = a.Feature_Description,
                Feature_Price = a.Feature_Price
            }).ToListAsync();
            return Result<List<GetSpecialServiceFeatureModel>>.Success(specialFeaturesAr, specialFeaturesEng);
        }



        [HttpGet]
        [Authorize]
        public async Task<Result<GetSubServiceModel>> GetCheckoutSubService(int id)
        {
            var serviceAr = await _dBContext.SubServicesTbls.Where(a => a.Sub_Service_ID == id).Include(a => a.SubFeaturesTbls).Select(a =>
            new GetSubServiceModel()
            {
                Sub_Service_ID = id,
                Sub_Service_Title = a.Sub_Service_Title_Ar,
                Sub_Service_Price = a.Sub_Service_Price,
                Image = a.Image
            }).FirstOrDefaultAsync();
            var serviceEng = await _dBContext.SubServicesTbls.Where(a => a.Sub_Service_ID == id).Include(a => a.SubFeaturesTbls).Select(a =>
           new GetSubServiceModel()
           {
               Sub_Service_ID = id,
               Sub_Service_Title = a.Sub_Service_Title,
               Sub_Service_Price = a.Sub_Service_Price,
               Image = a.Image
           }).FirstOrDefaultAsync();
            return Result<GetSubServiceModel>.Success(serviceAr, serviceEng);
        }

        [HttpGet]
        [Authorize]
        public async Task<Result<GetPlanModel>> GetCheckoutPlan(int id)
        {
            var PlanAr = await _dBContext.PlansTbls.Where(a => a.Plan_ID == id).Select(
                a => new GetPlanModel()
                {
                    Plan_ID = id,
                    Plan_Title = a.Plan_Title_Ar,
                    Plan_Description = a.Plan_Description_Ar,
                    Price_6m = a.Price_6m,
                    Price_1y = a.Price_1y,
                    Price_2y = a.Price_2y,
                    Price_1m = a.Price_1m,
                    Plan_Contents = a.PlanContentsTbls.Select(s => new GetPlanContentModel()
                    {
                        Plan_Content_ID = s.Plan_Content_ID,
                        Content_ID = s.Content_ID,
                        Plan_ID = s.Plan_ID,
                        Content_Value = s.Content_Value_Ar,
                        Content_Name = s.ContentsTbl.Content_Name_Ar
                    }).ToList()

                }).FirstOrDefaultAsync();
            var PlanEng = await _dBContext.PlansTbls.Where(a => a.Plan_ID == id).Select(
                a => new GetPlanModel()
                {
                    Plan_ID = id,
                    Plan_Title = a.Plan_Title,
                    Plan_Description = a.Plan_Description,
                    Price_6m = a.Price_6m,
                    Price_1y = a.Price_1y,
                    Price_2y = a.Price_2y,
                    Price_1m = a.Price_1m,
                    Plan_Contents = a.PlanContentsTbls.Select(s => new GetPlanContentModel()
                    {
                        Plan_Content_ID = s.Plan_Content_ID,
                        Content_ID = s.Content_ID,
                        Plan_ID = s.Plan_ID,
                        Content_Value = s.Content_Value_Ar,
                        Content_Name = s.ContentsTbl.Content_Name_Ar
                    }).ToList()

                }).FirstOrDefaultAsync();
            return Result<GetPlanModel>.Success(PlanAr, PlanEng);
        }

        [HttpPost]
        [Authorize]
        public async Task<Result<string>> SubscripSpecialService(double totalprice , List<int> SpecialFeatureID , int serviceId)
        {
            try
            {
                SpecialRequestsTbl specialRequestsTbl = new SpecialRequestsTbl();
                specialRequestsTbl.User_ID = User.Identity.GetUserId();
                specialRequestsTbl.Request_Date = DateTime.Now;
                specialRequestsTbl.Service_ID = serviceId;
                await _dBContext.SpecialRequestsTbls.AddAsync(specialRequestsTbl);
                await _dBContext.SaveChangesAsync();
                List<SpecialRequestFeaturesTbl> specialRequestFeatures = new List<SpecialRequestFeaturesTbl>();
                foreach (var item in SpecialFeatureID)
                {
                    SpecialRequestFeaturesTbl special = new SpecialRequestFeaturesTbl();
                    special.Special_Request_ID = specialRequestsTbl.Special_Request_ID;
                    special.Special_Feature_ID = item ;
                    specialRequestFeatures.Add(special);
                }
                await _dBContext.SpecialRequestFeaturesTbls.AddRangeAsync(specialRequestFeatures);
                await _dBContext.SaveChangesAsync();
                var request = await _dBContext.SpecialRequestsTbls.FindAsync(specialRequestsTbl.Special_Request_ID);
                string code1 = "G" + (request.Special_Request_ID + 10) + "SP";
                request.Requset_Code = code1;
                await _dBContext.SaveChangesAsync();

                //send email 

                return Result<string>.Success("تم تسجيل طلبك بنجاح");
            }
            catch
            {
                return Result<string>.Failed("عذرا لقد حدثت مشكلة ما");
            }
           
        }
        [HttpPost]
        [Authorize]
        public async Task<Result<string>> SupscripeSubService(int id)
        {
            try
            {
                var subService = await _dBContext.SubServicesTbls.FindAsync(id);
                ServiceRequestsTbl serviceRequestsTbl = new ServiceRequestsTbl();
                serviceRequestsTbl.Id = User.Identity.GetUserId();
                serviceRequestsTbl.Sub_Service_ID = id;
                serviceRequestsTbl.Service_Request_Date = DateTime.Now;
                serviceRequestsTbl.Request_Status = 1;
                serviceRequestsTbl.Requset_Code = "";
                serviceRequestsTbl.Renewal_request = false;
                serviceRequestsTbl.Price = subService.Sub_Service_Price;
                await _dBContext.ServiceRequestsTbls.AddAsync(serviceRequestsTbl);
                int idd = serviceRequestsTbl.Service_Request_ID;
                await _dBContext.SaveChangesAsync();
                var request = await _dBContext.ServiceRequestsTbls.FindAsync(idd);
                string code1 = "G" + (request.Service_Request_ID + 10) + "S";
                request.Requset_Code = code1;
                await _dBContext.SaveChangesAsync();

                //send email

                return Result<string>.Success("تم تسجيل طلبك بنجاح");
            }
            catch
            {
                return Result<string>.Failed("عذرا لقد حدثت مشكلة ما");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<Result<string>> SubscripePlan(int id, double price)//plan id   price in dollar
        {
            try
            {
                var plan = await _dBContext.PlansTbls.FindAsync(id);
                PlanSubscripesTbl planSubscripes = new PlanSubscripesTbl();
                planSubscripes.Id = User.Identity.GetUserId();
                planSubscripes.Plan_ID = id;
                planSubscripes.Subscripe_Code = "";
                double price1 = price / 3.3;
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

                await _dBContext.PlanSubscripesTbls.AddAsync(planSubscripes);
                int idd = planSubscripes.Plan_Subscripe_ID;
                await _dBContext.SaveChangesAsync();
                var subscripe = await _dBContext.PlanSubscripesTbls.FindAsync(idd);
                string code1 = "G" + (subscripe.Plan_Subscripe_ID + 10) + "P";
                subscripe.Subscripe_Code = code1;
                await _dBContext.SaveChangesAsync();

                //string body = string.Empty;
                //using (StreamReader reader = new StreamReader(Server.MapPath("~/Views/Home/InvoiceEmail.html")))
                //{
                //    body = reader.ReadToEnd();
                //}
                //ApplicationUserManager UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                //string userid = System.Web.HttpContext.Current.User.Identity.GetUserId();
                //AspNetUser user = db.AspNetUsers.Find(userid);
                //body = body.Replace("{productname}", "You have subscribed to the plan :" + plan.Plan_Title);
                //body = body.Replace("{UserName}", user.UserName);
                //body = body.Replace("{InvoicCodeNum}", code1);
                //body = body.Replace("{TotalPrice}", price.ToString());
                //bool IsSendEmail = SendEmail.EmailSend(user.Email, "Thank you for completing the payment process ", body, true);
                //if (IsSendEmail)
                //{
                //    return new JsonResult { Data = new { status = true } };
                //}
                //else
                //{
                //    return new JsonResult { Data = new { status = false } };

                return Result<string>.Success("تم تسجيل طلبك بنجاح");
            }
            catch
            {
                return Result<string>.Failed("عذرا لقد حدثت مشكلة ما");
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<Result<string>> UpgradeSubService(int? id) // request id 
        {
            try
            {

                var serviceRequestsTbl = await _dBContext.ServiceRequestsTbls.FindAsync(id);
                serviceRequestsTbl.Service_Request_Date = DateTime.Now;
                serviceRequestsTbl.Request_Status = 4; //طلب تجديد
                serviceRequestsTbl.Renewal_request = true;
                serviceRequestsTbl.Price = serviceRequestsTbl.Renewal_price;
                await _dBContext.SaveChangesAsync();

                //string body = string.Empty;
                //using (StreamReader reader = new StreamReader(Server.MapPath("~/Views/Home/InvoiceEmail.html")))
                //{
                //    body = reader.ReadToEnd();
                //}
                //ApplicationUserManager UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                //string userid = System.Web.HttpContext.Current.User.Identity.GetUserId();
                //AspNetUser user = db.AspNetUsers.Find(userid);
                //body = body.Replace("{productname}", "You have subscribed to the Service :" + subService.Sub_Service_Title);
                //body = body.Replace("{UserName}", user.UserName);
                //body = body.Replace("{TotalPrice}", serviceRequestsTbl.Renewal_price.ToString());
                //bool IsSendEmail = SendEmail.EmailSend(user.Email, "Thank you for completing the payment process ", body, true);
                //if (IsSendEmail)
                //{
                //    return new JsonResult { Data = new { status = true } };
                //}
                //else
                //{
                //    return new JsonResult { Data = new { status = false } };
                //}
                return Result<string>.Success("تم تسجيل طلبك بنجاح");
            }
            catch
            {
                return Result<string>.Failed("عذرا لقد حدثت مشكلة ما");
            }
        }
    }
}
