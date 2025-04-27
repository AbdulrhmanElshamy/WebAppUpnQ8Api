using WebAppUpnQ8Api.ViewModels.PlanViewModels;
using WebAppUpnQ8Api.ViewModels;
using WebAppUpnQ8Api.Repository;
using WebAppUpnQ8Api.ViewModels.CustomerViewModels;
using WebAppUpnQ8Api.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAppUpnQ8Api.RepositoryModels
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly WebAppUpnQ8ApiDBContext _dBContext;
        public CustomerRepository(WebAppUpnQ8ApiDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<Result<List<GetCustomModel>>> AllCustomers()
        {
            try
            {
                var customers = await _dBContext.Users.Include(a => a.CodeNumbersTbl).
                    Include(a => a.CitiesTbl).
                    ThenInclude(b => b.CountriesTbl).
                    Select(a => new GetCustomModel
                    {
                        Customer_ID = a.Id,
                        First_Name = a.FirstName,
                        Last_Name = a.LastName,
                        Birth_Day_Date = a.BirthDate,
                        Phone_Number_1 = a.PhoneNumber,
                        Phone_Number_2 = a.SecondPhoneNumber,
                        Address_1 = a.FirstAddress,
                        Address_2 = a.SecondAddress,
                        Country_ID = a.CountryId,
                        City_Name_Eng = a.CitiesTbl.City_Name_Eng,
                        Country_Name_Eng = a.CitiesTbl.CountriesTbl.Country_Name_Eng,
                        City_ID = a.CityId,
                        Gender = a.Gender,
                        Register_Date = a.RegisterDate,
                        Code_Number_ID_1 = a.CodeNumberId,
                        Code_Number = a.CodeNumbersTbl.Code_Number

                    }).ToListAsync();
                return Result<List<GetCustomModel>>.Success(customers);

            }
            catch
            {
                return Result<List<GetCustomModel>>.Failed("لقد حدث خطا ما");
            }
        }

        public async Task<Result<GetCustomDetailsModel>> DetailsCustomer(string id)
        {
            try
            {
                var customer = await _dBContext.Users.Include(a => a.CodeNumbersTbl).
                    Include(a => a.CitiesTbl).
                    ThenInclude(b => b.CountriesTbl).Include(a => a.PlanSubscripesTbls).
                    Include(a => a.SubscriptionsTbls).Include(a => a.ServiceRequestsTbls).
                    Where(a => a.Id == id).Select(a => new GetCustomDetailsModel
                    {
                        InformationInfo = new GetCustomModel()
                        {
                        Customer_ID = a.Id,
                        First_Name = a.FirstName,
                        Last_Name = a.LastName,
                        Birth_Day_Date = a.BirthDate,
                        Phone_Number_1 = a.PhoneNumber,
                        Phone_Number_2 = a.SecondPhoneNumber,
                        Address_1 = a.FirstAddress,
                        Address_2 = a.SecondAddress,
                        Country_ID = a.CountryId,
                        City_Name_Eng = a.CitiesTbl.City_Name_Eng,
                        Country_Name_Eng = a.CitiesTbl.CountriesTbl.Country_Name_Eng,
                        City_ID = a.CityId,
                        Gender = a.Gender,
                        Register_Date = a.RegisterDate,
                        Code_Number_ID_1 = a.CodeNumberId,
                        Code_Number = a.CodeNumbersTbl.Code_Number
                        },
                        customServices = a.ServiceRequestsTbls.Select(b => new CustomServiceModel 
                                {
                                   Service_Request_ID = b.Id,
                            Customer_ID = b.Customer_ID,
                            Service_Request_Statues = b.Service_Request_Statues,
                            Service_Request_Date = b.Service_Request_Date,
                            Service_Response_Date = b.Service_Response_Date,
                            Sub_Service_ID = b.Sub_Service_ID,
                            Sub_Service_Title = b.SubServicesTbl.Sub_Service_Title,
                            Request_Status = b.Request_Status,
                            Service_Active_Date = b.Service_Active_Date,
                            Price = b.Price,
                            Requset_Code = b.Requset_Code,
                            Finished_Date = b.Finished_Date,
                            Renewal_price = b.Renewal_price,
                            Renewal_request = b.Renewal_request
                        }).ToList(),
                        customPlans = a.PlanSubscripesTbls.Select( c => new CustomPlanModel
                        {
                            Plan_Subscripe_ID = c.Plan_Subscripe_ID,
                            Customer_ID = c.Customer_ID,
                            Subscription_Price = c.Subscription_Price,
                            Plan_ID = c.Plan_ID,
                            Plan_Title = c.PlansTbl.Plan_Title,
                            Discount_ID = c.Discount_ID,
                            Discount_Percent = c.DiscountsTbl.Discount_Percent,
                            Discount_Code = c.DiscountsTbl.Discount_Code,
                            Subscription_Start_Date = c.Subscription_Start_Date,
                            Subscription_End_Date = c.Subscription_End_Date,
                            DurationInMonth = c.DurationInMonth,
                            Subscripe_Code = c.Subscripe_Code
                        }).ToList()


                    }).FirstOrDefaultAsync();
                return Result<GetCustomDetailsModel>.Success(customer);

            }
            catch
            {
                return Result<GetCustomDetailsModel>.Failed("لقد حدث خطا ما");
            }
        }
    }
}
