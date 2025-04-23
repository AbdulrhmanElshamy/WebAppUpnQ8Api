using WebAppUpnQ8Api.ViewModels.PlanViewModels;
using WebAppUpnQ8Api.ViewModels;
using WebAppUpnQ8Api.ViewModels.CustomerViewModels;

namespace WebAppUpnQ8Api.Repository
{
    public interface ICustomerRepository
    {
        Task<Result<List<GetCustomModel>>> AllCustomers();
        Task<Result<GetCustomDetailsModel>> DetailsCustomer(string id);
    }
}
