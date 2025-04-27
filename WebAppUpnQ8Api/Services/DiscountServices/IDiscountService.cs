using UPNprojectApi.Models;
using WebAppUpnQ8Api.ViewModels;

namespace WebAppUpnQ8Api.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<List<Discounts>> GetAllAsync();
        Task<Result<Discounts>> GetByIdAsync(int id);
        Task<Result<string>> AddAsync(Discounts discount);
        Task<Result<string>> UpdateAsync(Discounts discount);
        Task<Result<string>> DeleteAsync(int id);
    }
}
