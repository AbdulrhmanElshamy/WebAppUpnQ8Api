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

        public async Task<List<Discounts>> GetAllAsync()
        {
            return await _context.Discounts.Include(d => d.Service).ToListAsync();
        }

        public async Task<Result<Discounts>> GetByIdAsync(int id)
        {
            var discount = await _context.Discounts.Include(c => c.Service).FirstOrDefaultAsync(c => c.Discount_ID == id);

            if (discount is null)
                return Result<Discounts>.Faild(new Discounts());



            return Result<Discounts>.Success(discount);
        }

        public async Task<Result<string>> AddAsync(Discounts discount)
        {
            var service =await _context.ServicesTbls.FindAsync(discount.Service_ID);

            if (service is null)
                return Result<string>.Faild("service not found");

            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();

            return Result<string>.Success("Discount Added");

        }

        public async Task<Result<string>> UpdateAsync(Discounts discount)
        {
            var service = await _context.ServicesTbls.FindAsync(discount.Service_ID);

            if (service is null)
                return Result<string>.Faild("service not found");

            _context.Discounts.Update(discount);
            await _context.SaveChangesAsync();

            return Result<string>.Success("Discount Updated");

        }

        public async Task<Result<string>> DeleteAsync(int id)
        {
            var discount = await _context.DiscountsTbls.FindAsync(id);
            if (discount != null)
            {
                _context.DiscountsTbls.Remove(discount);
                await _context.SaveChangesAsync();

                return Result<string>.Success("Discount Deleted!");

            }

            return Result<string>.Failed("Somting wrong!");
        }
    }

}
