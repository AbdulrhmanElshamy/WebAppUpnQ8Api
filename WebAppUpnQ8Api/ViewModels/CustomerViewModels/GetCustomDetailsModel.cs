namespace WebAppUpnQ8Api.ViewModels.CustomerViewModels
{
    public class GetCustomDetailsModel
    {
        public GetCustomModel InformationInfo { get; set; }
        //public List<CustomQuestionModel>? customQuestions { get; set; }
        public List<CustomServiceModel> customServices { get; set; }
        public List<CustomPlanModel> customPlans { get; set; }
    }
}
