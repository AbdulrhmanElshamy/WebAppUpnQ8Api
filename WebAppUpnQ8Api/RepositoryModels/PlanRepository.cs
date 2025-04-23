using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Numerics;
using UPNprojectApi.Models;
using WebAppUpnQ8Api.Models;
using WebAppUpnQ8Api.Repository;
using WebAppUpnQ8Api.ViewModels;
using WebAppUpnQ8Api.ViewModels.PlanViewModels;

namespace WebAppUpnQ8Api.RepositoryModels
{
    public class PlanRepository : IPlanRepository
    {
        private readonly WebAppUpnQ8ApiDBContext _dBContext;

        public PlanRepository(WebAppUpnQ8ApiDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<Result<string>> AddEditcontent(ContentModel content)
        {
            try
            {
                if (content != null)
                {
                    if (content.Content_ID != 0)//edit
                    {
                        var OldProduct = await _dBContext.ContentsTbls.FindAsync(content.Content_ID);
                        if (OldProduct != null)
                        {
                            OldProduct.Content_Name = content.Content_Name;
                            OldProduct.Content_Name_Ar = content.Content_Name_Ar;
                            await _dBContext.SaveChangesAsync();
                            return Result<string>.Success("تم التعديل بنجاح");
                        }
                        else
                        {
                            return Result<string>.Failed("لم يتم ايجاد العنصر الذي تريد تعديله");
                        }
                    }
                    else // add
                    {
                        ContentsTbl newcontent = new ContentsTbl();
                        newcontent.Content_Name = content.Content_Name;
                        newcontent.Content_Name_Ar = content.Content_Name_Ar;
                        await _dBContext.ContentsTbls.AddAsync(newcontent);

                        var res = await _dBContext.SaveChangesAsync();
                       
                            return Result<string>.Success("تمت الاضافة بنجاح");                        
                    }
                }
                else
                {
                    return Result<string>.Failed("لقد قمت بارسال بيانات فارغة");
                }
            }
            catch
            {
                return Result<string>.Failed("عذرا هناك مشكلة ما يرجى اعادة المحاولة ");
            }
        }

        public async Task<Result<List<ContentModel>>> AllContents(ContentQueryParameters parameters)
        {
            try
            {
                var query = _dBContext.ContentsTbls.AsQueryable();

                if (!string.IsNullOrWhiteSpace(parameters.Search))
                {
                    query = query.Where(c =>
                        c.Content_Name.Contains(parameters.Search) ||
                        c.Content_Name_Ar.Contains(parameters.Search));
                }

                var contents = await query
                    .OrderByDescending(c => c.Content_ID)
                    .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                    .Take(parameters.PageSize)
                    .Select(a => new ContentModel
                    {
                        Content_ID = a.Content_ID,
                        Content_Name = a.Content_Name,
                        Content_Name_Ar = a.Content_Name_Ar
                    })
                    .ToListAsync();

                return Result<List<ContentModel>>.Success(contents);
            }
            catch
            {
                return Result<List<ContentModel>>.Failed("عذرا حدثت مشكلة ما");
            }
        }


        public async Task<Result<List<PlanDetailsModel>>> AllPlans(PlanQueryParameters parameters)
        {
            try
            {
                var query = _dBContext.PlansTbls.AsQueryable();

                if (!string.IsNullOrWhiteSpace(parameters.Search))
                {
                    query = query.Where(p =>
                        p.Plan_Title.Contains(parameters.Search) ||
                        p.Plan_Description.Contains(parameters.Search) ||
                        p.Plan_Title_Ar.Contains(parameters.Search) ||
                        p.Plan_Description_Ar.Contains(parameters.Search));
                }

                if (parameters.MinPrice.HasValue)
                {
                    query = query.Where(p =>
                        (p.Price_1m ?? 0) >= (double)parameters.MinPrice ||
                        (p.Price_6m ?? 0) >= (double)parameters.MinPrice ||
                        (p.Price_1y ?? 0) >= (double)parameters.MinPrice ||
                        (p.Price_2y ?? 0) >= (double)parameters.MinPrice);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    query = query.Where(p =>
                        (p.Price_1m ?? double.MaxValue) <= (double)parameters.MaxPrice ||
                        (p.Price_6m ?? double.MaxValue) <= (double)parameters.MaxPrice ||
                        (p.Price_1y ?? double.MaxValue) <= (double)parameters.MaxPrice ||
                        (p.Price_2y ?? double.MaxValue) <= (double)parameters.MaxPrice);
                }

                int totalCount = await query.CountAsync();

                var plans = await query
                    .OrderByDescending(p => p.Plan_ID)
                    .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                    .Take(parameters.PageSize)
                    .Select(a => new PlanDetailsModel
                    {
                        Plan_ID = a.Plan_ID,
                        Plan_Title = a.Plan_Title,
                        Plan_Description = a.Plan_Description,
                        Price_6m = a.Price_6m,
                        Price_1y = a.Price_1y,
                        Price_2y = a.Price_2y,
                        Price_1m = a.Price_1m,
                        Plan_Title_Ar = a.Plan_Title_Ar,
                        Plan_Description_Ar = a.Plan_Description_Ar
                    })
                    .ToListAsync();

                return plans.Count > 0
                    ? Result<List<PlanDetailsModel>>.Success(plans)
                    : Result<List<PlanDetailsModel>>.Failed("عذرا لا يوجد خطط بعد");
            }
            catch
            {
                return Result<List<PlanDetailsModel>>.Failed("عذرا حدثت مشكلة ما");
            }
        }



        public async Task<Result<List<PlanSubscripModel>>> AllSubscrips(int id)
        {
            List<PlanSubscripModel> planSubscrips = null;
            if (id != 0)
            {
                planSubscrips = await _dBContext.PlanSubscripesTbls.Where(a => a.Plan_ID == id).
                    Select(a => new PlanSubscripModel()
                    {
                        Plan_Subscripe_ID = a.Plan_Subscripe_ID,
                        Customer_ID = a.Customer_ID,
                        Subscription_Price = a.Subscription_Price,
                        Plan_ID = a.Plan_ID,
                        Discount_ID = a.Discount_ID,
                        Subscription_Start_Date = a.Subscription_Start_Date,
                        Subscription_End_Date = a.Subscription_End_Date,
                        DurationInMonth = a.DurationInMonth,
                        Subscripe_Code = a.Subscripe_Code,
                        Plan_Title = a.PlansTbl.Plan_Title,
                        Plan_Description = a.PlansTbl.Plan_Description,
                        Plan_Title_Ar = a.PlansTbl.Plan_Title_Ar,
                        Plan_Description_Ar = a.PlansTbl.Plan_Description_Ar,
                        Final_Price = a.Subscription_Price - (a.Subscription_Price * a.DiscountsTbl.Discount_Percent / 100),
                        First_Name = a.CustomersTbl.FirstName,
                        Last_Name = a.CustomersTbl.LastName,
                        Discount_Percent = a.DiscountsTbl.Discount_Percent,
                        

                    }).ToListAsync();
                    
                   
            }
            else
            {
                planSubscrips = await _dBContext.PlanSubscripesTbls.
                   Select(a => new PlanSubscripModel()
                   {
                       Plan_Subscripe_ID = a.Plan_Subscripe_ID,
                       Customer_ID = a.Customer_ID,
                       Subscription_Price = a.Subscription_Price,
                       Plan_ID = a.Plan_ID,
                       Discount_ID = a.Discount_ID,
                       Subscription_Start_Date = a.Subscription_Start_Date,
                       Subscription_End_Date = a.Subscription_End_Date,
                       DurationInMonth = a.DurationInMonth,
                       Subscripe_Code = a.Subscripe_Code,
                       Plan_Title = a.PlansTbl.Plan_Title,
                       Plan_Description = a.PlansTbl.Plan_Description,
                       Plan_Title_Ar = a.PlansTbl.Plan_Title_Ar,
                       Plan_Description_Ar = a.PlansTbl.Plan_Description_Ar,
                       Final_Price = a.Subscription_Price - (a.Subscription_Price * a.DiscountsTbl.Discount_Percent / 100),
                       First_Name = a.CustomersTbl.FirstName,
                       Last_Name = a.CustomersTbl.LastName,
                       Discount_Percent = a.DiscountsTbl.Discount_Percent,


                   }).ToListAsync();
            }
            foreach (var item in planSubscrips)
            {
                
                DateTime f = DateTime.Now;
                DateTime g = (DateTime)item.Subscription_End_Date;
                TimeSpan g1 = g.Subtract(f);

                if (g1.Days > 0)
                {
                    item.status = false;
                }
                else
                {
                    item.status = true;
                }
            }

            return Result<List<PlanSubscripModel>>.Success(planSubscrips);
        }

        public async Task<Result<string>> DeleteContent(int id)
        {
            
            var content = await _dBContext.ContentsTbls.Where(a => a.Content_ID == id).Include(a => a.PlanContentsTbls).Include(a => a.PlanSubscripeContentsTbls).FirstOrDefaultAsync();
            if(content == null || content.PlanContentsTbls.Count() != 0 || content.PlanSubscripeContentsTbls.Count() != 0)
            {
                return Result<string>.Failed("عذرا لا يمكن حذف هذا العنصر لوجود ارتباط بينه وبين عناصر اخرين");
            }
            else
            {
                _dBContext.ContentsTbls.Remove(content);
                _dBContext.SaveChanges();
                return Result<string>.Success("تمت عملية الحذف بنجاح");
            }
            
        }

        public async Task<Result<string>> DeletePlan(int id)
        {
            try
            {
                var plan = await _dBContext.PlansTbls.Where(a => a.Plan_ID == id).Include(a => a.PlanContentsTbls).Include(a => a.PlanSubscripesTbls).FirstOrDefaultAsync();
                if (plan == null || plan.PlanContentsTbls.Count() != 0 || plan.PlanSubscripesTbls.Count() != 0)
                {
                    return Result<string>.Failed("عذرا لا يمكن حذف هذا العنصر لوجود ارتباط بينه وبين عناصر اخرين");
                }
                else
                {
                    _dBContext.PlansTbls.Remove(plan);
                    _dBContext.SaveChanges();
                    return Result<string>.Success("تمت عملية الحذف بنجاح");
                }
            }
            catch
            {
                return Result<string>.Failed("عذرا هناك مشكلة ما ");
            }
        }

        public async Task<Result<PlanDetailsModel>> DetailsPlan(int id)
        {
            try
            {
                var plan = await _dBContext.PlansTbls.Where(a => a.Plan_ID == id).
                    Include(a => a.PlanContentsTbls).ThenInclude(b => b.ContentsTbl).
                    Select(a => new PlanDetailsModel()
                    {
                        Plan_ID = a.Plan_ID,
                        Plan_Title = a.Plan_Title,
                        Plan_Description = a.Plan_Description,
                        Price_6m = a.Price_6m,
                        Price_1y = a.Price_1y,
                        Price_2y = a.Price_2y,
                        Price_1m = a.Price_1m,
                        Plan_Title_Ar = a.Plan_Title_Ar,
                        Plan_Description_Ar = a.Plan_Description_Ar,
                        PlanContentModels = a.PlanContentsTbls.Select(b => new PlanContentModel()
                        {
                            Plan_Content_ID = b.Plan_Content_ID,
                            Content_ID = b.Content_ID,
                            Plan_ID = b.Plan_ID,
                            Content_Value = b.Content_Value,
                            Content_Name = b.ContentsTbl.Content_Name,
                            Content_Value_Ar = b.Content_Value_Ar,
                            Content_Name_Ar = b.ContentsTbl.Content_Name_Ar,
                        }).ToList(),

                    }).FirstOrDefaultAsync();
                if (plan != null)
                {
                    return Result<PlanDetailsModel>.Success(plan);
                }
                else
                {
                    return Result<PlanDetailsModel>.Failed("عذرا لم يتم ايجاد العنصر المطلوب");
                }
            }
            catch
            {
                return Result<PlanDetailsModel>.Failed("عذرا حدثت مشكلة ما");

            }
        }

        public async Task<Result<PlanSubscripModel>> DetailsSubscrip(int id)
        {
            try
            {
                var subscripe = await _dBContext.PlanSubscripesTbls.Where(a => a.Plan_Subscripe_ID == id).
                    Include(a => a.CustomersTbl).Include(a => a.PlanSubscripeContentsTbls).
                    ThenInclude(b => b.ContentsTbl).Select(a => new PlanSubscripModel()
                    {
                        Plan_Subscripe_ID = a.Plan_Subscripe_ID,
                        Customer_ID = a.Customer_ID,
                        Subscription_Price = a.Subscription_Price,
                        Plan_ID = a.Plan_ID,
                        Discount_ID = a.Discount_ID,
                        Subscription_Start_Date = a.Subscription_Start_Date,
                        Subscription_End_Date = a.Subscription_End_Date,
                        DurationInMonth = a.DurationInMonth,
                        Id = a.Id,
                        Subscripe_Code = a.Subscripe_Code,
                        First_Name = a.CustomersTbl.FirstName,
                        Last_Name = a.CustomersTbl.LastName,
                        Plan_Title = a.PlansTbl.Plan_Title,
                        Plan_Description = a.PlansTbl.Plan_Description,
                        Discount_Percent = a.DiscountsTbl.Discount_Percent,
                        Price_6m = a.PlansTbl.Price_6m,
                        Price_1y = a.PlansTbl.Price_1y,
                        Price_2y = a.PlansTbl.Price_2y,
                        Price_1m = a.PlansTbl.Price_1m,
                        //Final_Price = a.Final_Price,
                        //status = a.status,
                        planeSubscripContents = a.PlanSubscripeContentsTbls.Select(b => new PlaneSubscripContentModel()
                        {
                            Subscripe_Content_ID = b.Subscripe_Content_ID,
                            Plan_Subscripe_ID = b.Plan_Subscripe_ID,
                            Content_ID = b.Content_ID,
                            Current_Value = b.Current_Value,
                            Content_Name = b.ContentsTbl.Content_Name,
                            Content_Name_Ar = b.ContentsTbl.Content_Name_Ar,

                        }).ToList(),

                    }).FirstOrDefaultAsync();
                if(subscripe != null)
                {
                    return Result<PlanSubscripModel>.Success(subscripe);
                }
                else
                {
                    return Result<PlanSubscripModel>.Failed("عذرا لم يتم ايجاد العنصر المطلوب");
                }
            }
            catch
            {
                return Result<PlanSubscripModel>.Failed("عذرا حدثت مشكلة ما");
            }
            
        }
        public async Task<Result<string>> EditPlan(PlanDetailsModel plan)
        {
            try
            {
                if (plan == null || plan.Plan_ID == 0)
                {
                    return Result<string>.Failed("عذرا هناك مشكلة ما ");
                }

                var oldPlan = await _dBContext.PlansTbls.FindAsync(plan.Plan_ID);
                if (oldPlan == null)
                {
                    return Result<string>.Failed("عذرا الخطة غير موجودة");
                }


                oldPlan.Plan_Title = plan.Plan_Title;
                oldPlan.Plan_Description = plan.Plan_Description;
                oldPlan.Plan_Title_Ar = plan.Plan_Title_Ar;
                oldPlan.Plan_Description_Ar = plan.Plan_Description_Ar;
                oldPlan.Price_6m = plan.Price_6m;
                oldPlan.Price_1y = plan.Price_1y;
                oldPlan.Price_2y = plan.Price_2y;
                oldPlan.Price_1m = plan.Price_1m;

                foreach (var item1 in plan.PlanContentModels)
                {
                    if (item1.Plan_Content_ID == 0)
                    {
                        
                        var contentExists = await _dBContext.ContentsTbls
                            .AnyAsync(c => c.Content_ID == item1.Content_ID);

                        if (!contentExists)
                        {
                            return Result<string>.Failed($"المحتوى برقم المعرف {item1.Content_ID} غير موجود");
                        }

                        var newPlanContent = new PlanContentsTbl
                        {
                            Content_Value = item1.Content_Value,
                            Content_Value_Ar = item1.Content_Value_Ar,
                            Content_ID = item1.Content_ID,
                            Plan_ID = plan.Plan_ID
                        };

                        await _dBContext.PlanContentsTbls.AddAsync(newPlanContent);
                    }
                    else
                    {
                       
                        var oldPlanContent = await _dBContext.PlanContentsTbls
                            .Where(a => a.Plan_Content_ID == item1.Plan_Content_ID)
                            .FirstOrDefaultAsync();

                        if (oldPlanContent == null)
                        {
                            return Result<string>.Failed($"المحتوى برقم المعرف {item1.Plan_Content_ID} غير موجود");
                        }

                        oldPlanContent.Content_Value = item1.Content_Value;
                        oldPlanContent.Content_Value_Ar = item1.Content_Value_Ar;
                    }
                }

                await _dBContext.SaveChangesAsync();
                return Result<string>.Success("تمت عملية التعديل بنجاح");
            }
            catch (Exception ex)
            {
                
                return Result<string>.Failed("عذرا هناك مشكلة ما ");
            }
        }



        public async Task<Result<string>> EditSubscrib(PlanSubscripModel planSubscripModel)
        {
            try
            {
                foreach (var item in planSubscripModel.planeSubscripContents)
                {
                    var plan = _dBContext.PlanSubscripeContentsTbls.Find(item.Subscripe_Content_ID);
                    if(plan is null)
                        return Result<string>.Failed("الخطه غير موجوده");

                    plan.Current_Value = item.Current_Value;
                    await _dBContext.SaveChangesAsync();
                }
                if (planSubscripModel.Subscription_End_Date != null)
                {
                    var subscripe = _dBContext.PlanSubscripesTbls.Find(planSubscripModel.Plan_Subscripe_ID);
                    if (subscripe is null)
                        return Result<string>.Failed("الاشتراك غير موجود");

                    subscripe.Subscription_End_Date = planSubscripModel.Subscription_End_Date;
                    await _dBContext.SaveChangesAsync();
                }
                return Result<string>.Success("تمت عملية التعديل بنجاح");
            }
            catch
            {
                return Result<string>.Failed("عذرا هناك مشكلة ما ");
            }
        }

        public async Task<Result<string>> PostAddNewPlan(PlanDetailsModel plan)
        {
            try
            {
                if (plan == null)
                    return Result<string>.Failed("عذرا هناك مشكلة ما");

                var newPlan = new PlansTbl
                {
                    Plan_Title = plan.Plan_Title,
                    Plan_Description = plan.Plan_Description,
                    Plan_Title_Ar = plan.Plan_Title_Ar,
                    Plan_Description_Ar = plan.Plan_Description_Ar,
                    Price_1m = plan.Price_1m,
                    Price_6m = plan.Price_6m,
                    Price_1y = plan.Price_1y,
                    Price_2y = plan.Price_2y
                };

                await _dBContext.PlansTbls.AddAsync(newPlan);
                await _dBContext.SaveChangesAsync();

                var validContentIds = await _dBContext.ContentsTbls
                    .Select(c => c.Content_ID)
                    .ToListAsync();

                var planContents = plan.PlanContentModels
                    .Where(item => validContentIds.Contains(item.Content_ID)) 
                    .Select(item => new PlanContentsTbl
                    {
                        Plan_ID = newPlan.Plan_ID,
                        Content_ID = item.Content_ID,
                        Content_Value = item.Content_Value,
                        Content_Value_Ar = item.Content_Value_Ar
                    }).ToList();
                var invalidContentIds = plan.PlanContentModels
                    .Where(item => !validContentIds.Contains(item.Content_ID))
                    .Select(item => item.Content_ID)
                    .ToList();

                if (invalidContentIds.Any())
                {
                    return Result<string>.Failed($"المحتوى برقم المعرف {string.Join(", ", invalidContentIds)} غير موجود");
                }

                if (planContents.Count > 0)
                {
                    await _dBContext.PlanContentsTbls.AddRangeAsync(planContents);
                    await _dBContext.SaveChangesAsync();
                }

                return Result<string>.Success("تم الحفظ بنجاح");
            }
            catch (Exception ex)
            {
                
                return Result<string>.Failed("عذرا هناك مشكلة ما");
            }
        }


    }
}
