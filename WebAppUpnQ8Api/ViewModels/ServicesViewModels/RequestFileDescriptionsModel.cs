namespace WebAppUpnQ8Api.ViewModels.ServicesViewModels
{
    public class RequestFileDescriptionsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<RequestFileDescriptionsModel> requestFiles { get; set; }
        public Nullable<DateTime> Finished_Date { get; set; }
        public Nullable<double> Renewal_price { get; set; }
    }
}
