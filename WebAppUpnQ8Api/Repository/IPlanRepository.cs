using UPNprojectApi.Models;
using WebAppUpnQ8Api.ViewModels;
using WebAppUpnQ8Api.ViewModels.PlanViewModels;

namespace WebAppUpnQ8Api.Repository
{
    public interface IPlanRepository
    {
        Task<Result<List<PlanDetailsModel>>> AllPlans();
        Task<Result<string>> PostAddNewPlan(PlanDetailsModel plan);
        Task<Result<string>> EditPlan(PlanDetailsModel data);
        Task<Result<string>> DeletePlan(int id);
        Task<Result<PlanDetailsModel>> DetailsPlan(int id);
        Task<Result<List<ContentModel>>> AllContents();
        Task<Result<string>> AddEditcontent(ContentModel data);
        Task<Result<string>> DeleteContent(int id);
        Task<Result<List<PlanSubscripModel>>> AllSubscrips(int id);//plan id
        Task<Result<PlanSubscripModel>> DetailsSubscrip(int id);
        Task<Result<string>> EditSubscrib(PlanSubscripModel planSubscripModel);
    }
}
