using UPNprojectApi.Models;
using WebAppUpnQ8Api.ViewModels;

namespace WebAppUpnQ8Api.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<List<DiscountDto>> GetAllAsync();
        Task<Result<DiscountDto?>> GetByIdAsync(int id);
        Task<Result<string>> AddAsync(DiscountDto discount);
        Task<Result<string>> UpdateAsync(DiscountDto discount);
        Task<Result<string>> DeleteAsync(int id);
    }
}
