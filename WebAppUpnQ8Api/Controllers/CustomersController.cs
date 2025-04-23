using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppUpnQ8Api.Repository;
using WebAppUpnQ8Api.ViewModels;
using WebAppUpnQ8Api.ViewModels.CustomerViewModels;

namespace WebAppUpnQ8Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public async Task<Result<List<GetCustomModel>>> GetAllCustomers()
        {
            return await _customerRepository.AllCustomers();
        }
        [HttpGet]
        public async Task<Result<GetCustomDetailsModel>> DetailsCustomer(string id)
        {
            return await _customerRepository.DetailsCustomer(id);
        }
    }
}
