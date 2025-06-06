﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UPNprojectApi.Models;
using WebAppUpnQ8Api.Repository;
using WebAppUpnQ8Api.ViewModels;
using WebAppUpnQ8Api.ViewModels.PlanViewModels;

namespace WebAppUpnQ8Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PlansController : ControllerBase
    {
        private readonly IPlanRepository _planRepository;

        public PlansController(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        [HttpGet("GetAllPlans")]
        public async Task<Result<List<PlanDetailsModel>>> GetPlans()
        {
            return await _planRepository.AllPlans();
        }
        [HttpPost("AddPlan")]
        public async Task<Result<string>> AddPlan(PlanDetailsModel data)
        {
            return await _planRepository.PostAddNewPlan(data);
        }
        [HttpPost("EditPlan")]
        public async Task<Result<string>> EditPlan(PlanDetailsModel data)
        {
            return await _planRepository.EditPlan(data);
        }
        [HttpPost("DeletePlan/{id}")]
        public async Task<Result<string>> DeletePlan(int id)
        {
            return await _planRepository.DeletePlan(id);
        }
        [HttpGet("DetailsPlan/{id}")]
        [Authorize]
        public async Task<Result<PlanDetailsModel>> DetailsPlan(int id)
        {
            return await _planRepository.DetailsPlan(id);
        }
        [HttpGet("GetAllContents")]
        public async Task<Result<List<ContentModel>>> GetContents()
        {
            return await _planRepository.AllContents();
        }
        [HttpPost("AddContent")]
        public async Task<Result<string>> AddContent(ContentModel data)
        {
            return await _planRepository.AddEditcontent(data);
        }
        [HttpPost("EditContent")]
        public async Task<Result<string>> EditContent(ContentModel data)
        {
            return await _planRepository.AddEditcontent(data);
        }
        [HttpPost("DeleteContent/{id}")]
        public async Task<Result<string>> DeleteContent(int id)
        {
            return await _planRepository.DeleteContent(id);
        }
        [HttpGet("AllSubscrips/{id}")]
        public async Task<Result<List<PlanSubscripModel>>> AllSubscrips(int id)
        {
            return await _planRepository.AllSubscrips(id);
        }
        [HttpGet("PlanSubscripModel/{id}")]
        public async Task<Result<PlanSubscripModel>> DetailsSubscrip(int id)
        {
            return await _planRepository.DetailsSubscrip(id);
        }
        [HttpPost("EditSubscrib")]
        public async Task<Result<string>> EditSubscrib(PlanSubscripModel planSubscripModel)
        {
            return await _planRepository.EditSubscrib(planSubscripModel);
        }

    }
}
