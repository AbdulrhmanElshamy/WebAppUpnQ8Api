using Microsoft.EntityFrameworkCore;
using UPNprojectApi.Models;
using WebAppUpnQ8Api.Models;
using WebAppUpnQ8Api.ViewModels;

namespace WebAppUpnQ8Api.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly WebAppUpnQ8ApiDBContext _context;

        public DiscountService(WebAppUpnQ8ApiDBContext context)
        {
            _context = context;
        }

        public async Task<List<DiscountDto>> GetAllAsync()
        {
            return await _context.Discounts.Select(c => new DiscountDto { Service_ID = c.Service_ID,Description = c.Description,Description_Ar = c.Description_Ar,DiscountPercentage = c.DiscountPercentage,Discount_ID = c.Discount_ID,
            EndDate = c.EndDate,StartDate = c.StartDate}).ToListAsync();
        }

        public async Task<Result<DiscountDto?>> GetByIdAsync(int id)
        {
            var discount = await _context.Discounts.Select(c => new DiscountDto
            {
                Service_ID = c.Service_ID,
                Description = c.Description,
                Description_Ar = c.Description_Ar,
                DiscountPercentage = c.DiscountPercentage,
                Discount_ID = c.Discount_ID,
                EndDate = c.EndDate,
                StartDate = c.StartDate
            }).FirstOrDefaultAsync(c => c.Discount_ID == id);

            if (discount is null)
                return Result<DiscountDto>.Faild(null);



            return Result<DiscountDto>.Success(discount);
        }

        public async Task<Result<string>> AddAsync(DiscountDto discount)
        {
            var service =await _context.ServicesTbls.FindAsync(discount.Service_ID);

            if (service is null)
                return Result<string>.Faild("service not found");

            if (discount.StartDate > discount.EndDate)
                return Result<string>.Faild("End Date must be grater than start date");

            var discountModel = new Discounts
            {
                StartDate = discount.StartDate,
                EndDate= discount.EndDate,
                Discount_ID= discount.Discount_ID,
                DiscountPercentage= discount.DiscountPercentage,
                Description_Ar= discount.Description_Ar,
                Description = discount.Description,
                Service_ID= service.Service_ID,
            };

            _context.Discounts.Add(discountModel);
            await _context.SaveChangesAsync();

            return Result<string>.Success("Discount Added");

        }

        public async Task<Result<string>> UpdateAsync(DiscountDto discount)
        {
            var service = await _context.ServicesTbls.FindAsync(discount.Service_ID);

            if (service is null)
                return Result<string>.Faild("service not found");

            if(discount.StartDate > discount.EndDate)
                return Result<string>.Faild("End Date must be grater than start date");

            var discountModel = await _context.Discounts.FindAsync(discount.Discount_ID);

            if (discountModel is null)
                return Result<string>.Faild("Discount not found");

            discountModel.StartDate = discount.StartDate;
            discountModel.EndDate = discount.EndDate;
            discountModel.Description = discount.Description;
            discountModel.DiscountPercentage = discount.DiscountPercentage;
            discountModel.Description_Ar = discount.Description_Ar;
            discountModel.Service_ID = service.Service_ID;

            _context.Discounts.Update(discountModel);
            await _context.SaveChangesAsync();

            return Result<string>.Success("Discount Updated");

        }

        public async Task<Result<string>> DeleteAsync(int id)
        {
            var discount = await _context.Discounts.FindAsync(id);
            if (discount != null)
            {

                _context.Discounts.Remove(discount);
                await _context.SaveChangesAsync();

                return Result<string>.Success("Discount Deleted!");

            }

            return Result<string>.Failed("Somting wrong!");
        }
    }

}
