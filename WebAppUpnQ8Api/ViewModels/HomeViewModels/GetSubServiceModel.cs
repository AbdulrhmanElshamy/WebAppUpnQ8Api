namespace WebAppUpnQ8Api.ViewModels.HomeViewModels
{
    public class GetSubServiceModel
    {
        public int Sub_Service_ID { get; set; }
        public string Sub_Service_Title { get; set; }
        public Nullable<double> Sub_Service_Price { get; set; }
        public string Image { get; set; }
        public List<GetSubServiceFeatureModel> subServiceFeatures { get; set; }
    }
}
