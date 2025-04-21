using UPNprojectApi.Models;

namespace WebAppUpnQ8Api.ViewModels.ServicesViewModels
{
    public class SubServiceDetailsModel
    {
        public Nullable<int> Sub_Service_ID { get; set; }
        public string Sub_Service_Title { get; set; }
        public Nullable<double> Sub_Service_Price { get; set; }
        public string Sub_Service_Title_Ar { get; set; }
        public Nullable<double> Sub_Service_Price_dollar { get; set; }
        public IFormFile? upload { get; set; }
        public int Service_ID { get; set; }
        public List<SubFeatureModel> subFeatures { get; set; }
    }
}
