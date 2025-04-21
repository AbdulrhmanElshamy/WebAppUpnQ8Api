namespace WebAppUpnQ8Api.ViewModels.HomeViewModels
{
    public class GetServiceDetailsModel
    {
        public int Service_ID { get; set; }
        public string Service_Title { get; set; }
        public string Service_Description { get; set; }
        public string Image { get; set; }
        public List<GetSubServiceModel> SubServices { get; set; }
        public bool IsSpecialService { get; set; }
    }
}
