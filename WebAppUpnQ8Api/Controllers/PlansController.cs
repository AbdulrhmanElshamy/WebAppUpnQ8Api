using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UPNprojectApi.Models;
using WebAppUpnQ8Api.Repository;
using WebAppUpnQ8Api.ViewModels;
using WebAppUpnQ8Api.ViewModels.PlanViewModels;

namespace WebAppUpnQ8Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly IPlanRepository _planRepository;

        public PlansController(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        [HttpGet]
        public Task<Result<List<PlanDetailsModel>>> GetPlans()
        {
            return _planRepository.AllPlans();
        }
        [HttpPost]
        public async Task<Result<string>> AddPlan(PlanDetailsModel data)
        {
            return await _planRepository.PostAddNewPlan(data);
        }
        [HttpPost]
        public async Task<Result<string>> EditPlan(PlanDetailsModel data)
        {
            return await _planRepository.EditPlan(data);
        }
        [HttpPost]
        public async Task<Result<string>> DeletePlan(int id)
        {
            return await _planRepository.DeletePlan(id);
        }
        [HttpGet]
        public async Task<Result<PlanDetailsModel>> DetailsPlan(int id)
        {
            return await _planRepository.DetailsPlan(id);
        }
        [HttpGet]
        public async Task<Result<List<ContentModel>>> GetContents()
        {
            return await _planRepository.AllContents();
        }
        [HttpPost]
        public async Task<Result<string>> AddContent(ContentModel data)
        {
            return await _planRepository.AddEditcontent(data);
        }
        [HttpPost]
        public async Task<Result<string>> EditContent(ContentModel data)
        {
            return await _planRepository.AddEditcontent(data);
        }
        [HttpPost]
        public async Task<Result<string>> DeleteContent(int id)
        {
            return await _planRepository.DeleteContent(id);
        }
        [HttpGet]
        public async Task<Result<List<PlanSubscripModel>>> AllSubscrips(int id)
        {
            return await _planRepository.AllSubscrips(id);
        }
        [HttpGet]
        public async Task<Result<PlanSubscripModel>> DetailsSubscrip(int id)
        {
            return await _planRepository.DetailsSubscrip(id);
        }
        [HttpGet]
        public async Task<Result<string>> EditSubscrib(string data)
        {
            return await _planRepository.EditSubscrib(data);
        }

    }
}
