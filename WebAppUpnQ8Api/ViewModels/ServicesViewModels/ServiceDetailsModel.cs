using UPNprojectApi.Models;

namespace WebAppUpnQ8Api.ViewModels.ServicesViewModels
{
    public class ServiceDetailsModel
    {
        public int Service_ID { get; set; }
        public string Service_Title { get; set; }
        public string Service_Description { get; set; }
        public string Service_Title_Ar { get; set; }
        public string Service_Description_Ar { get; set; }
        public string Icon_Code { get; set; }
        public string Image { get; set; }

        public List<SubServicesTbl> subServices { get; set; }
        public List<SubServiceDetailsModel> subServiceDetails { get; set; }
        public List<SpecialFeaturesTbl> specialFeatures { get; set; }
    }
}
