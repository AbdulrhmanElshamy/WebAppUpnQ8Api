using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UPNprojectApi.Models;
using WebAppUpnQ8Api.Services.DiscountServices;
using WebAppUpnQ8Api.ViewModels;

namespace WebAppUpnQ8Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Discounts>>> GetAll()
        {
            var discounts = await _discountService.GetAllAsync();
            return Ok(discounts);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Discounts>> GetById(int id)
        {
            var discount = await _discountService.GetByIdAsync(id);
            if (discount == null)
                return NotFound();

            return Ok(discount);
        }

        [HttpPost("Create")]
        public async Task<Result<string>> Create(Discounts discount)
        {

            var res = await _discountService.AddAsync(discount);
            return res;
        }

        [HttpPost("Update")]
        public async Task<Result<string>> Update(Discounts discount)
        {

            var res = await _discountService.UpdateAsync(discount);
            return res;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<Result<string>> Delete(int id)
        {
         

          var res =   await _discountService.DeleteAsync(id);
            return res;
        }
    }
}
